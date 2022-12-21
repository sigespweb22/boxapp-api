using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class RotinaEventHistoryViewModel
    {
        public Guid? Id { get; set; }

        public string DataInicio { get; private set; }
        public string DataFim { get; private set; }
        public string StatusProgresso { get; private set; }

        public RotinaViewModel RotinaViewModel { get; set; }
    }
}