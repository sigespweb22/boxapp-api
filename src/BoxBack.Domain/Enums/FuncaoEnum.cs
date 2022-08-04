using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum FuncaoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,
        
        [Display(Name = "Engenheiro de Software")]
        ENGENHEIRO_SOFTWARE = 1
    }
}