using System.Net.Mime;
using System.Numerics;
using System.Security.Cryptography;
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


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }


        public ICollection<PipelineEtapa> Etapas { get; set; }
        public ICollection<PipelineEnvolvido> Envolvidos { get; set; }
    }
}
