// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.Extensions.Logging;
// using BoxBack.Application.ViewModels;
// using BoxBack.Domain.Models;
// using BoxBack.Domain.Interfaces;
// using BoxBack.Infra.CrossCutting.Identity.Services;
// using AutoMapper;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;

// namespace BoxBack.WebApi.Areas.Identity.Pages.Account
// {
//     [AllowAnonymous]
//     public class LoginModel : PageModel
//     {
//         private readonly UserManager<ApplicationUser> _userManager;
//         private readonly SignInManager<ApplicationUser> _signInManager;
//         private readonly ILogger<LoginModel> _logger;
//         private readonly IContaUsuarioRepository _contaUsuarioRepository;
//         private readonly IMapper _mapper;
//         private readonly IHttpContextAccessor _httpContextAccessor;
//         private ISession _session => _httpContextAccessor.HttpContext.Session;

//         public LoginModel(UserManager<ApplicationUser> userManager,
//                             SignInManager<ApplicationUser> signInManager, 
//                             ILogger<LoginModel> logger,
//                             IContaUsuarioRepository contaUsuarioRepository,
//                             IMapper mapper,
//                             UserResolverService userResolverService,
//                             IHttpContextAccessor httpContextAccessor)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//             _logger = logger;
//             _contaUsuarioRepository = contaUsuarioRepository;
//             _mapper = mapper;
//             _httpContextAccessor = httpContextAccessor;
//         }

//         [BindProperty]
//         public InputModel Input { get; set; }

//         public IList<AuthenticationScheme> ExternalLogins { get; set; }

//         public string ReturnUrl { get; set; }

//         [TempData]
//         public string ErrorMessage { get; set; }

//         public class InputModel
//         {
//             [Required]
//             [EmailAddress]
//             public string Email { get; set; }

//             [Required]
//             [DataType(DataType.Password)]
//             public string Password { get; set; }

//             [Display(Name = "Remember me?")]
//             public bool RememberMe { get; set; }
//         }

//         public async Task OnGetAsync(string returnUrl = null)
//         {
//             if (!string.IsNullOrEmpty(ErrorMessage))
//             {
//                 ModelState.AddModelError(string.Empty, ErrorMessage);
//             }

//             returnUrl = returnUrl ?? Url.Content("~/");

//             // Clear the existing external cookie to ensure a clean login process
//             await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

//             ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

//             ReturnUrl = returnUrl;
//         }

//         public async Task<IActionResult> OnPostAsync(string returnUrl = null)
//         {
//             returnUrl = returnUrl ?? Url.Content("~/");

//             if (ModelState.IsValid)
//             {
//                 // This doesn't count login failures towards account lockout
//                 // To enable password failures to trigger acocunt lockout, set lockoutOnFailure: true
//                 var result = await _signInManager
//                                         .PasswordSignInAsync(Input.Email, 
//                                                              Input.Password, 
//                                                              Input.RememberMe, 
//                                                              lockoutOnFailure: true);

//                 if (result.Succeeded)
//                 {
//                     _logger.LogInformation("Usuário logado.");

//                     return LocalRedirect(returnUrl);
//                 }
//                 if (result.RequiresTwoFactor)
//                 {
//                     return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
//                 }
//                 if (result.IsLockedOut)
//                 {
//                     _logger.LogWarning("Conta usuário bloqueada.");
//                     return RedirectToPage("./Lockout");
//                 }
//                 else
//                 {
//                     ModelState.AddModelError(string.Empty, "Usuário ou senha inválido (s).");
//                     return Page();
//                 }
//             }

//             // If we got this far, something failed, redisplay form
//             return Page();
//         }
//     }
// }
