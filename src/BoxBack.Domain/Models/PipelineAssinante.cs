using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Models
{
    public class PipelineAssinante : EntityAudit
    {        
        public PipelineAssinante(string fullName, AssinaturaTipoEnum tipo)
        {
            FullName = fullName;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineAssinante() {}

        public string FullName { get; set; }
        public AssinaturaTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineId")]
        public Guid PipelineId { get; set; }
        public Pipeline Pipeline { get; set; }
    }
}