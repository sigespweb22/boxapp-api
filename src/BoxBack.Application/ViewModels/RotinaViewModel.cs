using System;
using System.Collections.Generic;

namespace BoxBack.Application.ViewModels
{
    public class RotinaViewModel
    {
        public Guid Id { get; set; }
         public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public Int32 ChaveSequencial { get; set; }
        public string DispatcherRoute { get; set; }
        public string Periodicidade { get; set; }
        public string HoraExecucao { get; set; }

        // dados do último evento da rotina
        public string DataCriacaoUltimoEvento { get; set; }
        public string StatusUltimoEvento { get; set; }
        public string TotalItensInsucessoUltimoEvento { get; set; }
        public string TotalItensSucessoUltimoEvento { get; set; }
        public string ExceptionMessageUltimoEvento { get; set; }
        public string DataCompetenciaInicio { get; set; }
        public string DataCompetenciaFim { get; set; }
        public string Status { get; set; }
        public Property Property { get; set; }
        public Guid? PropertyId { get; set; }

        public ICollection<RotinaEventHistoryViewModel> RotinasEventsHistories { get; set; }
    }

    public class Property
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}