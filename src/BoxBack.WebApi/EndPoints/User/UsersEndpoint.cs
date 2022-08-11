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
            var result = new List<UserTemp>();
            try
            {
                var user1 = new UserTemp()
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    FullName = "ALAN LEITE DE REZENDE",
                    Company = "Box Tecnologia",
                    Roles = new string[] {"SUPORTE", "FINANCEIRO"},
                    UserName = "alan.rezende",
                    Country = "Brasil",
                    Contact = "(48) 9.9961-6679",
                    Email = "alan.rezende@boxtecnologia.com.br",
                    Status = "ACTIVE",
                    Avatar = "",
                    AvatarColor = "primary"
                };

                var user2 = new UserTemp()
                {
                    Id = "43ab3050-cfe7-4f6b-9034-d9d4c317df0e",
                    FullName = "JOÃO DA SILVA",
                    Company = "Box Tecnologia",
                    Roles = new string[] {"MASTER", "ADMIN", "SUPORTE", "USER"},
                    UserName = "joao.silva",
                    Country = "Brasil",
                    Contact = "(48) 9.9961-6679",
                    Email = "joao.silva@boxtecnologia.com.br",
                    Status = "PENDING",
                    Avatar = "",
                    AvatarColor = "info"
                };

                var user3 = new UserTemp()
                {
                    Id = "a94c13b5-756a-467d-8f18-6b10254c7f3e",
                    FullName = "LEONARDO CARVALHO MOREIRA",
                    Company = "Box Tecnologia",
                    Roles = new string[] {"MASTER", "ADMIN", "SUPORTE", "USER"},
                    UserName = "leonardo.moreira",
                    Country = "Brasil",
                    Contact = "(48) 9.9961-6679",
                    Email = "leonardo.moreira@boxtecnologia.com.br",
                    Status = "INACTIVE",
                    Avatar = "",
                    AvatarColor = "warning"
                };

                result.Add(user1);
                result.Add(user2);
                result.Add(user3);

                // users = await _manager.Users
                //                     .AsNoTracking()
                //                     .Include(x => x.ContaUsuario)
                //                     .ToListAsync();
                
            }
            catch (Exception ex){ return StatusCode(500, ex.Message); }
            if (result == null)
                return StatusCode(404, "Not found.");

            if(!string.IsNullOrEmpty(q))
                result = result.Where(x => x.FullName.Contains(q.ToUpper())).ToList();

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