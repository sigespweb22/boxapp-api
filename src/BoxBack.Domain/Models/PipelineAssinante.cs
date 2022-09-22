using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class PipelineAssinante : EntityAudit
    {        
        public PipelineAssinante(EnvolvidoTipoEnum tipo)
        {
            Tipo = tipo;
        }

        // Constructor empty for EF
        public PipelineAssinante() {}

        public EnvolvidoTipoEnum Tipo { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa Tarefa { get; set; }
    }
}
