using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Domain.Interfaces;

namespace BoxBack.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        public async Task SincronizarFromTPAsync()
        {
            await _clienteService.SincronizarFromTPAsync();
        }
    }
} 