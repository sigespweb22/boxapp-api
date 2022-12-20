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
        /// Sincroniza a base de FATURAS de CONTRATOS de clientes do BOM CONTROLE 
        /// com a base de FATURAS de CONTRATOS de clientes do BoxApp (Este método não atualiza os dados de contrato,
        /// apenas mantém os mesmos contratos em ambos os sistemas)
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de FATURAS de CONTRATOS de clientes sincronizadas</returns>
        /// <response code="200">Objeto com o total de FATURAS de CONTRATOS de clientes sincronizados</response>
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
            #region Get contratos
            ClienteContrato[] clientesContratos;
            try
            {
                clientesContratos = await _context.ClientesContratos.ToArrayAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                AddError("Nenhum contrato encontrado na base de dados, para então seguir com a sincronização das faturas de contratos com o sistema de terceiro.");
                return CustomResponse(404);
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

            #region Get data Bom Controle (Third Party) and map and persistance faturas
            BCContratoModelService clientesContratosThirdParty = new BCContratoModelService();
            Int64 totalSincronizado = 0;
            for (var a = 0; a < clientesContratos.Count(); a++)
            {
                if (clientesContratos[a].BomControleContratoId == 0) continue;
                
                try
                {
                    clientesContratosThirdParty = await _bcServices.VendaContratoObter(clientesContratos[a].BomControleContratoId, token);
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                if (clientesContratosThirdParty == null) continue;
                if (clientesContratosThirdParty.Faturas == null || clientesContratosThirdParty.Faturas.Count() == 0) continue;

                BCFaturaModelService[] clientesContratosFaturasThirdParty = clientesContratosThirdParty.Faturas.ToArray();

                for (var b = 0; b < clientesContratosFaturasThirdParty.Length; b++)
                {
                    var clienteContratoFatura = new ClienteContratoFatura();
                    try
                    {
                        clienteContratoFatura = _mapper.Map<ClienteContratoFatura>(clientesContratosFaturasThirdParty[b]);
                        clienteContratoFatura.ClienteContratoId = clientesContratos[a].Id;
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                    // check to double
                    if (AlreadyClienteContratoFaturaAsync(clienteContratoFatura)) continue;

                    try
                    {
                        _context.ClientesContratosFaturas.Add(clienteContratoFatura);
                        totalSincronizado++;
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                }
            }
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

        /// <summary>
        /// Atualiza as FATURAS de CONTRATOS de clientes do BOXAPP
        /// com os dados das FATURAS de CONTRATOS de clientes do BoxApp
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de FATURAS de CONTRATOS de clientes sincronizadas</returns>
        /// <response code="200">Objeto com o total de faturas atualizadas com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhuma fatura encontrada</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoFaturaUpdate, CanClienteContratofaturaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> UpdateFromThirdPartyAsync()
        {
            #region Get faturas
            ClienteContratoFatura[] clientesContratosFaturas;
            try
            {
                clientesContratosFaturas = await _context.ClientesContratosFaturas.ToArrayAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientesContratosFaturas == null || clientesContratosFaturas.Length <= 0)
            {
                AddError("Nenhuma fatura encontrada na base de dados, para então seguir com a atualização dos dados de fatura.");
                return CustomResponse(404);
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

            #region Get data Bom Controle (Third Party) to map and update faturas
            BCFaturaModelService faturaThirdParty = new BCFaturaModelService();
            Int64 totalFaturasAtualizadas = 0;
            for (var a = 0; a < clientesContratosFaturas.Count(); a++)
            {
                if (clientesContratosFaturas[a].BomControleContratoId == 0) continue;
                
                try
                {
                    faturaThirdParty = await _bcServices.FaturaObter(clientesContratosFaturas[a].BomControleContratoId, token);
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                if (faturaThirdParty == null) continue;

                var clienteContratoFaturaMap = new ClienteContratoFatura();
                try
                {
                    clienteContratoFaturaMap = _mapper.Map<ClienteContratoFatura>(faturaThirdParty);
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                try
                {
                    _context.ClientesContratosFaturas.Update(clienteContratoFaturaMap);
                    totalFaturasAtualizadas++;
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            }
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
                TotalFaturasAtualizadas = totalFaturasAtualizadas,
            });
            #endregion
        }
        #endregion

        #region Private methods
        private bool AlreadyClienteContratoFaturaAsync(ClienteContratoFatura clienteContratoFatura)
        {
            #region General validations
            if (clienteContratoFatura.ClienteContratoId == null) throw new ArgumentException("Id contrato requerido.");
            if (clienteContratoFatura.DataCompetencia == null) throw new ArgumentException("Data compentência requerida.");
            if (clienteContratoFatura.Valor == 0) throw new ArgumentException("Valor requerido.");
            if (clienteContratoFatura.NumeroParcela == 0) throw new ArgumentException("Número parcela requerido.");
            #endregion

            #region Check to already
            // check to same clienteContratoId, dataCompentencia, valor e numeroParcela
            bool already;
            try
            {
                already = _context.ClientesContratosFaturas.Any(x => x.ClienteContratoId.Equals(clienteContratoFatura.ClienteContratoId) &&
                                                                x.DataCompetencia.Equals(clienteContratoFatura.DataCompetencia) &&
                                                                x.Valor.Equals(clienteContratoFatura.Valor) &&
                                                                x.NumeroParcela.Equals(clienteContratoFatura.NumeroParcela));
            }
            catch { throw; }
            #endregion

            return already;
        }
        #endregion
    }
}