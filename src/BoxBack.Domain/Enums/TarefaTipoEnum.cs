using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum TarefaTipoEnum
    {
        [Display(Name = "Principal")]
        PRINCIPAL = 0,

        [Display(Name = "Subtarefa")]
        SUBTAREFA = 1
    }
}