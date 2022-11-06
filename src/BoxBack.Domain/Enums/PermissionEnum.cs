using System.ComponentModel;
using BoxBack.Domain.Helpers;

namespace BoxBack.Domain.Enums
{
    // Define an extension method in a non-nested static class.
    public static class Extensions
    {
        public static string GetDescription(this PermissionEnum pe)
        {
            return EnumHelper.GetDescription(pe);
        }
    }

    public enum PermissionEnum
    {
        [Description("Pode total a todas as funcionalidades do sistema.")]
        Master = 0,

        //Begin - Dashboard
        CanDashboardAll = 19,
        CanDashboardClientList = 20,
        CanDashboardACList = 21,
        //End - Dashboard

        //Begin - Usuário
        CanUserAll = 1,
        CanUserList = 2,
        CanUserRead = 3,
        CanUserUpdate = 4,
        CanUserDelete = 5,
        CanUserAlterStatus = 6,
        //End - Usuário

        //Begin - Roles (Permissões)
        CanRoleAll = 7,
        CanRoleList = 8,
        CanRoleRead = 9,
        CanRoleUpdate = 10,
        CanRoleCreate = 11,
        CanRoleDelete = 12,
        //End - Roles (Permissões)

        //Begin - Grupo de usuários
        CanGroupAll = 13,
        CanGroupList = 14,
        CanGroupRead = 15,
        CanGroupUpdate = 16,
        CanGroupCreate = 17,
        CanGroupDelete = 18,
        //End - Grupo de usuários

        //Begin - Cliente
        CanClienteAll = 22,
        CanClienteList = 23,
        CanClienteRead = 24,
        CanClienteUpdate = 25,
        CanClienteCreate = 26,
        CanClienteDelete = 27,
        CanClienteAlterStatus = 28,
        CanClienteTPAll = 29,
        CanClienteTPListOne = 30,
        CanClienteListOne = 31,
        //End - Cliente

         //Begin - Cliente Serviço
        CanClienteServicoAll = 22,
        CanClienteServicoList = 23,
        CanClienteServicoRead = 24,
        CanClienteServicoUpdate = 25,
        CanClienteServicoCreate = 26,
        CanClienteServicoDelete = 27,
        CanClienteServicoAlterStatus = 28,
        //End - Cliente Serviço

        //Begin - Serviço
        CanServicoAll = 32,
        CanServicoList = 33,
        CanServicoRead = 34,
        CanServicoUpdate = 35,
        CanServicoCreate = 36,
        CanServicoDelete = 37,
        CanServicoAlterStatus = 38,
        //End - Serviço

        //Begin - Fornecedor
        CanFornecedorAll = 39,
        CanFornecedorList = 40,
        CanFornecedorRead = 41,
        CanFornecedorUpdate = 42,
        CanFornecedorCreate = 43,
        CanForncedorDelete = 44,
        CanFornecedorAlterStatus = 45,
        CanFornecedorTPAll = 46,
        CanFornecedorTPListOne = 47
        //End - Fornecedor
    }
}