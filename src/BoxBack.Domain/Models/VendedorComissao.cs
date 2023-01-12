using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class VendedorComissao : EntityAudit
    {
        public VendedorComissao (decimal valorComissao)
        {
            ValorComissao = valorComissao;
        }

        // Constructo empty to EFCore
        public VendedorComissao() {}

        public decimal ValorComissao { get; set; }
        

        // Relationships
        [ForeignKey("ClienteContratoId")]
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContrato { get; set; }

        [ForeignKey("VendedorId")]
        public Guid VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        [ForeignKey("ClienteContratoFaturaId")]
        public Guid ClienteContratoFaturaId { get; set; }
        public ClienteContratoFatura ClienteContratoFatura { get; set; }
    }
}