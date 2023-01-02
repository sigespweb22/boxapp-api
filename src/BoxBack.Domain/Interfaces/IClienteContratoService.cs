using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteContratoService
    {
        Task SyncUpdateFromTPAsync(string token, Guid rotinaEventHistoryId);
        Task AddFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId);
    }
}