using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IVendedorComissaoService
    {
        Task GerarComissoesByVendedorIdAsync(Guid rotinaEventHistoryId, Guid vendedorId);
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<bool> AlterStatusAsync(Guid id);
        Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(Guid vendedorId, DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId);
        Task DeletePermanentlyAsync(Guid id);
    }
}