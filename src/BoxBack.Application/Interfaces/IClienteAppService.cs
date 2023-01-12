using System.Threading;
using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task SincronizarFromTPAsync(CancellationTokenSource tokenSource, Guid rotinaEventHistoryId);
    }
}