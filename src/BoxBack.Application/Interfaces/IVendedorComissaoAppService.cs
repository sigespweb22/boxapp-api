using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Date;

namespace BoxBack.Application.Interfaces
{
    public interface IVendedorComissaoAppService
    {
        // Task<IEnumerable<VendedorComissaoViewModel>> GetAllAsync();
        // Task<VendedorComissaoViewModel> GetByIdAsync();
        Task<bool> AlterStatusAsync(Guid id);
        Task GerarComissaoAsync(Guid rotinaEventHistoryId, string vendedorId);
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(string vendedorId, DataPeriodoViewModel dataPeriodo);
        Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAsync(string vendedorId);
        Task DeletePermanentlyAsync(Guid id);
    }
}