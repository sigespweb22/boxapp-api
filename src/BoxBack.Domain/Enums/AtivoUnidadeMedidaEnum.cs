using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum AtivoUnidadeMedidaEnum
    {
        [Display(Name = "Computador")]
        CPU = 0,
        
        [Display(Name = "Hora")]
        HR = 1,

        [Display(Name = "Giga bytes")]
        GB = 2,

        [Display(Name = "vCPU")]
        vCPU = 3
    }
}