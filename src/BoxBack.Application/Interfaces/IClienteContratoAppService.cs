using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteContratoAppService
    {
        Task SyncFromTPAsync(Guid rotinaEventHistoryId);
        Task UpdateFromTPAsync(Guid rotinaEventHistoryId);
    }
}