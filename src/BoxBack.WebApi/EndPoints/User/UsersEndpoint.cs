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
using BoxBack.Domain.Interfaces;

namespace BoxBack.WebApi.EndPoints.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;

        public UsersEndpoint(BoxAppDbContext context,
                             UserManager<ApplicationUser> manager, 
                             RoleManager<ApplicationRole> roleManager, 
                             IMapper mapper, ValidationResult validationResult)
        {
            _context = context;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _validationResult = validationResult;
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>s
        /// <param name=""></param>
        /// <returns>Um json com os usuários</returns>
        /// <response code="200">Lista de usuários</response>
        /// <response code="400">Lista nula</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "MASTER, USER_LIST")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string q)
        {
            #region Get data
            var users = new List<ApplicationUser>();
            try
            {
                users = await _manager.Users
                                        .AsNoTracking()
                                        .Include(x => x.ApplicationUserRoles)
                                        .ThenInclude(x => x.ApplicationRole)
                                        .ToListAsync();
                if (users == null)
                    return StatusCode(404, "Not found.");
            }
            catch (Exception ex){ return StatusCode(500, ex.Message); }
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
            catch (Exception ex) { return StatusCode(500, ex); }
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
        /// <param name="ApplicationUserViewMode"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Null data</response>
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationUserViewModel applicationUserViewModel)
        {
            #region Properties resolve
            // var usnPS = applicationUserViewModel.Email.IndexOf("@");
            // var userName = applicationUserViewModel.Email.Substring(0, usnPS);
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
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            var result = await _manager.CreateAsync(userMap);
            if (result.Succeeded)
            {
                await _manager.AddPasswordAsync(userMap, applicationUserViewModel.Password);   
            }
            else
            {
                return StatusCode(400, result.Errors);
            }

            return StatusCode(201, new {
                Data = userMap,
                Message = "Usuário criado com sucesso." }
            );
        }

        public class UserTemp
        {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Company { get; set; }
            public new string[] Roles { get; set; }
            public string UserName { get; set; }
            public string Country { get; set; }
            public string Contact { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
            public string Avatar { get; set; }
            public string AvatarColor { get; set; }
        }
    }
}