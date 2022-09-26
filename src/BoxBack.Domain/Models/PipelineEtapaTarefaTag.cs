using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaTag : EntityAudit
    {   
        public PipelineEtapaTarefaTag(string nome) 
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        // Constructor empty for EF
        public PipelineEtapaTarefaTag() {}

        // Relationships
        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }
        

        [ForeignKey("TarefaTagId")]
        public Guid TarefaTagId { get; set; }
        public TarefaTag TarefaTag { get; set; }
    }
}
