using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineTarefaTag : EntityAudit
    {   
        public PipelineTarefaTag(string nome) 
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        // Constructor empty for EF
        public PipelineTarefaTag() {}

        // Relationships
        [ForeignKey("PipelineTarefaId")]
        public Guid PipelineTarefaId { get; set; }
        public PipelineTarefa PipelineTarefa { get; set; }
        

        [ForeignKey("TarefaTagId")]
        public Guid TarefaTagId { get; set; }
        public TarefaTag TarefaTag { get; set; }
    }
}
