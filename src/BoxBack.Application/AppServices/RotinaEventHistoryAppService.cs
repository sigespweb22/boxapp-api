using System;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class RotinaEventHistoryAppService : IRotinaEventHistoryAppService
    {
        private ILogger _logger;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IMapper _mapper;

        public RotinaEventHistoryAppService(ILogger<RotinaEventHistoryAppService> logger,
                                            IRotinaEventHistoryService rotinaEventHistoryService,
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
        public async Task AddWithStatusEmExecucaoHandleAsync(Guid rotinaId, Guid id)
        {
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
        }
        private void UpdateWithStatusFalhaExecucaoHandle(string exceptionMessage, Guid rotinaEventoHistoryId)
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



            // obter o objeto do banco para atualizar
            var rotinaEventHistoryViewModel = new RotinaEventHistoryViewModel()
            {
                Id = Guid.NewGuid(),
                DataInicio =  DateTimeOffset.Now.ToString(),
                StatusProgresso = RotinaStatusProgressoEnum.FALHA_EXECUCAO.ToString(),
                TotalItensSucesso = 0,
                TotalItensInsucesso = 0,
                RotinaId = rotinaId
            };

            rotinaEventHistoryViewModel.ExceptionMensagem = $"{exceptionMessage}";
            rotinaEventHistoryViewModel.StatusProgresso = RotinaStatusProgressoEnum.FALHA_EXECUCAO.ToString();
            rotinaEventHistoryViewModel.DataFim = DateTimeOffset.Now.ToString();

            try
            {
                _rotinaEventHistoryAppService.Update(rotinaEventHistoryViewModel);
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