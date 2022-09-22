using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum EnvolvidoTipoEnum
    {
        [Display(Name = "Responsável")]
        RESPONSAVEL = 1,
        
        [Display(Name = "Participante")]
        PARTICIPANTE = 2,

        [Display(Name = "Audiente")]
        AUDIENTE = 3
    }
}