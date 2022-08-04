using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BoxBack.Application.Interfaces;
using BoxBack.Domain.Models;
using BoxBack.WebApi.Extensions;

namespace BoxBack.WebApi.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContaUsuarioAppService _contaUsuarioManager;

        public ForgotPasswordModel(SignInManager<ApplicationUser> signInManager, 
                                    ILogger<LogoutModel> logger,
                                    UserManager<ApplicationUser> userManager, 
                                    IContaUsuarioAppService contaUsuarioManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _contaUsuarioManager = contaUsuarioManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task OnGet()
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation("Usuário deslogado.");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager
                                        .FindByEmailAsync(Input.Email);

                    var contaUsuario = _contaUsuarioManager.GetByUserId(user.Id);

                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        return RedirectToPage("./ForgotPasswordConfirmation");
                    }

                    // For more information on how to enable account confirmation and password reset please 
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new { code },
                        protocol: Request.Scheme);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new System.Net.Mail.MailAddress("aspenetcore@hotmail.com");
                        mail.CC.Add(new System.Net.Mail.MailAddress(user.Email));
                        mail.Subject = "BoxBackWeb - Link para troca de senha";
                        mail.Body = "Prezado (a) " + contaUsuario.Nome + " ," + $" para redefinir sua senha copie e cole o link em seu navegador => {HtmlEncoder.Default.Encode(callbackUrl)}";
                        //Cópia oculta
                        // mail.Bcc.Add(new System.Net.Mail.MailAddress(textBoxCCo.Text));
                        EmailExtensions.SendEmail(mail);
                    }

                    // await _emailSender.SendEmailAsync(
                    //     Input.Email,
                    //     "Redefinição senha",
                    //     $"Por favor redefina sua senha a partir no link a seguir <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                return Page();
            }
            catch { throw; }            
        }
    }
}
