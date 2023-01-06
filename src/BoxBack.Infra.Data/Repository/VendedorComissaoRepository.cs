using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class VendedorComissaoRepository : Repository<VendedorComissao>, IVendedorComissaoRepository
    {
        public VendedorComissaoRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId)
        {
            return await DbSet.Where(x => x.VendedorId.Equals(vendedorId)).ToListAsync();
        }
    }
}