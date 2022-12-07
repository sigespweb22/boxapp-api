using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum TipoPessoaEnum
    {
        [Display(Name = "Fisica")]
        FISICA = 1,

        [Display(Name = "Juridica")]
        JURIDICA = 2
    }
}