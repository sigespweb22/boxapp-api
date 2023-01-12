using System;

namespace BoxBack.Application.ViewModels
{
    public class RotinaEventHistoryViewModel
    {
        public Guid Id { get; set; }

        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string StatusProgresso { get; set; }
        public Int32 TotalItensSucesso { get; set;}
        public Int32 TotalItensInsucesso { get; set;}
        public string ExceptionMensagem { get; set; }

        public Guid RotinaId { get; set; }
        public RotinaViewModel RotinaViewModel { get; set; }
    }
}