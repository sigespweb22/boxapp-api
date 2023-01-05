using System;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IRotinaEventHistoryService
    {
        RotinaEventHistory GetById(Guid id);
        Task<RotinaEventHistory> GetByIdAsync(Guid id);
        Task AddAsync(RotinaEventHistory reh);
        Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id);
        void Update(RotinaEventHistory reh);
        void UpdateWithStatusConcluidaHandle(Guid id, Int64 totalSuccess, Int64 totalFailures);
        void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId);
        Task<RotinaEventHistory> GetByIdWithIncludeAsync(Guid rotinaEventHistoryId);
    }
}