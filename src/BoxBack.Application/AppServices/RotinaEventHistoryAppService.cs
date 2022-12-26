using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;

namespace BoxBack.Application.AppServices
{
    public class RotinaEventHistoryAppService : IRotinaEventHistoryAppService
    {
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IMapper _mapper;

        public RotinaEventHistoryAppService(IRotinaEventHistoryService rotinaEventHistoryService)
        {
            _rotinaEventHistoryService = rotinaEventHistoryService;
        }

        public async Task AddAsync(RotinaEventHistoryViewModel reh)
        {
            try
            {
                await _rotinaEventHistoryService.AddAsync(_mapper.Map<RotinaEventHistory>(reh));
            }
            catch { throw new ArgumentNullException(nameof(reh)); }
        }

        public void Update(RotinaEventHistoryViewModel reh)
        {
            try
            {
                _rotinaEventHistoryService.Update(_mapper.Map<RotinaEventHistory>(reh));
            }
            catch { throw new ArgumentNullException(nameof(reh)); }
        }
    }
} 