using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum AssinaturaCarimboEnum
    {
        [Display(Name = "Pipeline")]
        PIPELINE = 1,
        
        [Display(Name = "Tarefa")]
        TAREFA = 2
    }
}