using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Models;

namespace BoxBack.Application.ViewModels
{
    public class ApplicationUserUpdateViewModel
    {
        public string Id { get;set; }
        public string UserId { get;set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }

        [Required(ErrorMessage = "\nE-mail é requerido.")]
        public string Email { get; set; }
        
        public string Password { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Funcao { get; set; }
        public string Setor { get; set; }
        public string Avatar { get; set; }

        [Required(ErrorMessage = "\nNome completo é requerido.")]
        public string FullName { get; set; }
        public string AccessToken { get; set; }
        public bool RememberMe { get; set; }
        public string Status { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }


        [MinLength(1, ErrorMessage = "\nAo menos um grupo é requerido.")]
        public List<ApplicationUserGroupUpdateViewModel> ApplicationUserGroups { get; set; } 
    }
}