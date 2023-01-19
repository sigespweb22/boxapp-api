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
    [Route("api/v{version:apiVersion}/vendedores-contratos")]
    public class VendedorContratoEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBCServices _bcServices;

        public VendedorContratoEndpoint(BoxAppDbContext context,
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
        /// Lista de todos os CONTRATOS vinculados a um VENDEDOR
        /// </summary>
        /// <param name="q"></param>
        /// <param name="vendedorId"></param>
        /// <returns>Um array json com os CONTRATOS vinculados ao vendedor</returns>
        /// <response code="200">Lista de CONTRATOS vinculados ao vendedor</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorContratoList, CanVendedorContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string vendedorId)
        {
            #region Required validations
            if (string.IsNullOrEmpty(vendedorId))
            {
                AddError("Id Vendedor requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var vendedorContratos = new List<VendedorContrato>();
            try
            {
                vendedorContratos = await _context.VendedoresContratos
                                                    .AsNoTracking()
                                                    .Include(x => x.Vendedor)
                                                    .Include(x => x.ClienteContrato)
                                                    .ThenInclude(x => x.Cliente)
                                                    .Where(x => x.VendedorId == Guid.Parse(vendedorId))
                                                    .OrderByDescending(x => x.UpdatedAt)
                                                    .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
            {
                try
                {
                    vendedorContratos = vendedorContratos.Where(x => x.Vendedor.Nome.Contains(q)).ToList();
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            }
            #endregion

            #region Map
            IEnumerable<VendedorContratoViewModel> vendedorContratoMapped = new List<VendedorContratoViewModel>();
            try
            {
                vendedorContratoMapped = _mapper.Map<IEnumerable<VendedorContratoViewModel>>(vendedorContratos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = vendedorContratoMapped.ToList(),
                VendedorContratos = vendedorContratoMapped.ToList(),
                Params = q,
                Total = vendedorContratoMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona um CONTRATO para um vendedor
        /// </summary>
        /// <param name="vendedorContratoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanVendedorContratoCreate, CanVendedorContratoAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]VendedorContratoViewModel vendedorContratoViewModel)
        {
            #region Generals validations
            try
            {
                if (AlreadyVinculo(vendedorContratoViewModel))
                {
                    AddError("Já existe um vínculo de contrato ativo para o mesmo vendedor e contrato informados.");
                    return CustomResponse(400);
                }
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(400); }

            #endregion

            #region Map
            var vendedorContratoMapped = new VendedorContrato();
            try
            {
                vendedorContratoMapped = _mapper.Map<VendedorContrato>(vendedorContratoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.VendedoresContratos.AddAsync(vendedorContratoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { vendedorId = vendedorContratoViewModel.VendedorId});
        }

        /// <summary>
        /// Atualiza o CONTRATO de um vendedor
        /// </summary>
        /// <param name="vendedorContratoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorContratoUpdate, CanVendedorContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]VendedorContratoViewModel vendedorContratoViewModel)
        {
            #region Required validations
            if (!vendedorContratoViewModel.Id.HasValue ||
                vendedorContratoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var vendedorContratoDB = new VendedorContrato();
            try
            {
                vendedorContratoDB = await _context
                                            .VendedoresContratos
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == vendedorContratoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (vendedorContratoDB == null)
            {
                AddError("Serviço de vendedor não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var vendedorContratoMap = new VendedorContrato();
            try
            {
                vendedorContratoMap = _mapper.Map<VendedorContratoViewModel, VendedorContrato>(vendedorContratoViewModel, vendedorContratoDB);
                vendedorContratoMap.Vendedor = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update serviço vendedor
            try
            {
                _context.VendedoresContratos.Update(vendedorContratoMap);
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

            return CustomResponse(200, new { vendedorId = vendedorContratoViewModel.VendedorId } );
        }

        /// <summary>
        /// Altera o status do registro de CONTRATO vinculado a um vendedor
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
        [Authorize(Roles = "Master, CanVendedorContratoUpdate, CanVendedorContratoAll")]
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
            var vendedorContrato = new VendedorContrato();
            try
            {
                vendedorContrato = await _context.VendedoresContratos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (vendedorContrato == null)
            {
                AddError("Contrato do vendedor não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(vendedorContrato.IsDeleted)
            {
                case true:
                    vendedorContrato.IsDeleted = false;
                    break;
                case false:
                    vendedorContrato.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.VendedoresContratos.Update(vendedorContrato);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { message = "Status contrato vinculado ao vendedor alterado com sucesso.", vendedorId = vendedorContrato.VendedorId } );
        }

        /// <summary>
        /// Retorna um CONTRATO vinculado a um vendedor pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o CONTRATO solicitado</returns>
        /// <response code="200">Lista um CONTRATO vinculado a um vendedor</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CONTRATO não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorContratoRead, CanVendedorContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]Guid? id)
        {
            #region Required validations
            if (!id.HasValue || id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var vendedorContrato = new VendedorContrato();
            try
            {
                vendedorContrato = await _context.VendedoresContratos
                                                 .Include(x => x.Vendedor)
                                                 .Include(x => x.ClienteContrato)
                                                 .ThenInclude(x => x.Cliente)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (vendedorContrato == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var vendedorContratoMapped = new VendedorContratoViewModel();
            try
            {
                vendedorContratoMapped = _mapper.Map<VendedorContratoViewModel>(vendedorContrato);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = vendedorContratoMapped,
                VendedorContrato = vendedorContratoMapped,
                Params = id
            });
        }

        private bool AlreadyVinculo (VendedorContratoViewModel vendedorContratoViewModel)
        {
            #region Validation required
            if (vendedorContratoViewModel == null)
                throw new ArgumentNullException ("Dados requeridos não informados.");
            
            if (vendedorContratoViewModel.VendedorId == Guid.Empty)
                throw new ArgumentNullException ("Id do vendedor não informado");
            
            if (vendedorContratoViewModel.ClienteContratoId == Guid.Empty)
                throw new ArgumentNullException ("Id do contrato não informado");
            #endregion

            #region Check to already
            bool alreadyVinculo;
            try
            {
                alreadyVinculo = _context
                                    .VendedoresContratos
                                    .IgnoreQueryFilters()
                                    .Any(x => x.IsDeleted == false && 
                                         x.VendedorId.Equals(vendedorContratoViewModel.VendedorId) &&
                                         x.ClienteContratoId.Equals(vendedorContratoViewModel.ClienteContratoId));
            }
            catch (System.Exception ex) { throw new InvalidOperationException(ex.Message); }
            #endregion

            return alreadyVinculo;
        }
    }
}