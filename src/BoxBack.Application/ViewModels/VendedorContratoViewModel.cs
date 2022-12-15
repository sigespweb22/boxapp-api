using System;

namespace BoxBack.Application.ViewModels
{
    public class VendedorContratoViewModel
    {
        public Guid? Id { get; set; }
        public string Status { get; set; }
        public Int32 ComissaoPercentual { get; set; }
        public decimal ComissaoReais { get; set; }

        // Relationships
        public Guid VendedorId { get; set; }
        public Guid ClienteContratoId { get; set; }
    }
}