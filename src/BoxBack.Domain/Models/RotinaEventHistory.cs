using System;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class RotinaEventHistory : EntityAudit
    {
        public RotinaEventHistory(DateTimeOffset dataInicio, DateTimeOffset dataFim,
                                  RotinaStatusProgressoEnum statusProgresso) 
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            StatusProgresso = statusProgresso;
        }

        // Constructor empty to EFCore
        public RotinaEventHistory() {}

        
        
        public DateTimeOffset DataInicio { get; private set; }
        public DateTimeOffset DataFim { get; private set; }
        public RotinaStatusProgressoEnum StatusProgresso { get; private set; }



        // Relationships
        [ForeignKey("RotinaId")]
        public Guid RotinaId { get; private set; }
        public Rotina Rotina { get; private set; }
    }
}