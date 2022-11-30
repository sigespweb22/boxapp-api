
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
public class FornecedorProduto : EntityAudit
    {
        public FornecedorProduto(string nome, string codigoProduto,
                                 string caracteristicas)
        {
            Nome = nome;
            CodigoProduto = codigoProduto;
            Caracteristicas = caracteristicas;
        }

        // Constructor empty to EFCore 
        public FornecedorProduto() {}

        public string Nome  { get; set; }
        public string CodigoProduto { get; set; }
         public string Caracteristicas { get; set; }

        // Relationships
        [ForeignKey("FornecedorId")]
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
 
        public ICollection<Produto> Produtos { get; set; }
    }
} 