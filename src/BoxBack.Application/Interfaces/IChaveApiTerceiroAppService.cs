using System.Threading.Tasks;
using BoxBack.Domain.Enums;

namespace BoxBack.Application.Interfaces
{
    public interface IChaveApiTerceiroAppService
    {
        Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate);
    }
}