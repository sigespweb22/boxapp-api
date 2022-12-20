using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.Interfaces;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;
using BoxBack.Domain.Enums;
using BoxBack.Application.ViewModels;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes-contratos-faturas")]
    public class ClienteContratoFaturaEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBCServices _bcServices;

        public ClienteContratoFaturaEndpoint(BoxAppDbContext context,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IBCServices bcServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bcServices = bcServices;
        }

        #region Third party API
        /// <summary>
        /// Sincroniza a base de fatura de contratos de clientes do BOM CONTROLE 
        /// com a base de faturas de contratos de clientes do BoxApp (Este método não atualiza os dados de contrato, apenas mantém os mesmos contratos em ambos os sistemas)
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de faturas de contratos de clientes sincronizados</returns>
        /// <response code="200">Objeto com o total de faturas de conatratos de clientes sincronizados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoFaturaCreate, CanClienteContratofaturaAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("sincronizar-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> SincronizarFromThirdPartyAsync()
        {
            #region Get clientes
            Cliente[] clientes;
            try
            {
                clientes = await _context.Clientes.ToArrayAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientes == null || clientes.Count() <= 0)
            {
                AddError("Nenhum cliente encontrado na base de dados, para então seguir com a sincronização dos contratos com o sistema de terceiro.");
                return CustomResponse(500);
            }
            #endregion

            #region Chave api resolve
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _context
                                                .ChavesApiTerceiro
                                                .Where(x => x.DataValidade >= DateTimeOffset.Now &&
                                                       x.IsDeleted == false && !string.IsNullOrEmpty(x.Key))
                                                .FirstOrDefaultAsync(x => x.ApiTerceiro.Equals(ApiTerceiroEnum.BOM_CONTROLE));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (chaveApiTerceiro == null)
            { 
                AddError("Nenhuma chave de api de terceiro encontrada, verifique os possíveis erros: \n\nNenhuma chave de api cadastrada para esta integração. \n\nA chave de api cadastrada não possui uma Key. \n\nA chave de api cadastrada não está ativa. \n\nA chave de api cadastrada está com Data de Validade vencida.");
                return CustomResponse(404);
            }
            #endregion

            #region Token resolve
            String token = string.Empty;
            try
            {
                token = $"ApiKey {chaveApiTerceiro.Key}";
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get contratos
            IEnumerable<ClienteContrato> contratos = new List<ClienteContrato>();
            try
            {
                contratos = await _context.ClientesContratos.ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get data Bom Controle (Third Party)
            BCContratoModelService[] clienteContratosThirdParty;
            Int64 totalSincronizado = 0;
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                for (var a = 0; a < clientes.Count(); a++)
                {
                    switch (clientes[a].TipoPessoa) {
                        case TipoPessoaEnum.FISICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(clientes[a].Cpf, token);
                            break;
                        case TipoPessoaEnum.JURIDICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(clientes[a].CNPJ, token);
                            break;
                        default:
                            clienteContratosThirdParty = null;
                            break;
                    }

                    if (clienteContratosThirdParty == null) continue;

                    for (var b = 0; b < clienteContratosThirdParty.Count(); b++)
                    {
                        // Verifico se o contrato obtido da api de terceiro já não existe na minha base
                        if (!contratos.Any(x => x.BomControleContratoId.Equals(clienteContratosThirdParty[b].Id)))
                        {
                            // contrato não existe, portanto, posso sincronizá-lo para minha base
                            var contratoMapped = new ClienteContrato();
                            try
                            {
                                var clienteContratoThirdPartyId = clienteContratosThirdParty[b].Id;
                                clienteContratosThirdParty[b].Id = null;

                                contratoMapped = _mapper.Map<ClienteContrato>(clienteContratosThirdParty[b]);
                                
                                contratoMapped.BomControleContratoId = clienteContratoThirdPartyId;
                                contratoMapped.ClienteId = clientes[a].Id;
                                
                                clientesContratos.Add(contratoMapped);
                                totalSincronizado++;
                            }
                            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                        }
                    }
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance
            try
            {
                _context.ClientesContratos.AddRange(clientesContratos);    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Return
            return CustomResponse(200, new {
                TotalSincronizado = totalSincronizado,
            });
            #endregion
        }
        #endregion
    }
}