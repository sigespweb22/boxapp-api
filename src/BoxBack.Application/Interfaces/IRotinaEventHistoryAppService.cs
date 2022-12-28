using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.Interfaces
{
    public interface IRotinaEventHistoryAppService
    {
        Task AddAsync(RotinaEventHistoryViewModel reh);
        void Update(RotinaEventHistoryViewModel reh);
        Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id);
        void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId);
    }
}