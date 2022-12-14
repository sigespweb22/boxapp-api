using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BoxBack.Application.ViewModels
{
    public class ApplicationGroupUpdateViewModel
    {
        public string Id { get;set; }

        [Required(ErrorMessage = "\nNome do grupo é requerido.")]
        public string Name { get;set; } 
        public string Status { get; set; }

        public List<ApplicationRoleGroupUpdateViewModel> ApplicationRoleGroups { get; set; }
    }
}