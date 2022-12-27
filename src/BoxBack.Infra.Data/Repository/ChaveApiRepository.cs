using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;

namespace Sigesp.Infra.Data.Repository
{
    public class ChaveApiTerceiroRepository : Repository<ChaveApiTerceiro>, IChaveApiTerceiroRepository
    {
        public ChaveApiTerceiroRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public Task<ChaveApiTerceiro> GetByApiTerceiroNome(ApiTerceiroEnum ate)
        {
            var chaveApiTerceiro = new ChaveApiTerceiro();
            return Task.Run(() => chaveApiTerceiro);
        }
    }
}