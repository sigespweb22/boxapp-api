using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapaTarefaAnexo : EntityAudit
    { 
        public PipelineEtapaTarefaAnexo(string anexo) 
        {
            Anexo = anexo;
        }


        // Constructor empty for EF
        public PipelineEtapaTarefaAnexo() {}

        public string Anexo { get; set; }

        // Relationships
        [ForeignKey("PipelineEtapaTarefaId")]
        public Guid PipelineEtapaTarefaId { get; set; }
        public PipelineEtapaTarefa PipelineEtapaTarefa { get; set; }
        

        [ForeignKey("PipelineEtapaTarefaApontamentoId")]
        public Guid? PipelineEtapaTarefaApontamentoId { get; set; }
        public PipelineEtapaTarefaApontamento PipelineEtapaTarefaApontamento { get; set; }
    }
}