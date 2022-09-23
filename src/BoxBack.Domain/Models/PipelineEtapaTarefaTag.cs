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
        // Constructor empty for EF
        public PipelineEtapaTarefaTag() {}

        // Relationships
        [ForeignKey("TarefaTagId")]
        public Guid TarefaTagId { get; set; }
        public TarefaTag TarefaTag { get; set; }

        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }
    }
}
