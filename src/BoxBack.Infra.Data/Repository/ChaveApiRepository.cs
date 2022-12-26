using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;

namespace Sigesp.Infra.Data.Repository
{
    public class ChaveApiTerceiroRepository : Repository<ChaveApiTerceiro>, IChaveApiTerceiroRepository
    {
        public ChaveApiTerceiroRepository(BoxAppDbContext context)
            : base(context)
        {
        }
    }
}