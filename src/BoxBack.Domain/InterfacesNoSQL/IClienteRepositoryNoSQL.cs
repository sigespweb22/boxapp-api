using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.ModelsNoSQL;

namespace BoxBack.Domain.InterfacesNoSQL
{
    public interface IClienteRepositoryNoSQL
    {
        Task<IEnumerable<ClienteNoSQL>> GetAll();
        Task AddAsync(ClienteNoSQL item);
        Task<bool> RemoveAsync(string id);
    }
}