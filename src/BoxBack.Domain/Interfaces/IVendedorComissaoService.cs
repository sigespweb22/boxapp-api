using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IVendedorComissaoService
    {
        Task GerarComissoesAsync(Guid rotinaEventHistoryId, DateTime dataInicio, DateTime dataFim);
    }
}