using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum FuncaoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Engenheiro de Software")]
        ENGENHEIRO_SOFTWARE = 1,

        [Display(Name = "Arquiteto de Software")]
        ARQUITETO_SOFTWARE = 1
    }
}