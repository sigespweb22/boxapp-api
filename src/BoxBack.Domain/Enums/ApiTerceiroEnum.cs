using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ApiTerceiroEnum
    {
        [Display(Name = "Bom Controle")]
        BOM_CONTROLE = 0,

        [Display(Name = "Piperun")]
        PIPERUN = 1
    }
}