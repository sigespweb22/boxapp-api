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
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;
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

        /// <summary>
        /// Lista de todas as FATURAS de um CONTRATO de CLIENTE
        /// </summary>
        /// <param name="q"></param>
        /// <param name="clienteContratoId"></param>
        /// <param name="quitadas"></param>
        /// <returns>Um array json com as FATURAS do contrato do cliente</returns>
        /// <response code="200">Lista de FATURAS do contrato do cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoFaturaList, CanClienteContratoFaturaAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string clienteContratoId, bool quitadas = false)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(clienteContratoId))
            {
                AddError("Id Contrato requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var clienteContratoFaturas = new List<ClienteContratoFatura>();
            try
            {
                clienteContratoFaturas = await _context.ClientesContratosFaturas
                                                        .AsNoTracking()
                                                        .Include(x => x.ClienteContrato)
                                                        .ThenInclude(x => x.Cliente)
                                                        .Where(x => x.ClienteContratoId == Guid.Parse(clienteContratoId) &&
                                                               x.Quitado.Equals(quitadas))
                                                        .OrderBy(x => x.NumeroParcela)
                                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteContratoFaturas == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
                clienteContratoFaturas = clienteContratoFaturas.Where(x => x.Valor.Equals(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ClienteContratoFaturaViewModel> clienteContratoFaturaMapped = new List<ClienteContratoFaturaViewModel>();
            try
            {
                clienteContratoFaturaMapped = _mapper.Map<IEnumerable<ClienteContratoFaturaViewModel>>(clienteContratoFaturas);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteContratoFaturaMapped.ToList(),
                clienteContratoFaturas = clienteContratoFaturaMapped.ToList(),
                Params = q,
                Total = clienteContratoFaturaMapped.Count()
            });
        }
    }
}