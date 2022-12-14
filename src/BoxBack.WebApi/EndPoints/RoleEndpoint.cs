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
using BoxBack.Application.ViewModels.Selects;
using BoxBack.WebApi.Controllers;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/roles")]
    public class RoleEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleEndpoint(BoxAppDbContext context,
                             IUnitOfWork unitOfWork,
                             RoleManager<ApplicationRole> roleManager, 
                             IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas as roles
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com as roles</returns>
        /// <response code="200">Lista de roles</response>
        /// <response code="400">Lista nula</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanRoleList, CanRoleAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string q)
        {
            #region Get data
            var roles = new List<ApplicationRole>();
            try
            {
                roles = await _roleManager.Roles
                                        .AsNoTracking()
                                        .OrderBy(x => x.Name)
                                        .ToListAsync();
                if (roles == null)
                {
                    AddError("Nenhuma permissão encontrada.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                roles = roles.Where(x => x.NormalizedName.Contains(q.ToUpper())).ToList();
            #endregion

            #region Map
            IEnumerable<ApplicationRoleViewModel> roleMap = new List<ApplicationRoleViewModel>();
            try
            {
                roleMap = _mapper.Map<IEnumerable<ApplicationRoleViewModel>>(roles);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            var data = new {
                AllData = roleMap.ToList(),
                Roles = roleMap.ToList(),
                Params = q,
                Total = roleMap.Count()
            };
            #endregion
            return CustomResponse(200, data);
        }

        /// <summary>
        /// Cria uma role
        /// </summary>
        /// <param name="applicationRoleViewModel"></param>
        /// <returns>True se criado com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanRoleCreate, CanRoleAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationRoleViewModel applicationRoleViewModel)
        {
            #region Map
            var roleMap = new ApplicationRole();
            try
            {
                roleMap.Id = Guid.NewGuid().ToString();
                roleMap.Name = applicationRoleViewModel.Name;
                roleMap.NormalizedName = applicationRoleViewModel.Name.ToUpper();
                roleMap.ConcurrencyStamp = Guid.NewGuid().ToString();
                roleMap.Description = applicationRoleViewModel.Description;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Create role
            var result = new Microsoft.AspNetCore.Identity.IdentityResult();
            try
            {
                result = await _roleManager.CreateAsync(roleMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Check to result
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    AddError(item.Description);
                }
                return CustomResponse(400);
            }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza uma role
        /// </summary>
        /// <param name="applicationRoleViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanRoleUpdate, CanRoleAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ApplicationRoleViewModel applicationRoleViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(applicationRoleViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var roleDB = new ApplicationRole();
            try
            {
                roleDB = await _roleManager.FindByIdAsync(applicationRoleViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (roleDB == null)
            {
                AddError("Permissão não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var roleMap = new ApplicationRole();
            try
            {
                roleMap = _mapper.Map<ApplicationRoleViewModel, ApplicationRole>(applicationRoleViewModel, roleDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update role
            var result = new Microsoft.AspNetCore.Identity.IdentityResult();
            try
            {
                result = await _roleManager.UpdateAsync(roleMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Check to result
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    AddError(item.Description);
                }
                return CustomResponse(400);
            }
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Deleta uma role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanRoleDelete, CanRoleAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var role = new ApplicationRole();
            try
            {
                role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    AddError("Permissão não encontrada para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                await _roleManager.DeleteAsync(role);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Lista todas roles (permissões) ativas
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com as roles (permissões) ativas</returns>
        /// <response code="200">Lista de roles (permissões) ativas</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanRoleList, CanRoleAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q)
        {
            #region Get data
            var rolesDB = new List<ApplicationRole>();
            try
            {
                rolesDB = await _context
                                        .Roles
                                        .ToListAsync();
                if (rolesDB == null)
                {
                    AddError("Não encontrado");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Map
            IEnumerable<ApplicationRoleSelect2ViewModel> rolesMap = new List<ApplicationRoleSelect2ViewModel>();
            try
            {
                rolesMap = _mapper.Map<IEnumerable<ApplicationRoleSelect2ViewModel>>(rolesDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(rolesMap);
        }
    }
}