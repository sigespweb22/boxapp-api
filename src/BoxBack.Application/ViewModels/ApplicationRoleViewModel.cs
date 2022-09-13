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
    public class ApplicationRoleViewModel
    {

        public string Id { get;set; } 

        [Required(ErrorMessage = "\nNome é requerido.")]
        public string Name { get;set; }

        public string NormalizedName { get;set; }
        public string ConcurrencyStamp { get;set; }

        [Required(ErrorMessage = "\nDescrição é requerida.")]
        public string Description { get; set; }
    }
}