using System.Text;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;

namespace Sigesp.Domain.InterfacesRepositories
{
    public interface IChaveApiTerceiroRepository : IRepository<ChaveApiTerceiro>
    {
        Task<ChaveApiTerceiro> GetByApiTerceiroNome(ApiTerceiroEnum ate);
    }
}