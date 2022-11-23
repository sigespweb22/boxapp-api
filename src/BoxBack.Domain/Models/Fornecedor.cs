using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class Fornecedor : EntityAudit
    {        
        public Fornecedor(string nomeFantasia, string razaoSocial, string inscricaoEstadual,
                          string cnpj, string telefonePrincipal, string emailPrincipal,
                          int codigoMunicipio, string rua, string numero, string complemento,
                          string cidade, string estado, string cep, string observacao)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            TelefonePrincipal = telefonePrincipal;
            EmailPrincipal = emailPrincipal;
            CodigoMunicipio = codigoMunicipio;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Observacao = observacao;
        }

        // Constructor empty for EF
        public Fornecedor() {}

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Cnpj { get; set; }
        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public int? CodigoMunicipio { get; set; }
        public string Rua { get; set; } 
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Observacao { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<FornecedorServico> FornecedorServicos { get; set; }
        public ICollection<FornecedorProduto> FornecedorProdutos { get; set; }
    }
}
