using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get;set; } 
        public string UserId { get;set; }
        public string UserName { get; set; }

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

        public List<string> ApplicationUserRoles { get; set; }
        public List<string> Role { get; set; }

        [Required, MinLength(1, ErrorMessage = "\nGrupo usuário é requerido.")]
        public List<ApplicationUserGroupViewModel> ApplicationUserGroups { get; set; } 
        public List<string> ApplicationUserGroupsNames { get; set; }
    }
}