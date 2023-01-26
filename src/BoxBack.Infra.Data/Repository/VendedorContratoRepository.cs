using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Sigesp.Infra.Data.Repository
{
    public class VendedorContratoRepository : Repository<VendedorContrato>, IVendedorContratoRepository
    {
        public VendedorContratoRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public async Task<VendedorContrato[]> GetAllAtivosWithIncludesByVendedorIdAsync(Guid vendedorId)
        {
            return await DbSet
                            .Include(x => x.ClienteContrato)
                            .ThenInclude(x => x.ClientesContratosFaturas)
                            .Where(x => x.IsDeleted.Equals(false) &&
                                   x.VendedorId.Equals(vendedorId) &&
                                   x.ClienteContrato.ClientesContratosFaturas.Any())
                            .ToArrayAsync();
        }
    }
}