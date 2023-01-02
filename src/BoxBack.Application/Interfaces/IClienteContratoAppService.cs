using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteContratoAppService
    {
        Task SyncUpdateFromTPAsync(Guid rotinaEventHistoryId);
    }
}