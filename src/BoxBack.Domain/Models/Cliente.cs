using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class Cliente : EntityAudit
    {        
        public Cliente(string nomeFantasia, string razaoSocial, string inscricaoEstadual,
                       string cnpj, string telefonePrincipal, string emailPrincipal, string observacao,
                       DateTimeOffset dataFundacao, int codigoMunicipio, string rua, string numero, string complemento,
                       string cidade, string estado, string cep,
                       string cpf)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;
            CNPJ = cnpj;
            TelefonePrincipal = telefonePrincipal;
            EmailPrincipal = emailPrincipal;
            Observacao = observacao;
            DataFundacao = dataFundacao;
            CodigoMunicipio = codigoMunicipio;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Cpf = cpf;
        }

        // Constructor empty for EF
        public Cliente() {}

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CNPJ { get; set; }
        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public string Observacao { get; set; }
        public DateTimeOffset? DataFundacao { get; set; }
        public int? CodigoMunicipio { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public TipoPessoaEnum? TipoPessoa { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<ClienteServico> ClienteServicos { get; set; }
        public ICollection<ClienteProduto> ClienteProdutos { get; set; }
        public ICollection<ClienteContrato> ClienteContratos { get; set; }
    }
}
