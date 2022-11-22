using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ContratoTipoEnum
    {
        [Display(Name = "Recorrente")]
        RECORRENTE = 0,
        
        [Display(Name = "Parcelado")]
        PARCELADO = 1
    }
}