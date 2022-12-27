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
using BoxBack.WebApi.Controllers;
using BoxBack.Application.ViewModels;
using BoxBack.Application.Interfaces;
using BoxBack.Domain.InterfacesRepositories;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/rotinas")]
    public class RotinaEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClienteAppService _clienteAppService;

        public RotinaEndpoint(BoxAppDbContext context,
                              IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IClienteAppService clienteAppService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Lista de todas as ROTINAS
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um array json com as ROTINAS</returns>
        /// <response code="200">Lista das ROTINAS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaList, CanRotinaAll")]
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
            var rotinas = new List<Rotina>();
            try
            {
                rotinas = await _context.Rotinas
                                            .AsNoTracking()
                                            .OrderBy(x => x.ChaveSequencial)
                                            .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (rotinas == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
            {
                try
                {
                    rotinas = rotinas.Where(x => x.Nome.Equals(q)).ToList();    
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            }
            #endregion

            #region Map
            IEnumerable<RotinaViewModel> rotinaMapped = new List<RotinaViewModel>();
            try
            {
                rotinaMapped = _mapper.Map<IEnumerable<RotinaViewModel>>(rotinas);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = rotinaMapped.ToList(),
                Rotinas = rotinaMapped.ToList(),
                Params = q,
                Total = rotinaMapped.Count()
            });
        }

        /// <summary>
        /// Atualiza uma ROTINA
        /// </summary>
        /// <param name="rotinaViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaUpdate, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]RotinaViewModel rotinaViewModel)
        {
            #region Required validations
            if (rotinaViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var rotinaDB = new Rotina();
            try
            {
                rotinaDB = await _context
                                        .Rotinas
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == rotinaViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (rotinaDB == null)
            {
                AddError("Rotina não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var rotinaMap = new Rotina();
            try
            {
                rotinaMap = _mapper.Map<RotinaViewModel, Rotina>(rotinaViewModel, rotinaDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update rotina
            try
            {
                _context.Rotinas.Update(rotinaMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Check to result
            try
            {
                await _unitOfWork.CommitAsync(); 
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de uma ROTINA
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
        [Authorize(Roles = "Master, CanRotinaUpdate, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("alter-status/{id}")]
        [HttpPut]
        public async Task<IActionResult> AlterStatusAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var rotina = new Rotina();
            try
            {
                rotina = await _context.Rotinas.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (rotina == null)
            {
                AddError("Rotina não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(rotina.IsDeleted)
            {
                case true:
                    rotina.IsDeleted = false;
                    break;
                case false:
                    rotina.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Rotinas.Update(rotina);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { message = "Status rotina alterado com sucesso."} );
        }

        /// <summary>
        /// Retorna uma ROTINA pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com a ROTINA solicitada</returns>
        /// <response code="200">Lista uma ROTINA</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaRead, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var rotina = new Rotina();
            try
            {
                rotina = await _context.Rotinas
                                         .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (rotina == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var rotinaMapped = new RotinaViewModel();
            try
            {
                rotinaMapped = _mapper.Map<RotinaViewModel>(rotina);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = rotinaMapped,
                Rotina = rotinaMapped,
                Params = id
            });
        }

        /// <summary>
        /// Uma espécie de hub que centraliza as chamadas para rotinas e as despacha
        /// </summary>
        /// <param name="rotinaId"></param>
        /// <returns>Um objeto com o status único relacionado ao sucesso ou não do despacho e início da rotina</returns>
        /// <response code="200">Sucesso do despacho da rotina</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaRead, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("dispatch-clientes-sync/{rotinaId}")]
        [HttpPost]
        public async Task<IActionResult> DispatchClientesSync([FromRoute]Guid rotinaId)
        {
            if (rotinaId == Guid.Empty)
            {
                AddError("Id da rotina requerido.");
                return CustomResponse(400);
            }

            await Task.Run(() => _clienteAppService.SincronizarFromTPAsync(rotinaId)).ConfigureAwait(false);

            return CustomResponse(200);
        }

        /// <summary>
        /// Uma espécie de hub que centraliza as chamadas para rotinas e as despacha
        /// </summary>
        /// <param name="rotinaId"></param>
        /// <returns>Um objeto com o status único relacionado ao sucesso ou não do despacho e início da rotina</returns>
        /// <response code="200">Sucesso do despacho da rotina</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaRead, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("dispatch-contratos-sync-update/{rotinaId}")]
        [HttpPost]
        public async Task<IActionResult> DispatchContratosSyncUpdate([FromRoute]Guid rotinaId)
        {
            await Task.Delay(50);
            return CustomResponse(500);
        }

        /// <summary>
        /// Uma espécie de hub que centraliza as chamadas para rotinas e as despacha
        /// </summary>
        /// <param name="rotinaId"></param>
        /// <returns>Um objeto com o status único relacionado ao sucesso ou não do despacho e início da rotina</returns>
        /// <response code="200">Sucesso do despacho da rotina</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaRead, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("dispatch-faturas-sync/{rotinaId}")]
        [HttpPost]
        public async Task<IActionResult> DispatchFaturasSync([FromRoute]Guid rotinaId)
        {
            await Task.Delay(50);
            return CustomResponse(500);
        }

        /// <summary>
        /// Uma espécie de hub que centraliza as chamadas para rotinas e as despacha
        /// </summary>
        /// <param name="rotinaId"></param>
        /// <returns>Um objeto com o status único relacionado ao sucesso ou não do despacho e início da rotina</returns>
        /// <response code="200">Sucesso do despacho da rotina</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaRead, CanRotinaAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("dispatch-faturas-update/{rotinaId}")]
        [HttpPost]
        public async Task<IActionResult> DispatchFaturasUpdate([FromRoute]Guid rotinaId)
        {
            await Task.Delay(50);
            return CustomResponse(500);
        }
    }
}