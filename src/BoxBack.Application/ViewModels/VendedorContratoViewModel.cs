using System;

namespace BoxBack.Application.ViewModels
{
    public class VendedorContratoViewModel
    {
        public Guid? Id { get; set; }
         public Guid VendedorId { get; set; }
         public Guid ClienteContratoId { get; set; }

        public VendedorViewModel Vendedor { get; set; }
        public ClienteContratoViewModel ClienteContrato { get; set; }

        public string Status { get; set; }
    }
}