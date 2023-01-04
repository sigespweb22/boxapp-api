using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sigesp.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class VendedorComissaoService : IVendedorComissaoService
    {
        private readonly ILogger _logger;
        private readonly IVendedorComissaoRepository _vendedorComissaoRepository;
        private readonly IVendedorContratoService _vendedorContratoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public VendedorComissaoService(ILogger<VendedorComissaoService> logger,
                                       IVendedorComissaoRepository vendedorComissaoRepository,
                                       IVendedorContratoService vendedorContratoService,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _vendedorComissaoRepository = vendedorComissaoRepository;
            _vendedorContratoService = vendedorContratoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    
        public async Task GerarComissoesAsync(Guid rotinaEventHistoryId, DateTime dataInicio, DateTime dataFim)
        {
            await Task.Delay(500);
            // #region Get contratos
            // ClienteContrato[] clientesContratos;
            // try
            // {
            //     clientesContratos = _clienteContratoRepository.GetAll().ToArray();
            // }
            // catch (InvalidOperationException io)
            // {
            //     _logger.LogInformation($"Falhou tentativa de obter os contratos para seguir com a sincronização das faturas. | {io.Message}");
            //     _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
            //     throw new OperationCanceledException(io.Message);
            // }

            // if (clientesContratos == null || clientesContratos.Count() <= 0)
            // {
            //     _logger.LogInformation($"Nenhum contrato de cliente encontrado para iniciar a sincronização. | {clientesContratos.Count()}");
            //     _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum contrato de cliente encontrado para iniciar a sincronização", rotinaEventHistoryId);
            //     throw new ArgumentNullException("Nenhum contrato de cliente encontrato para iniciar a sincronização com api de terceiro.");
            // }
            // #endregion

            // #region Chave api resolve - Token
            // String token = string.Empty;
            // try
            // {
            //     token = $"ApiKey {await _chaveApiTerceiroService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            // }
            // catch (InvalidOperationException io)
            // {
            //     _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
            //     _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
            //     throw new OperationCanceledException(io.Message);
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
            //     _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
            //     throw new OperationCanceledException(ex.Message);
            // }
            // #endregion

            // #region Get data Bom Controle (Third Party) and map and persistance faturas
            // BCContratoModelService clientesContratosThirdParty = new BCContratoModelService();
            // Int64 totalSincronizado = 0;
            // for (var a = 0; a < clientesContratos.Count(); a++)
            // {
            //     if (clientesContratos[a].BomControleContratoId == 0) continue;
                
            //     try
            //     {
            //         clientesContratosThirdParty = await _bcServices.VendaContratoObter(clientesContratos[a].BomControleContratoId, true, token);
            //     }
            //     catch (Exception e) when (e is FormatException or OverflowException) {
            //         _logger.LogInformation($"Falhou tentativa de obter os contratos a partir da api de terceiro. | {e.Message}");
            //         _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId); 
            //         throw new Exception(e.Message, e.InnerException);
            //     }

            //     if (clientesContratosThirdParty == null) continue;
            //     if (clientesContratosThirdParty.Faturas == null || clientesContratosThirdParty.Faturas.Count() == 0) continue;

            //     BCFaturaModelService[] clientesContratosFaturasThirdParty = clientesContratosThirdParty.Faturas.ToArray();

            //     for (var b = 0; b < clientesContratosFaturasThirdParty.Length; b++)
            //     {
            //         var clienteContratoFatura = new ClienteContratoFatura();
            //         try
            //         {
            //             clienteContratoFatura.Id = Guid.NewGuid();
            //             clienteContratoFatura = _mapper.Map<ClienteContratoFatura>(clientesContratosFaturasThirdParty[b]);
            //             clienteContratoFatura.ClienteContratoId = clientesContratos[a].Id;
            //         }
            //         catch (InvalidCastException ic) { 
            //             _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ic.Message}");
            //             _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do cliente para sincronização", rotinaEventHistoryId);
            //             throw new InvalidOperationException(ic.Message); 
            //         }
            //         catch (InvalidOperationException io) { 
            //             _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {io.Message}");
            //             _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
            //             throw new InvalidOperationException(io.Message); 
            //         }
            //         catch (Exception ex) { 
            //             _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ex.Message}");
            //             _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização.", rotinaEventHistoryId);
            //             throw new InvalidOperationException(ex.Message); 
            //         }

            //         // check to double
            //         if (AlreadyClienteContratoFaturaAsync(clienteContratoFatura)) continue;

            //         try
            //         {
            //             await _clienteContratoFaturaRepository.AddAsync(clienteContratoFatura);
            //             totalSincronizado++;
            //         }
            //         catch (InvalidOperationException io) { 
            //             _logger.LogInformation($"Problemas ao adicionar fatura de contrato de cliente. | {io.Message}");
            //             _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao adicionar fatura de contrato cliente", rotinaEventHistoryId);
            //             throw new InvalidOperationException(io.Message);
            //         }
            //     }
            // }
            // #endregion

            // #region Commit
            // try
            // {
            //     _unitOfWork.Commit();    
            // }
            // catch (InvalidOperationException io) {
            //     _logger.LogInformation($"Problemas ao efetuar commit. | {io.Message}");
            //     _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
            //     throw new InvalidOperationException(io.Message); 
            // }
            // #endregion

            // #region Create rotina event history of success
            // try
            // {
            //     _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalSincronizado, 0);
            // }
            // catch (InvalidOperationException io)
            // {
            //     _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {io.Message}");
            //     throw new InvalidOperationException(io.Message, io.InnerException);
            // }
            // catch (ArgumentNullException an) 
            // {
            //     _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {an.Message}");
            //     throw new InvalidOperationException(an.Message, an.InnerException);
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {ex.Message}");
            //     throw new InvalidOperationException(ex.Message, ex.InnerException);
            // }
            // #endregion
        }

        public void Dispose()
        {
            _vendedorComissaoRepository.Dispose();
        }
    }
}