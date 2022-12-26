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
        public Int32 TotalItensSucesso { get; set;}
        public Int32 TotalItensInsucesso { get; set;}
        public string ExceptionMensagem { get; set; }


        // Relationships
        [ForeignKey("RotinaId")]
        public Guid RotinaId { get; set; }
        public Rotina Rotina { get; set; }
    }
}