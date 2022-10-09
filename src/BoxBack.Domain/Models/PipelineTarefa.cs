using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineTarefa : EntityAudit
    {        
        public PipelineTarefa(string titulo, string descricao,
                              int posicao, DateTime dataConclusao,
                              TarefaTipoEnum tipo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Posicao = posicao;
            DataConclusao = dataConclusao;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineTarefa() {}

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Posicao { get; set; }
        public DateTime DataConclusao { get; set; }
        public TarefaTipoEnum Tipo { get; set; }
        public TarefaStatusEnum Status { get; set; }

 
        // Relationships
        [ForeignKey("PipelineEtapaId")]
        public Guid PipelineEtapaId { get; set; }
        public PipelineEtapa PipelineEtapa { get; set; }

        public ICollection<PipelineTarefaAssinante> PipelineTarefaAssinantes { get; set; }
        public ICollection<PipelineTarefaApontamento> PipelineTarefaApontamentos { get; set; }
        public ICollection<PipelineTarefaAnexo> PipelineTarefaAnexos { get; set; }
        public ICollection<PipelineTarefaTag> PipelineTarefaTags { get; set; }
    }
}
