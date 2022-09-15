using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.WebApi.Extensions;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Enums;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels.Selects;
using BoxBack.Infra.Data.Extensions;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.ViewModels.Requests;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public UserEndpoint(BoxAppDbContext context,
                             IUnitOfWork unitOfWork,
                             UserManager<ApplicationUser> manager, 
                             RoleManager<ApplicationRole> roleManager, 
                             IMapper mapper,
                             ICNPJAServices cnpjaServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os usuários</returns>
        /// <response code="200">Lista de usuários</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanUserList, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var users = new List<ApplicationUser>();
            try
            {
                users = await _manager.Users
                                        .AsNoTracking()
                                        .Include(x => x.ApplicationUserRoles)
                                        .ThenInclude(x => x.ApplicationRole)
                                        .Include(x => x.ApplicationUserGroups)
                                        .ThenInclude(x => x.ApplicationGroup)
                                        .OrderBy(x => x.UserName)
                                        .ToListAsync();
                if (users == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                users = users.Where(x => x.FullName.Contains(q.ToUpper())).ToList();
            #endregion

            #region Map
            IEnumerable<ApplicationUserViewModel> userMap = new List<ApplicationUserViewModel>();
            try
            {
                userMap = _mapper.Map<IEnumerable<ApplicationUserViewModel>>(users);
                foreach(var tmp in userMap)
                {
                    tmp.UserName = tmp.UserName.Substring(0, tmp.UserName.IndexOf("@"));
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = userMap.ToList(),
                Users = userMap.ToList(),
                Params = q,
                Total = userMap.Count()
            });
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="applicationUserViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanUserCreate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationUserViewModel applicationUserViewModel)
        {
            #region Validations required
            if (string.IsNullOrEmpty(applicationUserViewModel.Password))
            {
                AddError("Senha é requerida.");
                return CustomResponse(400);
            }
            #endregion

            #region Map
            var userMap = new ApplicationUser();
            try
            {
                userMap.Id = Guid.NewGuid().ToString();
                userMap.UserName = applicationUserViewModel.Email;
                userMap.NormalizedUserName = applicationUserViewModel.Email.ToUpper();
                userMap.Email = applicationUserViewModel.Email;
                userMap.NormalizedEmail = applicationUserViewModel.Email.ToUpper();
                userMap.TwoFactorEnabled = false;
                userMap.EmailConfirmed = true;
                userMap.Avatar = string.Empty;
                userMap.FullName = applicationUserViewModel.FullName.ToUpper();
                userMap.Status = ApplicationUserStatusEnum.PENDING;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            var result = await _manager.CreateAsync(userMap);
            if (result.Succeeded)
            {
                await _manager.AddPasswordAsync(userMap, applicationUserViewModel.Password);   
            }
            else
            {
                foreach (var item in result.Errors.Select(x => x.Description).ToList())
                {
                    AddError(item);
                }
                return CustomResponse(400);
            }

            #region Group resolve and insert data
            foreach (var uGroup in applicationUserViewModel.ApplicationUserGroups)
            {
                // check to existence the role in group
                var hasRolesInGroup = _context.ApplicationGroups
                                                    .Where(x => x.Name == uGroup &&
                                                           x.ApplicationRoleGroups.Count() > 0)
                                                    .Any();

                if (!hasRolesInGroup)
                {
                    return CustomResponse(201, new { message = "Usuário criado com sucesso. \nPorém grupo de usuário " + uGroup + " não possui nenhuma permissão vinculada a ele. \nPrimeiro faça este vínculo e depois o atribua a um usuário."});
                }

                Guid groupId = _context.ApplicationGroups
                                            .Where(x => x.Name == uGroup)
                                            .Select(x => x.Id)
                                            .FirstOrDefault(); 

                if (groupId == Guid.Empty)
                {
                    AddError("Problemas ao adicionar um grupo para o usuário criado. Adicione manualmente um grupo ao usuário criado editando seu registro.");
                    return CustomResponse(400);
                }

                var tmp = new ApplicationUserGroup() { UserId = userMap.Id, GroupId = groupId };

                _context.ApplicationUserGroups.Add(tmp);
                _unitOfWork.Commit();
            }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanUserDelete, CanUserAll")]
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
            var user = new ApplicationUser();
            try
            {
                user = await _manager.FindByIdAsync(id);
                if (user == null)
                {
                    AddError("Usuário não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                await _manager.DeleteAsync(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um usuário
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
        [Route("alter-status/{id}")]
        [Authorize(Roles = "Master, CanUserAlterStatus, CanUserAll")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            var user = new ApplicationUser();
            try
            {
                user = await _manager.FindByIdAsync(id);
                if (user == null)
                {
                    AddError("Usuário não encontrado para alterar seu status.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            switch(user.Status)
            {
                case ApplicationUserStatusEnum.ACTIVE:
                    user.Status = ApplicationUserStatusEnum.INACTIVE;
                    break;
                case ApplicationUserStatusEnum.INACTIVE:
                    user.Status = ApplicationUserStatusEnum.ACTIVE;
                    break;
                case ApplicationUserStatusEnum.PENDING:
                    user.Status = ApplicationUserStatusEnum.ACTIVE;
                    break;
                default:
                    user.Status = ApplicationUserStatusEnum.INACTIVE;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                await _manager.UpdateAsync(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status usuário alterado com sucesso." } );
        }
    }
}