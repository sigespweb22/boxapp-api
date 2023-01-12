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
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/fornecedores-servicos")]
    public class FornecedorServicoEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public FornecedorServicoEndpoint(BoxAppDbContext context,
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
        /// Lista de todos os SERVIÇOS de um fornecedorServico
        /// </summary>
        /// <param name="q"></param>
        /// <param name="fornecedorId"></param>
        /// <returns>Um json com os SERVIÇOS do fornecedorServico</returns>
        /// <response code="200">Lista de SERVIÇOS do fornecedorServico</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoList, CanFornecedorServicoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string fornecedorId)
        {
            if (string.IsNullOrEmpty(fornecedorId))
            {
                AddError("FornecedorId requerido.");
                return CustomResponse(400);
            }

            #region Get data
            var FornecedorServicos = new List<FornecedorServico>();
            try
            {
                FornecedorServicos = await _context.FornecedorServicos
                                                .AsNoTracking()
                                                .Where(x => x.FornecedorId == Guid.Parse(fornecedorId))
                                                .OrderByDescending(x => x.UpdatedAt)
                                                .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (FornecedorServicos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
                FornecedorServicos = FornecedorServicos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<FornecedorServicoViewModel> fornecedorServicoMapped = new List<FornecedorServicoViewModel>();
            try
            {
                fornecedorServicoMapped = _mapper.Map<IEnumerable<FornecedorServicoViewModel>>(FornecedorServicos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = fornecedorServicoMapped.ToList(),
                FornecedorServicos = fornecedorServicoMapped.ToList(),
                Params = q,
                Total = fornecedorServicoMapped.Count()
            });
        }

        /// <summary>
        /// Lista todos os SERVIÇOS de um fornecedor para uma select2
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com os SERVIÇOS de um fornecedor</returns>
        /// <response code="200">Lista de SERVIÇOS de um fornecedor</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoList, CanFornecedorServicoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var fornecedorServicosDB = new List<FornecedorServico>();
            try
            {
                fornecedorServicosDB = await _context
                                                .FornecedorServicos
                                                .AsNoTracking()
                                                .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                                .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (fornecedorServicosDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<FornecedorServicoSelect2ViewModel> fornecedorServicosMap = new List<FornecedorServicoSelect2ViewModel>();
            try
            {
                fornecedorServicosMap = _mapper.Map<IEnumerable<FornecedorServicoSelect2ViewModel>>(fornecedorServicosDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(fornecedorServicosMap);
        }

        /// <summary> 
        /// Adiciona um SERVIÇO para um fornecedorServico
        /// </summary>
        /// <param name="FornecedorServicoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoCreate, CanFornecedorServicoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]FornecedorServicoViewModel FornecedorServicoViewModel)
        {
            #region Map
            var fornecedorServicoMapped = new FornecedorServico();
            try
            {
                fornecedorServicoMapped = _mapper.Map<FornecedorServico>(FornecedorServicoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            fornecedorServicoMapped.Fornecedor = null;
            #endregion

            #region Persistance and commit
            try
            {
                await _context.FornecedorServicos.AddAsync(fornecedorServicoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { fornecedorId = FornecedorServicoViewModel.FornecedorId});
        }

        /// <summary>
        /// Atualiza o SERVIÇO de um fornecedorServico
        /// </summary>
        /// <param name="FornecedorServicoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoUpdate, CanFornecedorServicoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]FornecedorServicoViewModel FornecedorServicoViewModel)
        {
            #region Required validations
            if (!FornecedorServicoViewModel.Id.HasValue ||
                FornecedorServicoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var FornecedorServicoDB = new FornecedorServico();
            try
            {
                FornecedorServicoDB = await _context
                                            .FornecedorServicos
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == FornecedorServicoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (FornecedorServicoDB == null)
            {
                AddError("Serviço do fornecedor não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var fornecedorServicoMap = new FornecedorServico();
            try
            {
                fornecedorServicoMap = _mapper.Map<FornecedorServicoViewModel, FornecedorServico>(FornecedorServicoViewModel, FornecedorServicoDB);
                fornecedorServicoMap.Fornecedor = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update serviço fornecedorServico
            try
            {
                _context.FornecedorServicos.Update(fornecedorServicoMap);
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

            return CustomResponse(200, new { fornecedorId = FornecedorServicoViewModel.FornecedorId } );
        }

        /// <summary>
        /// Deleta um fornecedorServico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoDelete, CanFornecedorServicoAll, CanFornecedorAll")]
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
            var fornecedorServico = new FornecedorServico();
            try
            {
                fornecedorServico = await _context.FornecedorServicos.FindAsync(id);
                if (fornecedorServico == null)
                {
                    AddError("Serviço do fornecedor não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.FornecedorServicos.Remove(fornecedorServico);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um fornecedorServico
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
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoUpdate, CanFornecedorServicoAll, CanFornecedorAll")]
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
            var FornecedorServico = new FornecedorServico();
            try
            {
                FornecedorServico = await _context.FornecedorServicos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (FornecedorServico == null)
            {
                AddError("Serviço do fornecedor não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(FornecedorServico.IsDeleted)
            {
                case true:
                    FornecedorServico.IsDeleted = false;
                    break;
                case false:
                    FornecedorServico.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.FornecedorServicos.Update(FornecedorServico);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status serviço do fornecedor alterado com sucesso.", fornecedorId = FornecedorServico.FornecedorId } );
        }

        /// <summary>
        /// Retorna um fornecedorServico pelo seu Id
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns>Um objeto com o fornecedorServico solicitado</returns>
        /// <response code="200">Lista um fornecedorServico</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">FornecedorServico não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoRead, CanFornecedorServicoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]Guid? fornecedorId)
        {
            #region Required validations
            if (!fornecedorId.HasValue || fornecedorId == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var fornecedorServico = new FornecedorServico();
            try
            {
                fornecedorServico = await _context.FornecedorServicos
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(x => x.FornecedorId.Equals(fornecedorId));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (fornecedorServico == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var fornecedorServicoMapped = new ClienteViewModel();
            try
            {
                fornecedorServicoMapped = _mapper.Map<ClienteViewModel>(fornecedorServico);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = fornecedorServicoMapped,
                FornecedorServico = fornecedorServicoMapped,
                Params = fornecedorId
            });
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
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorServicoCreate, CanFornecedorServicoAll, CanFornecedorAll")]
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