using System;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class ClienteServico : EntityAudit
    {        
        // Constructor empty for EF
        public ClienteServico(string nome, decimal valorVenda,
                              string caracteristicas,
                              ServicoCobrancaTipoEnum cobrancaTipo) 
        {
            Nome = nome;
            ValorVenda = valorVenda;
            Caracteristicas = caracteristicas;
            CobrancaTipo = cobrancaTipo;
        }

        // Constructor empty for EF
        public ClienteServico() {}

        public string Nome  { get; set; }
        public decimal ValorVenda { get; set; }
        public string Caracteristicas { get; set; }
        public ServicoCobrancaTipoEnum CobrancaTipo { get; set; }


        // Relationships
        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("ServicoId")]
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}