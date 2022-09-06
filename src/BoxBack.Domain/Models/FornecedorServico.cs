using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class FornecedorServico : EntityAudit
    {        
        public FornecedorServico(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        // Constructor empty for EF
        public FornecedorServico() {}

        public string Descricao { get; set; }
        public decimal Valor { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [ForeignKey("FornecedorId")]
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
