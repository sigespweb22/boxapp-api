using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Date;

namespace BoxBack.Application.Interfaces
{
    public interface IVendedorComissaoAppService
    {
        Task<bool> AlterStatusAsync(Guid id);
        Task GerarComissoesByVendedorIdAsync(Guid rotinaEventHistoryId, Guid vendedorId);
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(string vendedorId, DataPeriodoViewModel dataPeriodo);
        Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAsync(string vendedorId);
        Task DeletePermanentlyAsync(Guid id);
    }
}