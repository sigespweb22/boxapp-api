using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.AppServices
{
    public interface VendedorComissaoAppService
    {
        Task GerarComissoesAsync(Guid rotinaEventHistoryId, DateTimePeriodoRequestModel periodoCompetencia);
    }
}