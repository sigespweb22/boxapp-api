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

        [Required(ErrorMessage = "\nNome fantasia é requerido.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "\nNome fantasia deve possuir entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "\nRazão social é requerida.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "\nRazão social deve possuir entre 3 e 255 caracteres.")]
        public string RazaoSocial { get; set; }
        
        [StringLength(14, MinimumLength = 6, ErrorMessage = "\nInscrição estadual deve possuir entre 3 e 14 caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "\nCNPJ é requerido.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "\nCNPJ deve possuir 14 caracteres.")]
        public string Cnpj { get; set; }
        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public string Observacao { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Status { get; set; }
    }
}