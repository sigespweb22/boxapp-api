using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels.Requests
{
    public class AuthenticateViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-mail requerido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha requerida.")]
        [DisplayName("Senha")]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}