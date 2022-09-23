using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaApontamentoAnexo : EntityAudit
    { 
        public PipelineEtapaTarefaApontamentoAnexo(string anexo) 
        {
            Anexo = anexo;
        }


        // Constructor empty for EF
        public PipelineEtapaTarefaApontamentoAnexo() {}

        public string Anexo { get; set; }

        // Relationships
        [ForeignKey("PipelineEtapaTarefaApontamentoId")]
        public Guid PipelineEtapaTarefaApontamentoId { get; set; }
        public PipelineEtapaTarefaApontamento PipelineEtapaTarefaApontamento { get; set; }
    }
} 