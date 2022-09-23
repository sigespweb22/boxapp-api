using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefa : EntityAudit
    {        
        public PipelineEtapaTarefa(string nome, string descricao,
                                   int posicao, DateTime dataConclusao,
                                   TarefaTipoEnum tipo)
        {
            Nome = nome;
            Descricao = descricao;
            Posicao = posicao;
            DataConclusao = dataConclusao;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineEtapaTarefa() {}

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Posicao { get; set; }
        public DateTime DataConclusao { get; set; }
        public TarefaTipoEnum Tipo { get; set; }

 
        // Relationships
        [ForeignKey("PipelineEtapaId")]
        public Guid PipelineEtapaId { get; set; }
        public PipelineEtapa PipelineEtapa { get; set; }

        public ICollection<PipelineEtapaTarefaAssinante> Assinantes { get; set; }
        public ICollection<PipelineEtapaTarefaApontamento> Apontamentos { get; set; }
        public ICollection<PipelineEtapaTarefaAnexo> Anexos { get; set; }
        public ICollection<PipelineEtapaTarefaTag> Tags { get; set; }
    }
}
