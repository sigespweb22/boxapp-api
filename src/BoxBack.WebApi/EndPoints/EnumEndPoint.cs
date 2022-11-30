using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoxBack.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using BoxBack.Domain.Enums;

namespace BoxBack.WebApi.EndPoints
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/enums")]
    public class EnumEndPoint : ApiController
    {
        public EnumEndPoint()
        {
        }

        /// <summary>
        /// Lista de todos os gêneros
        /// </summary>
        /// <param></param>
        /// <returns>Um json com todos os gêneros</returns>
        /// <response code="200">Lista de gêneros</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("generos/list")]
        [HttpGet]
        public IActionResult GenerosListAsync()
        {
            #region Get data
            var generos = new List<string>();
            try
            {
                generos = EnumExtensions<SexoEnum>.GetNames().ToList();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (generos.Count() == 0)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion

            return Ok(generos);
        }

        /// <summary>
        /// Lista de todos os tipo de pessoa
        /// </summary>
        /// <param></param>
        /// <returns>Um json com todos os tipos de pessoa</returns>
        /// <response code="200">Lista de tipos de pessoa</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("tipos-pessoa/list")]
        [HttpGet]
        public IActionResult TiposPessoaListAsync()
        {
            #region Get data
            var tiposPessoa = new List<string>();
            try
            {
                tiposPessoa = EnumExtensions<TipoPessoaEnum>.GetNames().ToList();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (tiposPessoa.Count() == 0)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion

            return Ok(tiposPessoa);
        }

        /// <summary>
        /// Lista de todas as periodicidades
        /// </summary>
        /// <param></param>
        /// <returns>Um json com todas as periodicidades</returns>
        /// <response code="200">Lista das periodicidades</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("periodicidades/list")]
        [HttpGet]
        public IActionResult PeriodicidadesListAsync()
        {
            #region Get data
            var periodicidades = new List<string>();
            try
            {
                periodicidades = EnumExtensions<PeriodicidadeEnum>.GetNames().ToList();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (periodicidades.Count() == 0)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion

            return Ok(periodicidades);
        }
    }
}