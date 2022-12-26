using System.Text;
using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;

namespace BoxBack.Application.Interfaces
{
    public interface IChaveApiTerceiroAppService
    {
        Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate);
    }
}