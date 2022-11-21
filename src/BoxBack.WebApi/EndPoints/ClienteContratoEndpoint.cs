using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.Interfaces;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;
using BoxBack.Application.ViewModels.Selects;
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
        /// Obtém todos os contratos de um cliente do BOM CONTROLE (Pesquisa os contratos Por CNPJ ou nome do cliente) e mantém a base de contratos do cliente do BoxApp idêntica ao Bom Controle (Este método não atualiza os dados dos contratos, apenas mantém os mesmos contratos em ambos os sistemas)
        /// </summary>
        /// <param></param>
        /// <returns>Um array de objetos com os contratos do clientes</returns>
        /// <response code="200">Array de objeto com os contratos de clientes</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoCreate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("sincronizar-third-party")]
        [HttpGet]
        public async Task<IActionResult> SincronizarThirdPartyPAsync()
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
            var token = "ApiKey Z0EjZPzTOb-8NpoAk4GtAa8xOF7FW8cQDS4OPyGpk90XLOgEysE3zLAD7ClZLMNaynsbTrCaUm1lQiABFUNKY5Gg92GcpUhpHaUUcTkvYNyhbXzYG7zLggKd7MwMR1qwsW16kQFhc94.";
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
                                contratoMapped = _mapper.Map<ClienteContrato>(clienteContratoThirdParty);
                                await _context.ClienteContratos.AddAsync(contratoMapped);
                                totalSincronizado++;
                            }
                            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                        }
                    }
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            _unitOfWork.Commit();
            #endregion

            #region Return
            return CustomResponse(200, new {
                TotalSincronizado = totalSincronizado,
            });
            #endregion
        }
    }
}