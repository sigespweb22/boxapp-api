using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class RotinaEventHistoryService : IRotinaEventHistoryService
    {
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RotinaEventHistoryService(IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                         IUnitOfWork unitOfWork)
        {
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
    }
}