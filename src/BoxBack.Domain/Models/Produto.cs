using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class Produto : EntityAudit
    {        
        public Produto(string nome, string codigoUnico,
                       decimal valorCusto, string caracteristicas, 
                       string descricao)
        {
            Nome = nome;
            CodigoUnico = codigoUnico;
            ValorCusto = valorCusto;
            Caracteristicas = caracteristicas;
            Descricao = descricao;
        }

        // Constructor empty for EF
        public Produto() {}

        public string Nome { get; set; }
        public string CodigoUnico { get; set; }
        public decimal ValorCusto { get; set; }
        public string Caracteristicas { get; set; }
        public string Descricao { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [ForeignKey("FornecedorProdutoId")]
        public Guid FornecedorProdutoId { get; set; }
        public FornecedorProduto FornecedorProduto { get; set; }

        public ICollection<ClienteProduto> ClienteProdutos { get; set; }
    }
}