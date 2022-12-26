using System.Text;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Interfaces
{
    public interface IChaveApiTerceiroService
    {
        Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate);
    }
}