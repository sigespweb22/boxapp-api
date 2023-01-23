using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Domain.Hubs;
using BoxBack.Domain.HubsInterfaces;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class RotinaEventHistoryAppService : IRotinaEventHistoryAppService
    {
        private ILogger _logger;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificacaoHub, INotificacaoHub> _notificacaoHub;

        public RotinaEventHistoryAppService(ILogger<RotinaEventHistoryAppService> logger,
                                            IRotinaEventHistoryService rotinaEventHistoryService,
                                            IMapper mapper,
                                            IHubContext<NotificacaoHub, INotificacaoHub> notificacaoHub)
        {
            _logger = logger;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _mapper = mapper;
            _notificacaoHub = notificacaoHub;
        }

        public async Task AddAsync(RotinaEventHistoryViewModel reh)
        {
            try
            {
                await _rotinaEventHistoryService.AddAsync(_mapper.Map<RotinaEventHistory>(reh));
            }
            catch { throw new ArgumentNullException(nameof(reh)); }
        }
        public async Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id)
        {
            await _rotinaEventHistoryService.AddWithStatusEmExecucaoHandleAsync(rotinaId, id);
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
        public void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId)
        {
            _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(exceptionMessage, rotinaEventoHistoryId);
        }
    }
} 