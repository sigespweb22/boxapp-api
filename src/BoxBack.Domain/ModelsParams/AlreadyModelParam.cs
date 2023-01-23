using System;

namespace BoxBack.Domain.ModelsServices
{
    public class AlreadyModelParam
    {
        public Guid ClienteContratoId { get; set; }
        public DateTimeOffset DataCompetencia { get; set; }
        public decimal Valor { get; set; }
        public Int32 NumeroParcela { get; set; }
    }
}