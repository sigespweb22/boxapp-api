using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum CASLJSActionsEnum
    {
        [Display(Name = "Ligada a realização de todas as ações no sistema")]
        manage = 0,
        
        [Display(Name = "Ligada a todas as ações relacionadas a listar todos os registros de todas as entidades de sistema")]
        list = 1,

        [Display(Name = "Ligada as ações para ler ou listar apenas um registro de qualquer entidade do sistema")]
        read = 2,

        [Display(Name = "Ligada as ações para criar um ou mais registros de qualquer entidade do sistema")]
        create = 3,

        [Display(Name = "Ligada as ações para atualizar um ou mais registros de qualquer entidade do sistema")]
        update = 4,

        [Display(Name = "Ligada as ações para deletar um ou mais registros de qualquer entidade do sistema")]
        delete = 5
    }
}