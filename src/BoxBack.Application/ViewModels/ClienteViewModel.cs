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
        [StringLength(255, MinimumLength = 3, ErrorMessage = "\nNome fantasia deve possuir entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "\nRazão social é requerida.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "\nRazão social deve possuir entre 3 e 255 caracteres.")]
        public string RazaoSocial { get; set; }
        
        [StringLength(14, MinimumLength = 0, ErrorMessage = "\nInscrição estadual deve possuir 14 caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "\nCNPJ é requerido.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "\nCNPJ deve possuir 14 caracteres.")]
        public string CNPJ { get; set; }
        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public string Observacao { get; set; }
        public string DataFundacao { get; set; }
        private int _codigoMunicipio = 0;
        public int CodigoMunicio { get { return _codigoMunicipio; }  set { _codigoMunicipio = value; }}
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Status { get; set; }
    }
}