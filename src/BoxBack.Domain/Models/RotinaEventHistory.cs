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

        
        
        public DateTimeOffset DataInicio { get; set; }
        public DateTimeOffset DataFim { get; set; }
        public RotinaStatusProgressoEnum StatusProgresso { get; set; }



        // Relationships
        [ForeignKey("RotinaId")]
        public Guid RotinaId { get; set; }
        public Rotina Rotina { get; set; }
    }
}