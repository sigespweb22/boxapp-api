using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaAssinante : EntityAudit
    {        
        public PipelineEtapaTarefaAssinante(AssinaturaTipoEnum tipo)
        {
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineEtapaTarefaAssinante() {}

        public AssinaturaTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }
    }
}
