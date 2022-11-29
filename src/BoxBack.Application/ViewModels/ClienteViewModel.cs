using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BoxBack.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid? Id { get; set; }
        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "\nNome fantasia é requerido.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "\nNome fantasia deve possuir entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }
        
        public string InscricaoEstadual { get; set; }

        public string CNPJ { get; set; }
        public string Cpf { get; set; }

        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public string Observacao { get; set; }
        public string DataFundacao { get; set; }
        private int _codigoMunicipio = 0;
        public int codigoMunicipio { get { return _codigoMunicipio; }  set { _codigoMunicipio = value; }}
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public ICollection<ClienteContratoViewModel> Contratos { get; set; }
    }
}