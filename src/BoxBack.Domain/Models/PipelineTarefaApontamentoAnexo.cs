using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineTarefaApontamentoAnexo : EntityAudit
    { 
        public PipelineTarefaApontamentoAnexo(string anexo) 
        {
            Anexo = anexo;
        }

        // Constructor empty for EF
        public PipelineTarefaApontamentoAnexo() {}

        public string Anexo { get; set; }

        // Relationships
        [ForeignKey("PipelineTarefaApontamentoId")]
        public Guid PipelineTarefaApontamentoId { get; set; }
        public PipelineTarefaApontamento PipelineTarefaApontamento { get; set; }
    }
}