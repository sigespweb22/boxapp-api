using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class Servico : EntityAudit
    {        
        public Servico(string nome, string codigoUnico,
                       decimal valorCusto, string caracteristicas, 
                       ServicoUnidadeMedidaEnum unidadeMedida)
        {
            Nome = nome;
            CodigoUnico = codigoUnico;
            ValorCusto = valorCusto;
            Caracteristicas = caracteristicas;
            UnidadeMedida = unidadeMedida;
        }

        // Constructor empty for EF
        public Servico() {}

        public string Nome { get; set; }
        public string CodigoUnico { get; set; }
        public decimal ValorCusto { get; set; }
        public string Caracteristicas { get; set; }
        public ServicoUnidadeMedidaEnum UnidadeMedida { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [ForeignKey("FornecedorServicoId")]
        public Guid FornecedorServicoId { get; set; }
        public FornecedorServico FornecedorServico { get; set; }

        public ICollection<ClienteServico> ClienteServicos { get; set; }
    }
}