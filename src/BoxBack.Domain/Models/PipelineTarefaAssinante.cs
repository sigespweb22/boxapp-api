using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
namespace BoxBack.Domain.Models
{
    public class PipelineTarefaAssinante : EntityAudit
    {        
        public PipelineTarefaAssinante(string fullName, AssinaturaTipoEnum tipo)
        {
            FullName = fullName;
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineTarefaAssinante() {}

        public string FullName { get; set; }
        public AssinaturaTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineTarefaId")]
        public Guid PipelineTarefaId { get; set; }
        public PipelineTarefa PipelineTarefa { get; set; }
    }
}
