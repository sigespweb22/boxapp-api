using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class VendedorContrato : EntityAudit
    {
        public VendedorContrato(decimal comissaoReais,
                                Int32 comissaoPercentual)
        {
            ComissaoReais = comissaoReais;
            ComissaoPercentual = comissaoPercentual;
        }

        // Constructo empty to EFCore
        public VendedorContrato() {}


        public decimal ComissaoReais { get; set; }
        public Int32 ComissaoPercentual { get; set; }


        // Relationships
        [ForeignKey("VendedorId")]
        public Guid VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        

        [ForeignKey("ClienteContratoId")]
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContrato { get; set; }
    }
}