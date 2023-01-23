using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class ClienteContrato : EntityAudit
    {        
        public ClienteContrato(decimal valorContrato,
                               PeriodicidadeEnum peridiocidade)
        {
            ValorContrato = valorContrato;
            Periodicidade = peridiocidade;
        }

        // Constructor empty for EF
        public ClienteContrato() {}

        public decimal ValorContrato { get; set; }
        public PeriodicidadeEnum Periodicidade { get; set; }


        // Relationships
        [ForeignKey("ClienteId")]
        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [InverseProperty(nameof(VendedorComissao.ClienteContrato))]
        public ICollection<VendedorComissao> VendedoresComissoes { get; set; }
        public ICollection<VendedorContrato> VendedoresContratos { get; set; }
        public ICollection<ClienteContratoFatura> ClientesContratosFaturas { get; set; }

        // Id do registro do contrato no sistema de terceiro - Atualmente o Bom Controle
        public Int64 BomControleContratoId { get; set; }
    }
}