using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaApontamento : EntityAudit
    {        
        public PipelineEtapaTarefaApontamento(string titulo, string conteudo)
        {
            Titulo = titulo;
            Conteudo = conteudo;
        }

        // Constructor empty for EF
        public PipelineEtapaTarefaApontamento() {}

        public string Titulo { get; set; }
        public string Conteudo { get; set; }


        // Relationships
        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }

        public ICollection<PipelineEtapaTarefaApontamentoAnexo> Anexos { get; set; }
    }
}
