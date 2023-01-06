using System;
using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IVendedorComissaoAppService
    {
        Task GerarComissoesAsync(Guid rotinaEventHistoryId);
    }
}