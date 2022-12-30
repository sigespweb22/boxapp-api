using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Hubs;
using BoxBack.Application.HubsInterfaces;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;
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
        public async Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id)
        {
            if (rotinaId == Guid.Empty) throw new ArgumentNullException(nameof(rotinaId));
            
            // create object to store rotina
            var rotinaEventHistory = new RotinaEventHistory()
            {
                Id = id,
                DataInicio =  DateTimeOffset.Now,
                StatusProgresso = RotinaStatusProgressoEnum.EM_EXECUCAO,
                TotalItensSucesso = 0,
                TotalItensInsucesso = 0,
                RotinaId = rotinaId
            };

            try
            {
                await _rotinaEventHistoryService.AddAsync(rotinaEventHistory);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de adicionar rotina event history | {ex.Message}");
                throw new OperationCanceledException(ex.Message);
            }

            await _notificacaoHub.Clients.All.ReceiveMessage("Deuuuuu certo");
        }
        public void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId)
        {
            #region Get data
            var rotinaEventHistoryDB = new RotinaEventHistory();
            try
            {
                rotinaEventHistoryDB = _rotinaEventHistoryService.GetById(rotinaEventoHistoryId);
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Falhou tentativa de obter o registro de rotina event history para sua atualização. | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            #region Map to update
            rotinaEventHistoryDB.Id = rotinaEventoHistoryId;
            rotinaEventHistoryDB.DataFim = DateTimeOffset.Now;
            rotinaEventHistoryDB.StatusProgresso = RotinaStatusProgressoEnum.FALHA_EXECUCAO;
            rotinaEventHistoryDB.ExceptionMensagem = $"{exceptionMessage}";
            #endregion

            try
            {
                _rotinaEventHistoryService.Update(rotinaEventHistoryDB);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {an.Message}");
                throw new OperationCanceledException(an.Message);
            }
            catch (InvalidOperationException io) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar a rotina event history | {ex.Message}");
                throw new OperationCanceledException(ex.Message);
            }
        }
    }
} 