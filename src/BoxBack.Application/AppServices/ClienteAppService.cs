using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels.Navigation;
using BoxBack.Infra.Data.Context;

namespace BoxBack.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ClienteService _clienteService;

        public ClienteAppService(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        public async Task SincronizarFromTPAsync()
        {
            await _clienteService.SincronizarFromTPAsync();
        }
    }
}