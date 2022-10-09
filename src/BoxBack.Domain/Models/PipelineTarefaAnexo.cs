using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineTarefaAnexo : EntityAudit
    { 
        public PipelineTarefaAnexo(string anexo) 
        {
            Anexo = anexo;
        }


        // Constructor empty for EF
        public PipelineTarefaAnexo() {}

        public string Anexo { get; set; }

        // Relationships
        [ForeignKey("PipelineTarefaId")]
        public Guid PipelineTarefaId { get; set; }
        public PipelineTarefa PipelineTarefa { get; set; }
    }
}