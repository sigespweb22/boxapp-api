using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class ApplicationRoleViewModel
    {

        public string Id { get;set; } 

        [Required(ErrorMessage = "\nNome é requerido.")]
        public string Name { get;set; }

        public string NormalizedName { get;set; }
        public string ConcurrencyStamp { get;set; }

        [Required(ErrorMessage = "\nDescrição é requerida.")]
        public string Description { get; set; }

        public string Subject { get; set; }
        public string[] Actions { get; set; }
    }
}