using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class VendedorContrato : EntityAudit
    {
        // Constructo empty to EFCore
        public VendedorContrato() {}

        [ForeignKey("VendedorId")]
        public Guid VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        // Relationships
        [ForeignKey("ClienteContratoId")]
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContrato { get; set; }
    }
}