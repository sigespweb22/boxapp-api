using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum AssinaturaTipoEnum
    {
        [Description("Este tipo de assinante é um executor de tarefa")]
        [Display(Name = "Responsável")]
        RESPONSAVEL = 1,
        
        [Description("Este tipo de assinante apenas assiste uma tarefa")]
        [Display(Name = "Audiente")]
        AUDIENTE = 2
    }
}