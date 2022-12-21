using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class Rotina : EntityAudit
    {
        public Rotina(string nome, string descricao) 
        {
            Nome = nome;
            Descricao = descricao;
        }

        // Constructor empty to EFCore
        public Rotina() {}

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        // Relationships
        public ICollection<RotinaEventHistory> RotinasEventsHistories { get; set; }

        [ForeignKey("TenantId")]
        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; }
    }
}