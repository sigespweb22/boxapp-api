using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IVendedorComissaoService
    {
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
        Task<bool> AlterStatusAsync(Guid id);
    }
}