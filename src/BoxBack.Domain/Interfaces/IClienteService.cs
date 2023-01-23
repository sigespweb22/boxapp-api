using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteService
    {
        Task SincronizarFromTPAsync(string token, Guid rotinaEventHistoryId);
        Task<IEnumerable<Cliente>> GetAll();
    }
}