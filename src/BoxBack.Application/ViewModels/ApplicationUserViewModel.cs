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
        public string Email { get; set; }
        public string Password { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Funcao { get; set; }
        public string Setor { get; set; }
        public string PerfilFoto { get; set; }
        public string Nome { get; set; }
        public string AccessToken { get; set; }
        public bool RememberMe { get; set; }

        public List<string> Setores { get; set; }
        public List<string> Funcoes { get; set; }

        public List<string> ApplicationUserRoles { get; set; }
        
        public string ContaUsuarioNome { get; set; }
        public virtual ContaUsuarioViewModel ContaUsuarioViewModel { get; set; }
    }
}