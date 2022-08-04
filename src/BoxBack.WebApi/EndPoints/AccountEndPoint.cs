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
    }
}