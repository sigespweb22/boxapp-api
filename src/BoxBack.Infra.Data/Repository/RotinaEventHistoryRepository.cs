using System.Data.Common;
using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class RotinaEventHistoryRepository : Repository<RotinaEventHistory>, IRotinaEventHistoryRepository
    {
        public RotinaEventHistoryRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public async Task<RotinaEventHistory> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet.Include(x => x.Rotina).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}