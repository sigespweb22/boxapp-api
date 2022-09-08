using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ClienteAtivo
    {        
        // Constructor empty for EF
        public ClienteAtivo(decimal valorCusto, decimal valorVenda,
                            string caracteristica, string observacao) 
        {
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
            Caracteristica = caracteristica;
            Observacao = observacao;
        }

        // Constructor empty for EF
        public ClienteAtivo() {}

        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public string Caracteristica { get; set; }
        public string Observacao { get; set; }

        // Relationships
        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("AtivoId")]
        public Guid AtivoId { get; set; }
        public Ativo Ativo { get; set; }

        
    }
}