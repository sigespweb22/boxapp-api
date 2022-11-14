using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class Pipeline : EntityAudit
    {        
        public Pipeline(string nome)
        {
            Nome = nome;
        }

        // Constructor empty for EF
        public Pipeline() {}

        public string Nome { get; set; }
        public int Posicao { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }


        public ICollection<PipelineEtapa> PipelineEtapas { get; set; }
        public ICollection<PipelineAssinante> PipelineAssinantes { get; set; }
    }
}