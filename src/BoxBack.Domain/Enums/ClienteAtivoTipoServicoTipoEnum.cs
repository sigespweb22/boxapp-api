using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoServicoTipoEnum
    {
        [Display(Name = "Único")]
        UNICO = 0,
        
        [Display(Name = "Recorrente")]
        RECORRENTE = 1
    }
}