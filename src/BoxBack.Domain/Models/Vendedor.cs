using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BoxBack.Domain.Models
{
    public class Vendedor : EntityAudit
    {
        public Vendedor (string nome)
        {
            Nome = nome;
        }

        // Constructo empty to EFCore
        public Vendedor() {}


        public string Nome { get; set; }


        // Relashionship
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<VendedorComissao> VendedorComissoes { get; set; }
        public virtual ICollection<VendedorContrato> VendedorContratos { get; set; }
    }
}