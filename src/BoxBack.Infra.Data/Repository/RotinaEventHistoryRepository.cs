using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Sigesp.Infra.Data.Repository
{
    public class RotinaEventHistoryRepository : Repository<RotinaEventHistory>, IRotinaEventHistoryRepository
    {
        private ILogger<RotinaEventHistoryRepository> _logger;

        public RotinaEventHistoryRepository(BoxAppDbContext context,
                                            ILogger<RotinaEventHistoryRepository> logger)
            : base(context)
        {
            _logger = logger;
        }

        public async Task<RotinaEventHistory> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet.Include(x => x.Rotina).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}