﻿using System.Xml;
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
using BoxBack.Domain.Enums;
using BoxBack.Application.ViewModels.Selects;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Services;

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
                users = users.Where(x => x.FullName.Contains(q)).ToList();
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
        /// Lista um usuário pelo id
        /// </summary>s
        /// <param name="id"></param>
        /// <returns>Um objeto tipado com o usuário</returns>
        /// <response code="200">O usuário</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Registro não encontrado</response>
        [Authorize(Roles = "Master, CanUserListOne, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if(string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _context
                                .Users
                                .AsNoTracking()
                                .Include(x => x.ApplicationUserGroups)
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (user == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var userMap = new ApplicationUserViewModel();
            try
            {
                userMap = _mapper.Map<ApplicationUserViewModel>(user);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(user);
        }

        /// <summary>
        /// Lista todos os usuários ativos
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os usuários ativos</returns>
        /// <response code="200">Lista de usuários ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanUserListToSelect, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q)
        {
            #region Get data
            var users = new List<Generic3Select2ViewModel>();
            var usersDB = new List<ApplicationUser>();
            try
            {
                usersDB = await _manager.Users.ToListAsync();
                if (usersDB == null)
                {
                    AddError("Não encontrado");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Map
            try
            {
                foreach(var user in usersDB)
                {
                    var tmp = new Generic3Select2ViewModel()
                    {
                        UserId = user.Id.ToString(),
                        Name = user.FullName
                    };
                    users.Add(tmp);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(users);
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
            applicationUserViewModel.Id = Guid.NewGuid().ToString();
            applicationUserViewModel.UserId = applicationUserViewModel.Id;
            try
            {
                userMap = _mapper.Map<ApplicationUser>(applicationUserViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map set fixeds values
            userMap.LockoutEnabled = true;
            userMap.TwoFactorEnabled = false;
            userMap.EmailConfirmed = true;
            userMap.Avatar = "5.png";
            userMap.Status = ApplicationUserStatusEnum.PENDING;
            #endregion

            #region Data add and password
            try
            {
                await _manager.CreateAsync(userMap);
                await _manager.AddPasswordAsync(userMap, applicationUserViewModel.Password);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
             _unitOfWork.Commit();
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="applicationUserViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ApplicationUserViewModel applicationUserViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(applicationUserViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var userDB = new ApplicationUser();
            try
            {
                userDB = await _context
                                    .Users
                                    .Include(x => x.ApplicationUserGroups)
                                    .FirstOrDefaultAsync(x => x.Id.Equals(applicationUserViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (userDB == null)
            {
                AddError("Usuário não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion 

            #region Grupos remove | Mudar isso pelo amooooor
            _context.ApplicationUserGroups.RemoveRange(userDB.ApplicationUserGroups);
            #endregion

            #region Map User | Mudar isso pelo amoooor
            // Map User
            var userMap = new ApplicationUser();
            try 
            {
                applicationUserViewModel.EmailConfirmed = userDB.EmailConfirmed;
                applicationUserViewModel.LockoutEnd = userDB.LockoutEnd;
                applicationUserViewModel.LockoutEnabled = userDB.LockoutEnabled;
                applicationUserViewModel.Avatar = userDB.Avatar;
                applicationUserViewModel.Funcao = userDB.Funcao.ToString();
                applicationUserViewModel.Setor = userDB.Setor.ToString();
                applicationUserViewModel.Status = userDB.Status.ToString();
                userMap = _mapper.Map<ApplicationUserViewModel, ApplicationUser>(applicationUserViewModel, userDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update user
            try
            {
                _context.Users.Update(userMap);
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