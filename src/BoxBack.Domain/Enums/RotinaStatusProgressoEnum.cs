using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum RotinaStatusProgressoEnum
    {
        [Description("Este status representa uma rotina em processo de execução")]
        [Display(Name = "Em execução")]
        EM_EXECUCAO = 1,
        
        [Description("Este status representa uma rotina já realizada")]
        [Display(Name = "Conluída")]
        CONCLUIDA = 2,

        [Description("Este status representa uma rotina com falha na execução")]
        [Display(Name = "Falha na execução")]
        FALHA_EXECUCAO = 3
    }
}