using System;
using System.Threading;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ILogger _logger;
        private readonly IClienteService _clienteService;
        private readonly IRotinaAppService _rotinaAppService;
        private readonly IRotinaEventHistoryAppService _rotinaEventHistoryAppService;
        private readonly IChaveApiTerceiroAppService _chaveApiTerceiroAppService;

        public ClienteAppService(ILogger<ClienteAppService> logger,
                                 IClienteService clienteService,
                                 IRotinaAppService rotinaService,
                                 IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                 IChaveApiTerceiroAppService chaveApiTerceiroAppService) 
        {
            _logger = logger;
            _clienteService = clienteService;
            _rotinaAppService = rotinaService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _chaveApiTerceiroAppService = chaveApiTerceiroAppService;
        }
        
        public async Task SincronizarFromTPAsync(CancellationTokenSource tokenSource)
        {
            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroAppService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (InvalidOperationException io)
            {
                RotinaEventHistoryUpdateHandle(io.Message, rotinaId);
            }
            catch (Exception ex)
            {
                RotinaEventHistoryUpdateHandle(ex.Message, rotinaId);
            }
            #endregion

            try
            {
                await _clienteService.SincronizarFromTPAsync(token).ConfigureAwait(false);
            }
            catch
            { 
                // implementation on exceptions
                throw; 
            }
        }

        private void RotinaEventHistoryUpdateHandle(string exceptionMessage, Guid rotinaId)
        {
            // obter o objeto do banco para atualizar

            var rotinaEventHistoryViewModel = new RotinaEventHistoryViewModel()
            {
                Id = Guid.NewGuid(),
                DataInicio =  DateTimeOffset.Now.ToString(),
                StatusProgresso = RotinaStatusProgressoEnum.EM_EXECUCAO.ToString(),
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