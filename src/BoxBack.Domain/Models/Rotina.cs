using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

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

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public Int32 ChaveSequencial { get; set; }
        public string DispatcherRoute { get; set; }
        public DateTime DataCompetenciaInicio { get; set; }
        public DateTime DataCompetenciaFim { get; set; }
        public Guid? PropertyId { get; set;}
        public PeriodicidadeEnum Periodicidade { get; set; }
        public DateTime HoraExecucao { get; set; }


        // Relationships
        public ICollection<RotinaEventHistory> RotinasEventsHistories { get; set; }

        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}