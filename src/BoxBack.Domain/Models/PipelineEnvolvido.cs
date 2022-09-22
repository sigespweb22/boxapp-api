using System.Net.Mime;
using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineEnvolvido : EntityAudit
    {        
        public PipelineEnvolvido(EnvolvidoTipoEnum tipo)
        {
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineEnvolvido() {}

        public EnvolvidoTipoEnum Tipo { get; set; }


        // Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineId")]
        public Guid PipelineId { get; set; }
        public Pipeline Pipeline { get; set; }
    }
}
