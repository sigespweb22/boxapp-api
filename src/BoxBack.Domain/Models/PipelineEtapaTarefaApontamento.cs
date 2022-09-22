using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaApontamento : EntityAudit
    {        
        public PipelineEtapaTarefaApontamento(string titulo, string descricao,
                                              int posicao,
                                              int alertaEstagnacao)
        {
            Nome = nome;
            Descricao = descricao;
            Posicao = posicao;
            AlertaEstagnacao = alertaEstagnacao;
        }

        // Constructor empty for EF
        public PipelineEtapaTarefaApontamento() {}

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Posicao { get; set; }
        public int AlertaEstagnacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public TarefaTipoEnum Tipo { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [ForeignKey("PipelineId")]
        public Guid PipelineId { get; set; }
        public PipelineEnvolvido Pipeline { get; set; }
    }
}
