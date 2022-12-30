using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace BoxBack.Domain.Services
{
    public class RotinaEventHistoryService : IRotinaEventHistoryService
    {
        private readonly ILogger _logger;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RotinaEventHistoryService(ILogger<RotinaEventHistoryService> logger,
                                         IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                         IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RotinaEventHistory> GetByIdAsync(Guid id)
        {
            try
            {
                return await _rotinaEventHistoryRepository.GetByIdAsync(id);
            }
            catch { throw new InvalidOperationException(); }
        }
        public RotinaEventHistory GetById(Guid id)
        {
            try
            {
                return _rotinaEventHistoryRepository.GetById(id);
            }
            catch { throw new InvalidOperationException(); }
        }
        public async Task AddAsync(RotinaEventHistory reh)
        {
            try
            {
                await _rotinaEventHistoryRepository.AddAsync(reh);
                _unitOfWork.Commit();
            }
            catch (Exception ex){ throw new Exception(ex.InnerException.Message); }
        }
        public void Update(RotinaEventHistory reh)
        {
            var rotinaEventHistoryDB = _rotinaEventHistoryRepository.GetByIdAsync(reh.Id);
            try
            {
                _rotinaEventHistoryRepository.Update(reh);
                _unitOfWork.Commit();
            }
            catch (InvalidOperationException io) 
            {
                throw new InvalidOperationException(io.Message);
            }
            catch (ArgumentException ex) 
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        public void UpdateWithStatusConcluidaHandle(Guid id, Int64 totalSuccess, Int64 totalFailures)
        {
            #region Argument Validations
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            #endregion

            #region Get data
            var rotinaEventHistoryDB = new RotinaEventHistory();
            try
            {
                rotinaEventHistoryDB = _rotinaEventHistoryRepository.GetById(id);    
            }
            catch (InvalidOperationException io)
            {
                throw new InvalidOperationException(io.Message, io.InnerException);
            }
            #endregion

            #region Map
            try
            {
                rotinaEventHistoryDB.StatusProgresso = RotinaStatusProgressoEnum.CONCLUIDA;
                rotinaEventHistoryDB.DataFim = DateTimeOffset.Now;
                rotinaEventHistoryDB.TotalItensSucesso = totalSuccess;
                rotinaEventHistoryDB.TotalItensInsucesso = totalFailures;

                _rotinaEventHistoryRepository.Update(rotinaEventHistoryDB);
                _unitOfWork.Commit();
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Operação inválida. | {io.Message}");
                throw new InvalidOperationException(io.Message, io.InnerException);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Argumento nulo. | {an.Message}");
                throw new ArgumentException(an.Message, an.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Problemas ao atualizar e efetuar commit das alterações.  | {ex.Message} | InnerException => {ex.InnerException.Message}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            #endregion
        }

        public void Dispose()
        {
            _rotinaEventHistoryRepository.Dispose();
        }
    }
}