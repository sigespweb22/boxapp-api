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

        public ClienteContratoEndpoint(BoxAppDbContext context,
                                       IUnitOfWork unitOfWork,
                                       IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os clientes e seus contratos - Apenas clientes que possuem ao menos um contrato
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os clientes e seus contratos</returns>
        /// <response code="200">Lista de clientes com seus contratos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="404">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoList, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var clientes = new List<Cliente>();
            Guid id;
            try
            {
                if (Guid.TryParse(q, out id))
                {
                    clientes = await _context.Clientes
                                                .AsNoTracking()
                                                .Include(x => x.ClienteContratos)
                                                .Where(x => x.Id == id)
                                                .OrderByDescending(x => x.UpdatedAt)
                                                .ToListAsync();
                } 
                else
                {
                    clientes = await _context.Clientes
                                            .AsNoTracking()
                                            .Include(x => x.ClienteContratos)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
                }
                
                if (clientes == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                clientes = clientes.Where(x => x.RazaoSocial.Contains(q)).ToList();
            #endregion

            #region Filter cliente sem contrato
            clientes = clientes.Where(x => x.ClienteContratos.Count() > 0).ToList();
            #endregion

            #region Map
            IEnumerable<ClientePadraoIntegracaoViewModel> clienteMapped = new List<ClientePadraoIntegracaoViewModel>();
            try
            {
                clienteMapped = _mapper.Map<IEnumerable<ClientePadraoIntegracaoViewModel>>(clientes);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                ClientesContratos = clienteMapped.ToList(),
                Total = clienteMapped.Count()
            });
        }
    }
}