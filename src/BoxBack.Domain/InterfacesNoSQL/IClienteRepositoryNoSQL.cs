using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsNoSQL;

namespace BoxBack.Domain.InterfacesNoSQL
{
    public interface IClienteRepositoryNoSQL
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task AddAsync(Cliente item);
        Task<bool> RemoveAsync(string id);
    }
}