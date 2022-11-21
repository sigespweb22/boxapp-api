using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum IndiceReajusteEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Ipca")]
        IPCA = 1,

        [Display(Name = "Igpm")]
        IGPM = 2,

        [Display(Name = "Inpc")]
        INPC = 3,
        
        [Display(Name = "Igpdi")]
        IGPDI = 4,

        [Display(Name = "Incc")]
        INCC = 5,

        [Display(Name = "Outros")]
        OUTROS = 6
    }
}