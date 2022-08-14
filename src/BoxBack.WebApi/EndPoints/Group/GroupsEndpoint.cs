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
    [Route("api/v{version:apiVersion}/groups")]
    public class GroupsEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GroupsEndpoint(BoxAppDbContext context,
                              UserManager<ApplicationUser> manager, 
                              RoleManager<ApplicationRole> roleManager, 
                              IMapper mapper)
        {
            _context = context;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os grupos ativos
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os grupos ativos</returns>
        /// <response code="200">Lista de grupos ativos</response>
        /// <response code="400">Lista nula</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanGroupListToSelect, CanGroupAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
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
                    return StatusCode(404, "Not found.");
            }
            catch (Exception ex){ return StatusCode(500, ex.Message); }
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
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion
            
            return Ok(new {
                AllData = groups,
                Groups = groups,
                Params = q,
                Total = groups.Count()
            });
        }
    }
}