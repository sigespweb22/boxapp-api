using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum PeriodoReajusteEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Diaria")]
        DIARIA = 1,

        [Display(Name = "Semanal")]
        SEMANAL = 2,

        [Display(Name = "Quinzenal")]
        QUINZENAL = 3,
        
        [Display(Name = "Mensal")]
        MENSAL = 4,

        [Display(Name = "Anual")]
        ANUAL = 5,

        [Display(Name = "Trimestral")]
        TRIMESTRAL = 6,

        [Display(Name = "Semestral")]
        SEMESTRAL = 7,

        [Display(Name = "Bimestral")]
        BIMESTRAL = 8
    }
}