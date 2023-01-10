using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;

namespace Sigesp.Domain.InterfacesRepositories
{
    public interface IVendedorComissaoRepository : IRepository<VendedorComissao>
    {
        Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId);
        Task<bool> AlreadyByFaturaIdAndVendedorId(Guid clienteContratoFaturaId, Guid vendedorId);
    }
}