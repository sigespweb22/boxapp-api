using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class PipelineEtapa : EntityAudit
    {        
        public PipelineEtapa(string nome)
        {
            Nome = nome;
        }

        // Constructor empty for EF
        public PipelineEtapa() {}

        public string Nome { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
