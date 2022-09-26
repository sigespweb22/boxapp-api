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
        public PipelineEtapaTarefaAssinante(string fullName, AssinaturaTipoEnum tipo)
        {
            FullName = fullName;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineEtapaTarefaAssinante() {}

        public string FullName { get; set; }
        public AssinaturaTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }
    }
}
