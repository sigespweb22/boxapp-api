using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IRotinaAppService _rotinaAppService;
        private readonly IRotinaEventHistoryAppService _rotinaEventHistoryAppService;
        private readonly IChaveApiTerceiroAppService _chaveApiTerceiroAppService;        

        public ClienteAppService(IClienteService clienteService,
                                 IRotinaAppService rotinaService,
                                 IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                 IChaveApiTerceiroAppService chaveApiTerceiroAppService) 
        {
            _clienteService = clienteService;
            _rotinaAppService = rotinaService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _chaveApiTerceiroAppService = chaveApiTerceiroAppService;
        }
        
        public async Task SincronizarFromTPAsync(Guid rotinaId)
        {
            #region Create rotina event history
            var rotinaViewModel = new RotinaViewModel();
            try
            {
                rotinaViewModel = await _rotinaAppService.GetByIdAsync(rotinaId);
            }
            catch { throw; }

            if (rotinaViewModel == null) throw new ArgumentNullException(nameof(rotinaViewModel));

            // create object to store rotina
            var rotinaEventHistoryViewModel = new RotinaEventHistoryViewModel()
            {
                Id = Guid.NewGuid(),
                DataInicio =  DateTimeOffset.Now.ToString(),
                StatusProgresso = RotinaStatusProgressoEnum.EM_EXECUCAO.ToString(),
                TotalItensSucesso = 0,
                TotalItensInsucesso = 0,
                RotinaId = rotinaViewModel.Id
            };

            try
            {
                await _rotinaEventHistoryAppService.AddAsync(rotinaEventHistoryViewModel);    
            }
            catch { throw; }
            #endregion

            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroAppService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (ArgumentNullException ane) {

                #region Event exception register
                rotinaEventHistoryViewModel.StatusProgresso = RotinaStatusProgressoEnum.FALHA_EXECUCAO.ToString();
                rotinaEventHistoryViewModel.DataFim = DateTimeOffset.Now.ToString();
                rotinaEventHistoryViewModel.ExceptionMensagem = $"Nenhuma chave de api encontrada para seguir com o processo de integração. | ArgumentNullException => {ane.Message}";

                _rotinaEventHistoryAppService.Update(rotinaEventHistoryViewModel);
                await Task.FromCanceled(CancellationToken.None);
                #endregion
            }
            #endregion

            try
            {
                await _clienteService.SincronizarFromTPAsync(token);    
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            
        }
    }
} 