using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ServicoCobrancaTipoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,

        [Display(Name = "Único")]
        UNICO = 1,
        
        [Display(Name = "Recorrente")]
        RECORRENTE = 2
    }
}