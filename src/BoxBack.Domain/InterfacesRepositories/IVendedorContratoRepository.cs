using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;

namespace Sigesp.Domain.InterfacesRepositories
{
    public interface IVendedorContratoRepository : IRepository<VendedorContrato>
    {
        Task<VendedorContrato[]> GetAllAtivosWithIncludesByVendedorIdAsync(Guid vendedorId);
    }
}