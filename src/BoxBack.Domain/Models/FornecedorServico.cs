
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
public class FornecedorServico : EntityAudit
    {
        public FornecedorServico(string nome, string codigoServico,
                                 ServicoUnidadeMedidaEnum unidadeMedida, 
                                 string caracteristicas)
        {
            Nome = nome;
            CodigoServico = codigoServico;
            UnidadeMedida = unidadeMedida;
            Caracteristicas = caracteristicas;
        }

        // Constructor empty to EFCore 
        public FornecedorServico() {}


        public string Nome  { get; set; }
        public string CodigoServico { get; set; }
        public ServicoUnidadeMedidaEnum UnidadeMedida { get; set; }
         public string Caracteristicas { get; set; }

        // Relationships
        [ForeignKey("FornecedorId")]
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
 
        public ICollection<Servico> Servicos { get; set; }
    }
} 