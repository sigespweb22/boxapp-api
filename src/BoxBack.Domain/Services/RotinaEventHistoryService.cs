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
    
        public async Task AddAsync(RotinaEventHistory reh)
        {
            try
            {
                await _rotinaEventHistoryRepository.AddAsync(reh);
                _unitOfWork.Commit();
            }
            catch { throw new InvalidOperationException(); }
        }

        public void Update(RotinaEventHistory reh)
        {
            try
            {
                _rotinaEventHistoryRepository.Update(reh);
                _unitOfWork.Commit();
            }
            catch { throw new InvalidOperationException(); }
        }
    }
}