using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using BoxBack.Domain.Hubs;
using BoxBack.Domain.HubsInterfaces;

namespace BoxBack.Domain.Services
{
    public class RotinaEventHistoryService : IRotinaEventHistoryService
    {
        private readonly ILogger _logger;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<NotificacaoHub, INotificacaoHub> _notificacaoHub;
        
        public RotinaEventHistoryService(ILogger<RotinaEventHistoryService> logger,
                                         IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                         IUnitOfWork unitOfWork,
                                         IHubContext<NotificacaoHub, INotificacaoHub> notificacaoHub)
        {
            _logger = logger;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _unitOfWork = unitOfWork;
            _notificacaoHub = notificacaoHub;
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
        public async Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id)
        {
            if (rotinaId == Guid.Empty) throw new ArgumentNullException(nameof(rotinaId));
            
            // create object to store rotina
            var rotinaEventHistory = new RotinaEventHistory()
            {
                Id = id,
                DataInicio =  DateTimeOffset.UtcNow,
                StatusProgresso = RotinaStatusProgressoEnum.EM_EXECUCAO,
                TotalItensSucesso = 0,
                TotalItensInsucesso = 0,
                RotinaId = rotinaId
            };

            try
            {
                await AddAsync(rotinaEventHistory);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de adicionar rotina event history | {ex.Message}");
                throw new OperationCanceledException(ex.Message);
            }

            await _notificacaoHub.Clients.All.ReceiveMessage("ROTINA_EVENT_HISTORY_CREATED_SUCCESS");
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
                rotinaEventHistoryDB.DataFim = DateTimeOffset.UtcNow;
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

            _notificacaoHub.Clients.All.ReceiveMessage("ROTINA_EVENT_HISTORY_UPDATED_SUCCESS");
        }
        public void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId)
        {
            #region Get data
            var rotinaEventHistoryDB = new RotinaEventHistory();
            try
            {
                rotinaEventHistoryDB = GetById(rotinaEventoHistoryId);
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Falhou tentativa de obter o registro de rotina event history para sua atualização. | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            #region Map to update
            rotinaEventHistoryDB.Id = rotinaEventoHistoryId;
            rotinaEventHistoryDB.DataFim = DateTimeOffset.Now;
            rotinaEventHistoryDB.StatusProgresso = RotinaStatusProgressoEnum.FALHA_EXECUCAO;
            rotinaEventHistoryDB.ExceptionMensagem = $"{exceptionMessage}";
            #endregion

            try
            {
                Update(rotinaEventHistoryDB);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {an.Message}");
                throw new OperationCanceledException(an.Message);
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {ex.Message}");
                throw new OperationCanceledException(ex.Message);
            }

            _notificacaoHub.Clients.All.ReceiveMessage("ROTINA_EVENT_HISTORY_UPDATED_SUCCESS");
        }
        public async Task<RotinaEventHistory> GetByIdWithIncludeAsync(Guid rotinaEventHistoryId)
        {
            #region Arg validation
            if (rotinaEventHistoryId == Guid.Empty)
            {
                _logger.LogInformation($"Id do evento da rotina requerido.");
                throw new ArgumentNullException(nameof(rotinaEventHistoryId));
            }
            #endregion

            #region Get data
            var rotinaEventHistorys = new RotinaEventHistory();
            try
            {
                rotinaEventHistorys = await _rotinaEventHistoryRepository.GetByIdWithIncludeAsync(rotinaEventHistoryId);
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Falhou tentativa de obter o registro de rotina event history pelo seu id. | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }

            if (rotinaEventHistorys == null)
            {
                _logger.LogInformation($"Nenhum evento de rotina encontrado com o id informado.");
                throw new OperationCanceledException($"Nenhum evento de rotina encontrado com o id informado.");
            }
            #endregion

            return rotinaEventHistorys;
        }

        public void Dispose()
        {
            _rotinaEventHistoryRepository.Dispose();
        }
    }
}