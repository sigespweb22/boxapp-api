using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;

namespace Sigesp.Infra.Data.Repository
{
    public class RotinaRepository : Repository<Rotina>, IRotinaRepository
    {
        public RotinaRepository(BoxAppDbContext context)
            : base(context)
        {
        }
    }
}