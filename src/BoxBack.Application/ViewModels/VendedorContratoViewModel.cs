using System;

namespace BoxBack.Application.ViewModels
{
    public class VendedorContratoViewModel
    {
        public Guid? Id { get; set; }
         public Guid VendedorId { get; set; }
         public Guid ClienteContratoId { get; set; }
    }
}