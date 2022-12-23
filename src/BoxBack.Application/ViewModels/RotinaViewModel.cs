using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class RotinaViewModel
    {
        public Guid? Id { get; set; }
         public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public Int32 ChaveSequencial { get; set; }

        public string Status { get; set; }

        public ICollection<RotinaEventHistoryViewModel> RotinasEventsHistories { get; set; }
    }
}