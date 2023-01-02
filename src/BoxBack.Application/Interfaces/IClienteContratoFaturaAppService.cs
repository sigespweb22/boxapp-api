using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteContratoFaturaAppService
    {
        Task SyncFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId);
    }
}