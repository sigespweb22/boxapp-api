using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class RotinaAppService : IRotinaAppService
    {
        private ILogger<RotinaAppService> _logger;
        private readonly IRotinaService _rotinaService;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public RotinaAppService(IRotinaService rotinaService,
                                IMapper mapper,
                                ILogger<RotinaAppService> logger,
                                IClienteService clienteService)
        {
            _rotinaService = rotinaService;
            _mapper = mapper;
            _logger = logger;
            _clienteService = clienteService;
        }

        public async Task<RotinaViewModel> GetByIdAsync(Guid rotinaId)
        {
            try
            {
                return _mapper.Map<RotinaViewModel>(await _rotinaService.GetByIdAsync(rotinaId));    
            }
            catch { throw new ArgumentNullException(nameof(rotinaId)); }
        }
    }
} 