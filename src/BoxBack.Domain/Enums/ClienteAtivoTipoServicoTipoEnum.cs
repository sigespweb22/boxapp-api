using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoServicoTipoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Único")]
        UNICO = 1,
        
        [Display(Name = "Recorrente")]
        RECORRENTE = 2
    }
}