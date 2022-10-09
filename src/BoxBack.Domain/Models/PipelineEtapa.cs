using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapa : EntityAudit
    {        
        public PipelineEtapa(string nome, string descricao, int posicao,
                             int alertaEstagnacao)
        {
            Nome = nome;
            Descricao = descricao;
            Posicao = posicao;
            AlertaEstagnacao = alertaEstagnacao;
        }

        // Constructor empty for EF
        public PipelineEtapa() {}

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Posicao { get; set; }
        public int AlertaEstagnacao { get; set; }


        // Relationships
        [ForeignKey("PipelineId")]
        public Guid PipelineId { get; set; }
        public Pipeline Pipeline { get; set; }
        
        public ICollection<PipelineTarefa> PipelineTarefas { get; set; }
    }
}
