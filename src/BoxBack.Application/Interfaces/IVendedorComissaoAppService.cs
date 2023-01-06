using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.Interfaces
{
    public interface IVendedorComissaoAppService
    {
        // Task<IEnumerable<VendedorComissaoViewModel>> GetAllAsync();
        // Task<VendedorComissaoViewModel> GetByIdAsync();
        Task<bool> AlterStatusAsync(Guid id);
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAsync(string vendedorId);
    }
}