using System;

namespace BoxBack.Application.ViewModels.Dashboard.Comercial
{
    public class ClienteContratoChartViewModel
    {
        public Int64 TotalClientesSemContrato { get; set; }
        public Int64 TotalClientesComContrato { get; set; }
        public decimal TotalClientesUltimosMeses { get; set; }
    }
}