using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Models
{
    public class FornecedorSolucao : EntityAudit
    {        
        public FornecedorSolucao(string descricao, decimal valor,
                                 ServicoProdutoEnum tipo)
        {
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public FornecedorSolucao() {}

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ServicoProdutoEnum Tipo { get; set; }
 

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [ForeignKey("FornecedorId")]
        public Guid FornecedorId { get; set; } 
        public Fornecedor Fornecedor { get; set; }
    }
}
