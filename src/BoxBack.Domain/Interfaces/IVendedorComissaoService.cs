using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IVendedorComissaoService
    {
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<bool> AlterStatusAsync(Guid id);
        Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId);
    }
}