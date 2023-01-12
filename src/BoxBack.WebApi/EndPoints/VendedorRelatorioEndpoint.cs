using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.Interfaces;
using System.Collections.Generic;
using BoxBack.Application.ViewModels;
using System.Linq;
using BoxBack.Application.ViewModels.Date;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vendedores-relatorios")]
    public class VendedorRelatorioEndpoint : ApiController
    {
        private readonly IVendedorComissaoAppService _vendedorComissaoAppService;
        public VendedorRelatorioEndpoint(IVendedorComissaoAppService vendedorComissaoAppService)
        {
            _vendedorComissaoAppService = vendedorComissaoAppService;
        }

        /// <summary>
        /// Lista todos os dados para geração em tela de relatório de comissão de um vendedor
        /// </summary>
        /// <param name="vendedorId"></param>
        /// <param name="dataPeriodo"></param>
        /// <returns>Um objeto com todos os dados para geração em tela de relatório de comissão de um vendedor</returns>
        /// <response code="200">Um objeto com todos os dados para geração em tela de relatório de comissão de um vendedor</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorRelatorioListComissao, CanVendedorRelatorioAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-comissoes/{vendedorId}")]
        [HttpPost]
        public async Task<IActionResult> ListComissoesAsync([FromBody]DataPeriodoViewModel dataPeriodo, [FromRoute]string vendedorId)
        {
            #region Get data
            IEnumerable<VendedorComissaoViewModel> vendedorComissoesViewModel = new List<VendedorComissaoViewModel>();
            try
            {
                vendedorComissoesViewModel = await _vendedorComissaoAppService.GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(vendedorId, dataPeriodo);
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
    }
}