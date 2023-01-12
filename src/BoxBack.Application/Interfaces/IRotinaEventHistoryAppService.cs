using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.Interfaces
{
    public interface IRotinaEventHistoryAppService
    {
        Task AddAsync(RotinaEventHistoryViewModel reh);
        Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id);
        void Update(RotinaEventHistoryViewModel reh);
        void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId);        
    }
}