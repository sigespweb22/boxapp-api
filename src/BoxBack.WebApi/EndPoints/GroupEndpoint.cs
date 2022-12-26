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
using BoxBack.Application.ViewModels.Selects;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.Helpers;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/groups")]
    public class GroupEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GroupEndpoint(BoxAppDbContext context,
                              IUnitOfWork unitOfWork,
                              UserManager<ApplicationUser> manager, 
                              RoleManager<ApplicationRole> roleManager, 
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os grupos
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os grupos</returns>
        /// <response code="200">Lista de grupos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserList, CanUserAll, CanGroupAll")]
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
            var groups = new List<ApplicationGroup>();
            try
            {
                groups = await _context.ApplicationGroups
                                        .AsNoTracking()
                                        .IgnoreQueryFilters()
                                        .Include(x => x.ApplicationRoleGroups)
                                        .ThenInclude(x => x.ApplicationRole)
                                        .OrderBy(x => x.Name)
                                        .ToListAsync();
                if (groups == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                groups = groups.Where(x => x.Name.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ApplicationGroupViewModel> groupMap = new List<ApplicationGroupViewModel>();
            try
            {
                groupMap = _mapper.Map<IEnumerable<ApplicationGroupViewModel>>(groups);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = groupMap.ToList(),
                Groups = groupMap.ToList(),
                Params = q,
                Total = groupMap.Count()
            });
        }

        /// <summary>
        /// Lista todos os grupos ativos
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com os grupos ativos</returns>
        /// <response code="200">Lista de grupos ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanGroupList, CanGroupAll, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var groupsDB = new List<ApplicationGroup>();
            try
            {
                groupsDB = await _context
                                        .ApplicationGroups
                                        .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                        .ToListAsync();
                if (groupsDB == null)
                {
                    AddError("Não encontrado");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Map
            IEnumerable<ApplicationGroupSelect2ViewModel> groupsMap = new List<ApplicationGroupSelect2ViewModel>();
            try
            {
                groupsMap = _mapper.Map<IEnumerable<ApplicationGroupSelect2ViewModel>>(groupsDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(groupsMap);
        }

        /// <summary>
        /// Cria um grupo
        /// </summary>
        /// <param name="applicationGroupViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanGroupCreate, CanGroupAll, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationGroupViewModel applicationGroupViewModel)
        {
            #region Validations generals
            bool groupAlready;
            try
            {
                groupAlready = await _context.ApplicationGroups.AnyAsync(x => x.Name == applicationGroupViewModel.Name);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (groupAlready)
            {
                AddError("Já existe um grupo com o nome informado.");
                return CustomResponse(400);
            }
            #endregion

            #region Map
            var groupMap = new ApplicationGroup();
            try
            {
                groupMap = _mapper.Map<ApplicationGroup>(applicationGroupViewModel);
                groupMap.UniqueKey = KeyGenerate.CreateUniqueKeyBySecret(applicationGroupViewModel.Name);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            try
            {
                _context.ApplicationGroups.Add(groupMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            _unitOfWork.Commit();
            #endregion
            
            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um grupo
        /// </summary>
        /// <param name="applicationGroupViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanGroupUpdate, CanGroupAll, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ApplicationGroupUpdateViewModel applicationGroupViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(applicationGroupViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var groupDB = new ApplicationGroup();
            try
            {
                groupDB = await _context
                                    .ApplicationGroups
                                    .Include(x => x.ApplicationRoleGroups)
                                    .FirstOrDefaultAsync(x => x.Id.ToString() == applicationGroupViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (groupDB == null)
            {
                AddError("Grupo de permissões não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion 

            #region Grupos remove | Mudar isso pelo amooooor
            _context.ApplicationRoleGroups.RemoveRange(groupDB.ApplicationRoleGroups);
            #endregion

            #region Map User | Mudar isso pelo amoooor
            // Map User
            var groupMap = new ApplicationGroup();
            try 
            {
                // applicationGroupViewModel.EmailConfirmed = userDB.EmailConfirmed;
                // applicationUserViewModel.LockoutEnd = userDB.LockoutEnd;
                // applicationUserViewModel.LockoutEnabled = userDB.LockoutEnabled;
                // applicationUserViewModel.Avatar = userDB.Avatar;
                // applicationUserViewModel.Funcao = userDB.Funcao.ToString();
                // applicationUserViewModel.Setor = userDB.Setor.ToString();
                // applicationUserViewModel.Status = userDB.Status.ToString();
                groupMap = _mapper.Map<ApplicationGroupUpdateViewModel, ApplicationGroup>(applicationGroupViewModel, groupDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update user
            try
            {
                _context.ApplicationGroups.Update(groupMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um grupo
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
        [Route("alter-status/{id}")]
        [Authorize(Roles = "Master, CanGroupUpdate, CanGroupAll, CanGroupAll")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> AlterStatusAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var group = new ApplicationGroup();
            try
            {
                group = await _context
                                .ApplicationGroups
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (group == null)
            {
                AddError("Grupo não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(group.IsDeleted)
            {
                case false:
                    group.IsDeleted = true;
                    break;
                case true:
                    group.IsDeleted = false;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.ApplicationGroups.Update(group);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion
            return CustomResponse(200, new { message = "Status grupo alterado com sucesso." } );
        }
        
        /// <summary>
        /// Deleta um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanGroupDelete, CanGroupAll, CanGroupAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id)) {
                AddError("Id requerido.");
                return CustomResponse(400);
            } 
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var group = new ApplicationGroup();
            try
            {
                group = await _context.ApplicationGroups.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
                if (group == null) 
                {
                    AddError("Grupo não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete and commit
            try
            {
                _context.ApplicationGroups.Remove(group);    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            _unitOfWork.Commit();
            #endregion

            return CustomResponse(204);
        }
    }
}   