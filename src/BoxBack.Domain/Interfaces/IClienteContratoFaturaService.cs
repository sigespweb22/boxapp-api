using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteContratoFaturaService
    {
        Task AddQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task AddNaoQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId);
    }
}