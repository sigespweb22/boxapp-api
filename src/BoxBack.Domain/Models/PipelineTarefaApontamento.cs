using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class PipelineTarefaApontamento : EntityAudit
    {        
        public PipelineTarefaApontamento(string titulo, string conteudo)
        {
            Titulo = titulo;
            Conteudo = conteudo;
        }

        // Constructor empty for EF
        public PipelineTarefaApontamento() {}

        public string Titulo { get; set; }
        public string Conteudo { get; set; }


        // Relationships
        [ForeignKey("PipelineTarefaId")]
        public Guid PipelineTarefaId { get; set; }
        public PipelineTarefa PipelineTarefa { get; set; }

        public ICollection<PipelineTarefaApontamentoAnexo> PipelineTarefaApontamentoAnexos { get; set; }
    }
}
