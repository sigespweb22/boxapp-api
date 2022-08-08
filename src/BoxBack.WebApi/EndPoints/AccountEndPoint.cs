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

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountEndPoint : ApiController
    {
        private readonly GeneratorToken _generatorToken;
        private readonly BoxAppDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountEndPoint(GeneratorToken generatorToken,
                               BoxAppDbContext context,
                               SignInManager<ApplicationUser> signInManager)
        {
            _generatorToken = generatorToken;
            _context = context;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody]AuthenticateViewModel authenticateViewModel)
        {
            authenticateViewModel.UserName = authenticateViewModel.Email;
            
            // does sigin
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger acocunt lockout, set lockoutOnFailure: true
            var sigIn = new Microsoft.AspNetCore.Identity.SignInResult();
            try
            {
                sigIn = await _signInManager
                                    .PasswordSignInAsync(authenticateViewModel.UserName,
                                                            authenticateViewModel.Password,
                                                            authenticateViewModel.RememberMe,
                                                            lockoutOnFailure: true);    
            }
            catch { throw; }
            
            var result = new ApplicationUserViewModel();
            var user = new ApplicationUser();
            try
            {
                user = _context
                            .Users
                            .Include(x => x.ApplicationUserRoles)
                            .Include(x => x.ContaUsuario)
                            .Where(x => x.UserName == authenticateViewModel.UserName).FirstOrDefault();
                
            }
            catch { throw; }

            if (sigIn.Succeeded)
            {
                
                if (user == null)
                {
                    return BadRequest(new {
                        Message = "Problemas ao obter o usuário para retornar um token. Tente novamente.",
                        Success = false
                    });
                }
                    
                result = _generatorToken.GetToken(user);
            }
            else
            {
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            }

            if (sigIn.RequiresTwoFactor)
            {
                // return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            }

            if (sigIn.IsLockedOut)
            {
                // _logger.LogWarning("Conta usuário bloqueada.");
                // return RedirectToPage("./Lockout");
            }

            return Ok(result);
        }

        /// <summary>
        /// Lista as opções de menu do usuário
        /// </summary>s
        /// <param name=""></param>
        /// <returns>Um json com os itens de menu</returns>
        /// <response code="200">Lista de itens</response>
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
            String token;
            try
            {
                token = HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(token))
                   return StatusCode(400, "Não foi possível obter o token de authorização. Tente novamente, caso persista acione a equipe de suporte.");
            }
            catch (Exception ex) { return StatusCode(500, ex.Message ); }

            //             {
            // 	email: "alan.rezende@boxtecnologia.com.br"
            // 	fullName: "Alan Rezende"
            // 	id: "8e445865-a24d-4543-a6c6-9443d048cdb9"
            // 	role: "suporte"
            //         username: "alan.rezende@boxtecnologia.com.br"
            // }

            // does sigin
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger acocunt lockout, set lockoutOnFailure: true
            var user = new ApplicationUser();
            user.ContaUsuario = new ContaUsuario();

            // try
            // {
            //     user = _userManager
            // }

            // catch { throw; }
            
            
            return Ok();
        }
    }
}