using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;

namespace Sigesp.Infra.Data.Repository
{
    public class VendedorComissaoRepository : Repository<VendedorComissao>, IVendedorComissaoRepository
    {
        public VendedorComissaoRepository(BoxAppDbContext context)
            : base(context)
        {
        }
    }
}