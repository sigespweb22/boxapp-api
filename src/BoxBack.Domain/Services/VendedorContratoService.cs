using BoxBack.Domain.Interfaces;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sigesp.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class VendedorContratoService : IVendedorContratoService
    {
        private readonly ILogger _logger;
        private readonly IVendedorContratoRepository _vendedorContratoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public VendedorContratoService(ILogger<VendedorContratoService> logger,
                                       IVendedorContratoRepository vendedorContratoRepository,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _vendedorContratoRepository = vendedorContratoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _vendedorContratoRepository.Dispose();
        }
    }
}