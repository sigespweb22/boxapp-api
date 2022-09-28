using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum TarefaStatusEnum
    {
        [Display(Name = "Pendente")]
        PENDENTE = 0,

        [Display(Name = "Concluída")]
        CONCLUIDA = 1,
        
        [Display(Name = "Bloqueada")]
        BLOQUEADA = 2,

        [Display(Name = "Em execução")]
        EM_EXECUCAO = 3
    }
}