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
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/fornecedores")]
    public class FornecedorEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public FornecedorEndpoint(BoxAppDbContext context,
                                  IUnitOfWork unitOfWork,
                                  UserManager<ApplicationUser> manager, 
                                  RoleManager<ApplicationRole> roleManager,
                                  IMapper mapper,
                                  ICNPJAServices cnpjaServices,
                                  IBCServices bcServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
            _bcServices = bcServices;
        }

        /// <summary>
        /// Lista todos os FORNECEDORES
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os FORNECEDORES</returns>
        /// <response code="200">Lista de FORNECEDORES</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorList, CanFornecedorAll")]
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
            var fornecedores = new List<Fornecedor>();
            try
            {
                fornecedores = await _context.Fornecedores
                                                .AsNoTracking()
                                                .OrderByDescending(x => x.UpdatedAt)
                                                .ToListAsync();
                if (fornecedores == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                fornecedores = fornecedores.Where(x => x.RazaoSocial.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<FornecedorViewModel> fornecedoresMapped = new List<FornecedorViewModel>();
            try
            {
                fornecedoresMapped = _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = fornecedoresMapped.ToList(),
                Fornecedores = fornecedoresMapped.ToList(),
                Params = q,
                Total = fornecedoresMapped.Count()
            });
        }

        /// <summary>
        /// Retorna um fornecedor pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o fornecedor solicitado</returns>
        /// <response code="200">Lista um fornecedor</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Fornecedor não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorRead, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            var fornecedor = new Fornecedor();
            try
            {
                fornecedor = await _context.Fornecedores
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (fornecedor == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var fornecedorMapped = new FornecedorViewModel();
            try
            {
                fornecedorMapped = _mapper.Map<FornecedorViewModel>(fornecedor);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = fornecedorMapped,
                Fornecedor = fornecedorMapped,
                Params = id
            });
        }

        /// <summary>
        /// Cria um FORNECEDOR
        /// </summary>
        /// <param name="fornecedorViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorCreate, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]FornecedorViewModel fornecedorViewModel)
        {
            #region Validations required
            if (string.IsNullOrEmpty(fornecedorViewModel.Cnpj))
            {
                AddError("Cnpj é requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Map
            var fornecedorMapped = new Fornecedor();
            try
            {
                fornecedorMapped = _mapper.Map<Fornecedor>(fornecedorViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Validations
            bool alreadySameCnpj;
            try
            {
                alreadySameCnpj = await _context
                                            .Fornecedores
                                            .AnyAsync(x => x.Cnpj == fornecedorViewModel.Cnpj);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (alreadySameCnpj)
            {
                AddError("Já existe um fornecedor cadastrado com o mesmo CNPJ informado.");
                return CustomResponse(400);
            }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Fornecedores.AddAsync(fornecedorMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um FORNECEDOR
        /// </summary>
        /// <param name="fornecedorViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorUpdate, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]FornecedorViewModel fornecedorViewModel)
        {
            #region Required validations
            if (fornecedorViewModel.Id == null ||
                fornecedorViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var fornecedorDB = new Fornecedor();
            try
            {
                fornecedorDB = await _context
                                        .Fornecedores
                                        .FindAsync(fornecedorViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (fornecedorDB == null)
            {
                AddError("Fornecedor não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var fornecedorMap = new Fornecedor();
            try
            {
                fornecedorMap = _mapper.Map<FornecedorViewModel, Fornecedor>(fornecedorViewModel, fornecedorDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update Fornecedor
            try
            {
                _context.Fornecedores.Update(fornecedorMap);
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
        /// Deleta um FORNECEDOR
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorDelete, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var fornecedor = new Fornecedor();
            try
            {
                fornecedor = await _context.Fornecedores.FindAsync(id);
                if (fornecedor == null)
                {
                    AddError("Fornecedores não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.Fornecedores.Remove(fornecedor);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um FORNECEDOR
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /alter-status
        ///     {
        ///        "id": "f9c7d5a6-1181-4591-948b-5f97088e20a4"
        ///     }
        ///
        /// </remarks>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorUpdate, CanFornecedorAll")]
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
            var fornecedor = new Fornecedor();
            try
            {
                fornecedor = await _context.Fornecedores.FindAsync(id);
                if (fornecedor == null)
                {
                    AddError("Fornecedor não encontrado para alterar seu status.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            switch(fornecedor.IsDeleted)
            {
                case true:
                    fornecedor.IsDeleted = false;
                    break;
                case false:
                    fornecedor.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Fornecedores.Update(fornecedor);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status fornecedor alterado com sucesso." } );
        }

        #region Third Party

        /// <summary>
        /// Lista os dados do CNPJ de uma empresa a partir de uma api de terceiro
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>Um json com os dados da empresa</returns>
        /// <response code="200">Dados da empresa</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CNPJ não encontrado</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /tp
        ///     {
        ///        "cnpj": "23831562000182"
        ///     }
        ///
        /// </remarks>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorCreate, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("tp/{cnpj}")]
        [HttpGet]
        public async Task<IActionResult> GetByApiThirdPartyByCnpj(string cnpj)
        {
            #region Required validations
            if (string.IsNullOrEmpty(cnpj))
            {
                AddError("CNPJ requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var empresa = new CNPJaEmpresaModelService();
            try
            {
                empresa = await _cnpjaServices.ConsultaEstabelecimento(cnpj);
                if (empresa == null)
                {
                    AddError("Empresa não encontrada com o CNPJ informado.");
                    return CustomResponse(404, empresa);
                }
            }
            catch (Exception Content) { AddErrorToTryCatch(Content); return CustomResponse(400); }
            #endregion
            
            return CustomResponse(200, empresa);
        }
        #endregion
    }
}