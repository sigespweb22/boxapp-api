using System.Net.Mail;
using System.Net.WebSockets;
using System.Net.Cache;
using System.Net;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using BoxBack.Domain.Models;
using BoxBack.Domain.Interfaces;
using BoxBack.Infra.CrossCutting.Identity.Services;
using BoxBack.WebApi.Security;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Requests;
using BoxBack.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountEndPoint : ApiController
    {
        private readonly GeneratorToken _generatorToken;
        private readonly BoxAppDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountEndPoint(GeneratorToken generatorToken,
                               BoxAppDbContext context,
                               SignInManager<ApplicationUser> signInManager,
                               UserManager<ApplicationUser> userManager,
                               IMapper mapper)
        {
            _generatorToken = generatorToken;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Autentica um usuário e retorna seus dados
        /// </summary>
        /// <param name="AuthenticateViewModel"></param>
        /// <returns>Um json com os dados do usuário autenticado</returns>
        /// <response code="200">Dados do usuário autenticado</response>
        /// <response code="400">Dados de usuários nulls</response>
        /// <response code="404">Usuário não encontrado</response>
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody]AuthenticateViewModel authenticateViewModel)
        {
            #region SignIn resolve
            // does sigin
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger acocunt lockout, set lockoutOnFailure: true
            var sigIn = new Microsoft.AspNetCore.Identity.SignInResult();
            try
            {
                sigIn = await _signInManager
                                    .PasswordSignInAsync(authenticateViewModel.Email,
                                                            authenticateViewModel.Password,
                                                            authenticateViewModel.RememberMe,
                                                            lockoutOnFailure: true);
                if (!sigIn.Succeeded)
                    return StatusCode(400, "Usuário ou senha inválidos.");

                if (sigIn.RequiresTwoFactor)
                {
                    // return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }

                if (sigIn.IsLockedOut)
                {
                    // _logger.LogWarning("Conta usuário bloqueada.");
                    // return RedirectToPage("./Lockout");
                }
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion
            
            #region User resolve
            var user = new ApplicationUser();
            try
            {
                user = await _context
                                    .Users
                                    .Include(x => x.ApplicationUserRoles)
                                    .ThenInclude(x => x.ApplicationRole)
                                    .Include(x => x.ApplicationUserGroups)
                                    .ThenInclude(x => x.ApplicationGroup)
                                    .FirstOrDefaultAsync(x => x.Email == authenticateViewModel.Email);
                if (user == null)
                    return StatusCode(404, "Usuário não encontrado.");
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            #region Map
            var userMapped = new ApplicationUserViewModel();
            try
            {
                userMapped = _mapper.Map<ApplicationUserViewModel>(user);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }
            #endregion

            #region Get token
            String token;
            try
            {
                token = _generatorToken.GetToken(user);
                if (string.IsNullOrEmpty(token))
                    return StatusCode(400, "Problemas ao obter token. Tente novamente, persistindo o problema informe a equipe de suporte.");
                userMapped.AccessToken = token;
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            
            #endregion
            return Ok(new { userData = userMapped });
        }

        /// <summary>
        /// Lista os dados de um usuário
        /// </summary>
        /// <param name=""></param>
        /// <returns>Um json com os dados de usuário</returns>
        /// <response code="200">Lista de dados de usuário</response>
        /// <response code="400">Lista nula</response>
        /// <response code="404">Lista vazia</response>
        [AllowAnonymous]
        [Route("me")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MeAsync()
        {
            #region Token resolve
            String token;
            try
            {
                token = HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(token))    
                    return StatusCode(400, "Não foi possível obter o token de authorização. Tente novamente, caso persista acione a equipe de suporte.");
                token = token.Replace("Bearer ", "");
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }

            var pureToken = token;  
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = new JwtSecurityToken();
            try
            {
                jwtSecurityToken = handler.ReadJwtToken(token);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }
            #endregion

            #region Get user data            
            String userId;
            try
            {
                userId = jwtSecurityToken.Payload["nameid"].ToString();
                if (string.IsNullOrEmpty(userId))
                    return StatusCode(400, "Não foi possível obter o id do usuário. Tente novamente, caso persista acione a equipe de suporte.");
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }

            var user = new ApplicationUser();
            try
            {
                user = await _context
                                    .Users
                                    .Include(x => x.ApplicationUserRoles)
                                    .ThenInclude(x => x.ApplicationRole)
                                    .Include(x => x.ApplicationUserGroups)
                                    .ThenInclude(x => x.ApplicationGroup)
                                    .FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                    return StatusCode(404, "Nenhum registro encontrado.");
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }
            #endregion

            #region Map
            var userMapped = new ApplicationUserViewModel();
            try
            {
                userMapped = _mapper.Map<ApplicationUserViewModel>(user);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }
            #endregion

            return Ok(new { userData = userMapped });
        }
    }
}