using System;

namespace BoxBack.Application.ViewModels
{
    public class DateTimePeriodoRequestModel
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}