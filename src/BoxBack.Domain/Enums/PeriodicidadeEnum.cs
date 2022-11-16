using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum PeriodicidadeEnum
    {
        [Display(Name = "Nenhuma")]
        NENHUMA = 0,
        
        [Display(Name = "Diária")]
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