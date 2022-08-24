using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum AtivoUnidadeMedidaEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Computador")]
        CPU = 1,
        
        [Display(Name = "Hora")]
        HR = 2,

        [Display(Name = "Giga bytes")]
        GB = 3,

        [Display(Name = "vCPU")]
        vCPU = 4
    }
}