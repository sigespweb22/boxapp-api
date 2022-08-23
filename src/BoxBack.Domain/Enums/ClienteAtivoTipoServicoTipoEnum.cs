using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoServicoTipoEnum
    {
        [Display(Name = "Único")]
        UNICO = 1,
        
        [Display(Name = "Recorrente")]
        RECORRENTE = 2
    }
}