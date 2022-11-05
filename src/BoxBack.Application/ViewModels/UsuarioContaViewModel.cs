using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class UsuarioContaViewModel
    {
        public string Id { get;set; }
        public string Avatar { get;set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string FullName { get; set; }

        public List<ApplicationUserGroupViewModel> ApplicationUserGroups { get; set; } 
    }
}