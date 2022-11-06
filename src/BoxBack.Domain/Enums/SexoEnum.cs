using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum SexoEnum
    {
        [Display(Name = "Outro")]
        OUTRO = 0,
        
        [Display(Name = "Feminino")]
        FEMININO = 1,

        [Display(Name = "Masculino")]
        MASCULINO = 2
    }
}