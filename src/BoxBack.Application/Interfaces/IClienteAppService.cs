using System.Threading.Tasks;

namespace BoxBack.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task SincronizarFromTPAsync();
    }
}