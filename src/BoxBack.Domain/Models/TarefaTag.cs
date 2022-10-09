using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace BoxBack.Domain.Models
{
    public class TarefaTag : EntityAudit
    {        
        public TarefaTag(string nome)
        {
            Nome = nome;
        }

        // Constructor empty for EF
        public TarefaTag() {}

        public string Nome { get; set; }

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        
        public ICollection<PipelineTarefaTag> PipelineTarefaTags { get; set; }
    }
} 