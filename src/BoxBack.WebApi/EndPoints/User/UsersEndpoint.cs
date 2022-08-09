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

namespace BoxBack.WebApi.EndPoints.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly IContaUsuarioAppService _contaUsuarioAppService;
        private readonly IContaUsuarioRepository _contaUsuarioRepository;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;

        public UsersEndpoint(BoxAppDbContext context,
                             UserManager<ApplicationUser> manager, RoleManager<ApplicationRole> roleManager, IMapper mapper, IContaUsuarioAppService contaUsuarioAppService, IContaUsuarioRepository contaUsuarioRepository, ValidationResult validationResult)
        {
            _context = context;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _contaUsuarioAppService = contaUsuarioAppService;
            _contaUsuarioRepository = contaUsuarioRepository;
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
         [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<UserTemp>();
            try
            {
                var user1 = new UserTemp()
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    FullName = "ALAN LEITE DE REZENDE",
                    Company = "Box Tecnologia",
                    Role = "Admin",
                    UserName = "alan.rezende",
                    Country = "Brasil",
                    Contact = "(48) 9.9961-6679",
                    Email = "alan.rezende@boxtecnologia.com.br",
                    Status = "active",
                    Avatar = "",
                    AvatarColor = "primary"
                };

                result.Add(user1);

                // users = await _manager.Users
                //                     .AsNoTracking()
                //                     .Include(x => x.ContaUsuario)
                //                     .ToListAsync();
                
            }
            catch (Exception ex){ return StatusCode(500, ex.Message); }
            if (result == null)
                return StatusCode(404, "Not found.");
            return Ok(new {
                AllData = result,
                Users = result,
                Params = "",
                Total = 1
            });
        }

        public class UserTemp
        {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Company { get; set; }
            public string Role { get; set; }
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