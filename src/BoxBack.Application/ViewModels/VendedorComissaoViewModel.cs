using System;
using BoxBack.Domain.Models;

namespace BoxBack.Application.ViewModels
{
    public class VendedorComissaoViewModel
    {
        public Guid? Id { get; set; }
        public decimal ValorComissao { get; set; } = 0;
        public string Status { get; set; }


        // Relationships
        public Guid VendedorId { get; set; }
        public VendedorViewModel VendedorViewModel { get; set; }
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContratoViewModel { get; set; }
        public ClienteContratoFaturaViewModel ClienteContratoFaturaViewModel { get; set; }
    }
}