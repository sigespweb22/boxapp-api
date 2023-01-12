using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BoxBack.Application.ViewModels
{
    public class VendedorViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "\nNome vendedor é requerido.")]
        public string Nome { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
    }
}