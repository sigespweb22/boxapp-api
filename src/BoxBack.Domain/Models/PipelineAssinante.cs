using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
namespace BoxBack.Domain.Models
{
    public class PipelineAssinante : EntityAudit
    {        
        public PipelineAssinante(AssinaturaTipoEnum tipo)
        {
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineAssinante() {}

        public AssinaturaTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineId")]
        public Guid PipelineId { get; set; }
        public Pipeline Pipeline { get; set; }
    }
}