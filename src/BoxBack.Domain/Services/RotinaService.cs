using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class RotinaService : IRotinaService
    {
        private readonly IRotinaRepository _rotinaRepository;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        
        public RotinaService(IRotinaRepository rotinaRepository,
                             IRotinaEventHistoryRepository rotinaEventHistoryRepository)
        {
            _rotinaRepository = rotinaRepository;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
        }

        public async Task<Rotina> GetByIdAsync(Guid id)
        {
            try
            {
                return await _rotinaRepository.GetByIdAsync(id);
            }
            catch { throw new InvalidOperationException(); }
        }

        public void Dispose()
        {
            _rotinaRepository.Dispose();
        }
    }
}