using System;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class RotinaEventHistory : EntityAudit
    {
        public RotinaEventHistory(DateTimeOffset dataInicio, DateTimeOffset dataFim,
                                  RotinaStatusProgressoEnum statusProgresso,
                                  Int32 totalItensSucesso, Int32 totalItensInsucesso,
                                  string exceptionMensagem) 
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            TotalItensSucesso = totalItensSucesso;
            TotalItensInsucesso = totalItensInsucesso;
            ExceptionMensagem = exceptionMensagem;
            StatusProgresso = statusProgresso;
        }

        // Constructor empty to EFCore
        public RotinaEventHistory() {}

        
        
        public DateTimeOffset DataInicio { get; set; }
        public DateTimeOffset DataFim { get; set; }
        public RotinaStatusProgressoEnum StatusProgresso { get; set; }
        public Int64 TotalItensSucesso { get; set;}
        public Int64 TotalItensInsucesso { get; set;}
        public string ExceptionMensagem { get; set; }


        // Relationships
        [ForeignKey("RotinaId")]
        public Guid RotinaId { get; set; }
        public Rotina Rotina { get; set; }
    }
}