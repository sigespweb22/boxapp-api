using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteService
    {
        Task SincronizarFromTPAsync(string token, Guid rotinaEventHistoryId);
        Task SyncAsync(string token, Guid rotinaEventHistoryId, IServiceScope scope);
        Task<IEnumerable<Cliente>> GetAll();
    }
}