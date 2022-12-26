using Sigesp.Domain.Interfaces;
using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;

namespace Sigesp.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BoxAppDbContext context)
            : base(context)
        {
        }
    }
}