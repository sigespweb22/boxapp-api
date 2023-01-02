using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteContratoFaturaService
    {
        Task AddFromThirdPartyAsync(Guid rotinaEventHistoryId);
        Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId);
    }
}