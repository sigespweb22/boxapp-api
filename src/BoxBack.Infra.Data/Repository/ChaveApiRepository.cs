using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class ChaveApiTerceiroRepository : Repository<ChaveApiTerceiro>, IChaveApiTerceiroRepository
    {
        public ChaveApiTerceiroRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public async Task<ChaveApiTerceiro> GetByApiTerceiroNome(ApiTerceiroEnum ate)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ApiTerceiro == ate);
        }
    }
}