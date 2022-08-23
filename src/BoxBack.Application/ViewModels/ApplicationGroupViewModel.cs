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
    public class ApplicationGroupViewModel
    {
        public string Id { get;set; }

        [Required(ErrorMessage = "Nome do grupo é requerido.")]
        public string Name { get;set; } 
        public string Status { get; set; }

        [Required, MinLength(1, ErrorMessage = "Ao menos uma permissão é requerida.")]
        public List<string> ApplicationRoleGroups { get; set; }
        
        public List<string> ApplicationRoleGroupsNames { get; set; }
    }
}