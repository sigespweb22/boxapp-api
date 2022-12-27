using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;

namespace BoxBack.Application.AppServices
{
    public class RotinaAppService : IRotinaAppService
    {
        private readonly IRotinaService _rotinaService;
        private readonly IMapper _mapper;

        public RotinaAppService(IRotinaService rotinaService,
                                IMapper mapper)
        {
            _rotinaService = rotinaService;
            _mapper = mapper;
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