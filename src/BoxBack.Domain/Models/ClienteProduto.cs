using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class ClienteProduto : EntityAudit
    {        
        // Constructor empty for EF
        public ClienteProduto(string nome, decimal valorVenda,
                              string caracteristicas) 
        {
            Nome = nome;
            ValorVenda = valorVenda;
            Caracteristicas = caracteristicas;
        }

        // Constructor empty for EF
        public ClienteProduto() {}

        public string Nome  { get; set; }
        public decimal ValorVenda { get; set; }
        public string Caracteristicas { get; set; }


        // Relationships
        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("ProdutoId")]
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}