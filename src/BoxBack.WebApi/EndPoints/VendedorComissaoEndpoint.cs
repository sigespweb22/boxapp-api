﻿using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.Interfaces;
using System.Collections.Generic;
using BoxBack.Application.ViewModels;
using System.Linq;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vendedores-comissoes")]
    public class VendedorComissaoEndpoint : ApiController
    {
        private readonly IVendedorComissaoAppService _vendedorComissaoAppService;
        public VendedorComissaoEndpoint(IVendedorComissaoAppService vendedorComissaoAppService)
        {
            _vendedorComissaoAppService = vendedorComissaoAppService;
        }

        /// <summary>
        /// Lista de todas as COMISSÕES de um VENDEDOR
        /// </summary>
        /// <param name="vendedorId"></param>
        /// <returns>Um array json com as COMISSÕES de um VENDEDOR</returns>
        /// <response code="200">Lista de COMISSÕES de um VENDEDOR</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorComissaoList, CanVendedorComissaoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-by-vendedor/{vendedorId}")]
        [HttpGet]
        public async Task<IActionResult> ListByVendedorAsync([FromRoute]string vendedorId)
        {
            #region Required validations
            if (string.IsNullOrEmpty(vendedorId))
            {
                AddError("Id Vendedor requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            IEnumerable<VendedorComissaoViewModel> vendedorComissoesViewModel = new List<VendedorComissaoViewModel>();
            try
            {
                vendedorComissoesViewModel = await _vendedorComissaoAppService.GetAllWithIncludesByVendedorIdAsync(vendedorId);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (vendedorComissoesViewModel.Count() == 0)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            return Ok(new {
                VendedoresComissoes = vendedorComissoesViewModel,
                Total = vendedorComissoesViewModel.Count(),
                Params = vendedorId,
                AllData = vendedorComissoesViewModel,
            });
        }

        /// <summary>
        /// Altera o status do registro de COMISSÃO do VENDEDOR
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro interno desconhecido</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /alter-status
        ///     {
        ///        "id": "f9c7d5a6-1181-4591-948b-5f97088e20a4"
        ///     }
        ///
        /// </remarks>
        [Authorize(Roles = "Master, CanVendedorComissaoUpdate, CanVendedorComissaoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("alter-status/{id}")]
        [HttpPut]
        public async Task<IActionResult> AlterStatusAsync(Guid id)
        {
            #region Validations model state
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            return CustomResponse(200, new { success = await _vendedorComissaoAppService.AlterStatusAsync(id), message = "Status comissão de vendedor alterado com sucesso." } );
        }
    }
}