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

        public RotinaEventHistoryAppService(IRotinaEventHistoryService rotinaEventHistoryService,
                                            IMapper mapper)
        {
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _mapper = mapper;
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
            #region Get data to map and after update
            var rotinaEventHistoryDB = new RotinaEventHistory();
            try
            {
                rotinaEventHistoryDB = _rotinaEventHistoryService.GetById(reh.Id);
            }
            catch (InvalidCastException ic) { throw new InvalidCastException(ic.Message); }
            #endregion

            #region Map
            try
            {
                _mapper.Map<RotinaEventHistoryViewModel, RotinaEventHistory>(reh, rotinaEventHistoryDB);
            }
            catch (InvalidCastException ic) { throw new InvalidCastException(ic.Message); }
            
            #endregion

            try
            {
                _rotinaEventHistoryService.Update(rotinaEventHistoryDB);
            }
            catch { throw new ArgumentNullException(nameof(reh)); }
        }
    }
} 