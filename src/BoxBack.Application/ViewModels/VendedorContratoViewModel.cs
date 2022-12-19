using System;
using System.ComponentModel;
using BoxBack.Domain.Models;

namespace BoxBack.Application.ViewModels
{
    public class VendedorContratoViewModel
    {
        public Guid? Id { get; set; }
        public string Status { get; set; }

        public Int32 ComissaoPercentual { get; set; } = 0;
        public decimal ComissaoReais { get; set; } = 0;

        // Relationships
        public Guid VendedorId { get; set; }
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContrato { get; set; }
    }
}