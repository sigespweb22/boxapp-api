using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteContratoFaturaAppService
    {
        Task SyncQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task SyncNaoQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId);
    }
}