using System.Data;
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

        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(Guid vendedorId, DateTime dataInicio, DateTime dataFim)
        {
            if ((dataInicio == DateTime.MinValue) || (dataFim == DateTime.MinValue))
            {
                return await DbSet
                            .Include(x => x.Vendedor)
                            .Include(x => x.ClienteContratoFatura)
                            .Include(x => x.ClienteContrato)
                            .ThenInclude(x => x.Cliente)
                            .Where(x => x.VendedorId.Equals(vendedorId)).ToListAsync();
            } else
            {
                return await DbSet
                            .Include(x => x.Vendedor)
                            .Include(x => x.ClienteContratoFatura)
                            .Include(x => x.ClienteContrato)
                            .ThenInclude(x => x.Cliente)
                            .Where(x => x.VendedorId.Equals(vendedorId) &&
                                   x.ClienteContratoFatura.DataCompetencia >= dataInicio &&
                                   x.ClienteContratoFatura.DataCompetencia <= dataFim).ToListAsync();
            }
        }
        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId)
        {
            return await DbSet
                            .Include(x => x.Vendedor)
                            .Include(x => x.ClienteContratoFatura)
                            .Include(x => x.ClienteContrato)
                            .ThenInclude(x => x.Cliente)
                            .Where(x => x.VendedorId.Equals(vendedorId)).ToListAsync();
        }
        public async Task<bool> AlreadyByFaturaIdAndVendedorId(Guid clienteContratoFaturaId, Guid vendedorId)
        {
            return await DbSet
                            .AnyAsync(x => x.ClienteContratoFaturaId.Equals(clienteContratoFaturaId) && 
                                           x.VendedorId.Equals(vendedorId));
        }

        public void DeletePermanentlyAsync(VendedorComissao vendedorComissao)
        {
            var vc = DbSet
                        .Where(x => x.Id.Equals(vendedorComissao.Id)).FirstOrDefault();
            
            DbSet.Remove(vc);
        }
    }
}