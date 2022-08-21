using System.Net;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Net.Sockets;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
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
using BoxBack.Application.Helpers;

namespace BoxBack.WebApi.EndPoints.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/groups")]
    public class GroupsEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GroupsEndpoint(BoxAppDbContext context,
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
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os grupos</returns>
        /// <response code="200">Lista de grupos</response>
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
            var groups = new List<ApplicationGroup>();
            try
            {
                groups = await _context.ApplicationGroups
                                        .AsNoTracking()
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
                groups = groups.Where(x => x.Name.Contains(q.ToUpper())).ToList();
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
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os grupos ativos</returns>
        /// <response code="200">Lista de grupos ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanGroupListToSelect, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q)
        {
            #region Get data
            var groups = new List<Generic2Select2ViewModel>();
            var groupsDB = new List<ApplicationGroup>();
            try
            {
                groupsDB = await _context
                                        .ApplicationGroups
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
            try
            {
                foreach(var group in groupsDB)
                {
                    var tmp = new Generic2Select2ViewModel()
                    {
                        Id = group.Id.ToString(),
                        Name = group.Name
                    };
                    groups.Add(tmp);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(groups);
        }

        /// <summary>
        /// Cria um grupo
        /// </summary>
        /// <param name="applicationGroupViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanGroupCreate, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationGroupViewModel applicationGroupViewModel)
        {
            #region Validations generals
            bool groupAlready;
            try
            {
                groupAlready = _context.ApplicationGroups.Any(x => x.Name == applicationGroupViewModel.Name);    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (groupAlready)
            {
                AddError("Já existe um grupo com o nome informado.");
                return CustomResponse(400);
            }
            #endregion

            #region Map and persistance data without commit
            var groupMap = new ApplicationGroup();
            try
            {
                groupMap.Id = new Guid();
                groupMap.Name = applicationGroupViewModel.Name;
                groupMap.UniqueKey = KeyGenerate.CreateUniqueKeyBySecret(applicationGroupViewModel.Name);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            try
            {
                _context.ApplicationGroups.Add(groupMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Roles resolve and data inserts
            foreach (var roleName in applicationGroupViewModel.ApplicationRoleGroups)
            {
                // check to existence the role in group
                var role = new ApplicationRole();
                try
                {
                    role = await _roleManager.FindByNameAsync(roleName);    
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                if (role == null)
                {
                    AddError("Problemas ao criar um grupo. \nA permissão " + roleName + " não foi encontrada.");
                    return CustomResponse(400);
                }

                // map role to group
                var aRg = new ApplicationRoleGroup();
                try
                {
                    aRg.GroupId = groupMap.Id;
                    aRg.RoleId = role.Id;
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                
                // persistance role to group
                _context.ApplicationRoleGroups.Add(aRg);                
            }
            #endregion

            #region Commit
            _unitOfWork.Commit();
            #endregion
            
            return CustomResponse(201);
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
        [Route("alter-status/{id}")]
        [Authorize(Roles = "Master, CanGroupAlterStatus, CanGroupAll")]
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
            var group = new ApplicationGroup();
            try
            {
                group = await _context
                                .ApplicationGroups
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
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanGroupDelete, CanGroupAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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