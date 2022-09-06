using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class Fornecedor : EntityAudit
    {        
        public Fornecedor(string nomeFantasia, string razaoSocial,
                          string cnpj, string telefonePrincipal, string emailPrincipal,
                          string observacao, string cidade, string estado)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            TelefonePrincipal = telefonePrincipal;
            EmailPrincipal = emailPrincipal;
            Observacao = observacao;
            Cidade = cidade;
            Estado = estado;
        }

        // Constructor empty for EF
        public Fornecedor() {}

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string TelefonePrincipal { get; set; }
        public string EmailPrincipal { get; set; }
        public string Observacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<FornecedorServico> Servicos { get; set; }
    }
}
