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

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes-contratos")]
    public class ClienteContratoEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBCServices _bcServices;

        public ClienteContratoEndpoint(BoxAppDbContext context,
                                       IUnitOfWork unitOfWork,
                                       IMapper mapper,
                                       IBCServices bcServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bcServices = bcServices;
        }

        /// <summary>
        /// Sincroniza a base de contratos de clientes do BOM CONTROLE com a base de contratos de clientes do BoxApp (Este método não atualiza os dados de contrato, apenas mantém os mesmos contratos em ambos os sistemas)
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de contratos de clientes sincronizados</returns>
        /// <response code="200">Objeto com o total de clientes sincronizados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoCreate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("sincronizar-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> SincronizarFromThirdPartyPAsync()
        {
            #region Get clientes
            IEnumerable<Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = await _context.Clientes.ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientes == null || clientes.Count() <= 0)
            {
                AddError("Nenhum cliente encontrado na base de dados, para então seguir com a sincronização dos contratos com o sistema de terceiro.");
                return CustomResponse(500);
            }
            #endregion

            // TODO: Implementar busca do token diretamente da tabela chave api terceiro
            #region Token resolve
            var token = "ApiKey Z0EjZPzTOb_AOeUDlulXwdnhg9JMHSUQbKek2rFejjXyG9pyoA2hMY35uD1B6bzjynsbTrCaUm347KMoDwiTPkaCND-m5EQwHaUUcTkvYNyhbXzYG7zLggKd7MwMR1qwsW16kQFhc94.";
            #endregion

            #region Get contratos
            IEnumerable<ClienteContrato> contratos = new List<ClienteContrato>();
            try
            {
                contratos = await _context.ClienteContratos.ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get data Bom Controle (Third Party)
            IEnumerable<BCContratoModelService> clienteContratosThirdParty = new List<BCContratoModelService>();
            Int64 totalSincronizado = 0;
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                foreach (var cliente in clientes)
                {
                    switch (cliente.TipoPessoa) {
                        case TipoPessoaEnum.FISICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(cliente.Cpf, token);
                            break;
                        case TipoPessoaEnum.JURIDICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(cliente.CNPJ, token);
                            break;
                        default:
                            clienteContratosThirdParty = null;
                            break;
                    }

                    if (clienteContratosThirdParty == null) continue;

                    foreach (var clienteContratoThirdParty in clienteContratosThirdParty)
                    {
                        // Verifico se o contrato obtido da api de terceiro já não existe na minha base
                        if (!contratos.Any(x => x.BomControleContratoId.Equals(clienteContratoThirdParty.Id)))
                        {
                            // contrato não existe, portanto, posso sincronizá-lo para minha base
                            var contratoMapped = new ClienteContrato();
                            try
                            {
                                
                                var clienteContratoThirdPartyId = clienteContratoThirdParty.Id;
                                clienteContratoThirdParty.Id = null;

                                contratoMapped = _mapper.Map<ClienteContrato>(clienteContratoThirdParty);
                                
                                contratoMapped.BomControleContratoId = clienteContratoThirdPartyId;
                                contratoMapped.ClienteId = cliente.Id;
                                
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
                _context.ClienteContratos.AddRange(clientesContratos);    
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

        /// <summary>
        /// Atualiza a periodicidade dos contratos de clientes do BoxApp a partir da periodicidade dos mesmos contratos no BOM CONTROLE
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de contratos atualizados</returns>
        /// <response code="200">Um objeto com o total de contratos atualizados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoUpdate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update-periodicidade-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> UpdatePeriodicidadeFromThirdPartyPAsync()
        {
            #region Get contratos
            IEnumerable<ClienteContrato> clientesContratos = new List<ClienteContrato>();
            try
            {
                clientesContratos = await _context.ClienteContratos.AsNoTracking().ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                AddError("Nenhum contrato de cliente encontrado na base de dados, para então seguir com a atualização da periodicidade dos contratos a partir dos dados da api de terceiro.");
                return CustomResponse(500);
            }
            #endregion

            // TODO: Implementar busca do token diretamente da tabela chave api terceiro
            #region Token resolve
            var token = "ApiKey Z0EjZPzTOb_AOeUDlulXwdnhg9JMHSUQbKek2rFejjXyG9pyoA2hMY35uD1B6bzjynsbTrCaUm347KMoDwiTPkaCND-m5EQwHaUUcTkvYNyhbXzYG7zLggKd7MwMR1qwsW16kQFhc94.";
            #endregion

            #region Obtém os contratos da Api Terceiro um a um e atualiza a periodicidade no BoxApp
            var contratoFromThirdParty = new BCContratoModelService();
            Int64 totalContratosAtualizados = 0;
            try
            {
                foreach (var clienteContrato in clientesContratos)
                {
                    contratoFromThirdParty = await _bcServices.VendaContratoObter((long)clienteContrato.BomControleContratoId, token);
                    if (contratoFromThirdParty != null)
                    {
                        if (clienteContrato.Periodicidade != contratoFromThirdParty.Periodicidade)
                        {
                            clienteContrato.Periodicidade = contratoFromThirdParty.Periodicidade;
                            _context.ClienteContratos.Update(clienteContrato);
                            totalContratosAtualizados++;
                        } else continue;
                    } else continue;
                }
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
                TotalContratosAtualizados = totalContratosAtualizados,
            });
            #endregion
        }
    }
}