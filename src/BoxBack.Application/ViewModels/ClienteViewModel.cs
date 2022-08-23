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
    public class ClienteViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome fantasia é requerido.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Razão social é requerida.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Cnpj é requerido.")]
        public string Cnpj { get; set; }

        public string Status { get; set; }
    }
}