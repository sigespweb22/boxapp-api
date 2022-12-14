using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BoxBack.Domain.Models
{
    public class Vendedor : EntityAudit
    {
        public Vendedor (string nome, decimal comissaoReais,
                        Int32 comissaoPercentual)
        {
            Nome = nome;
            ComissaoReais = comissaoReais;
            ComissaoPercentual = comissaoPercentual;
        }

        // Constructo empty to EFCore
        public Vendedor() {}

        public string Nome { get; set; }
        public decimal ComissaoReais { get; set; }
        public Int32 ComissaoPercentual { get; set; }


        // Relashionship
        public string Email { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<VendedorComissao> VendedorComissoes { get; set; }
    }
}