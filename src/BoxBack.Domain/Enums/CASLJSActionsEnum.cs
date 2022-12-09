using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum CASLJSActionsEnum
    {
        [Display(Name = "Ligada a realização de todas as ações no sistema")]
        MANAGER = 0,
        
        [Display(Name = "Ligada a todas as ações relacionadas a listar todos os registros de todas as entidades de sistema")]
        LIST = 1,

        [Display(Name = "Ligada as ações para ler ou listar apenas um registro de qualquer entidade do sistema")]
        READ = 2,

        [Display(Name = "Ligada as ações para criar um ou mais registros de qualquer entidade do sistema")]
        CREATE = 3,

        [Display(Name = "Ligada as ações para atualizar um ou mais registros de qualquer entidade do sistema")]
        UPDATE = 4,

        [Display(Name = "Ligada as ações para deletar um ou mais registros de qualquer entidade do sistema")]
        DELETE = 5
    }
}