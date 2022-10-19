namespace BoxBack.Domain.Enums
{
    public enum PermissionEnum
    {
        Master = 0,

        //Begin - User
        CanUserAll = 1,
        CanUserList = 2,
        CanUserRead = 3,
        CanUserUpdate = 4,
        CanUserDelete = 5,
        CanUserAlterStatus = 6,
        //End - User

        //Begin - Permissions
        CanRoleAll = 7,
        CanRoleList = 8,
        CanRoleRead = 9,
        CanRoleUpdate = 10,
        CanRoleCreate = 11,
        CanRoleDelete = 12,
        //End - Permissions

        //Begin - Group
        CanGroupAll = 13,
        CanGroupList = 14,
        CanGroupRead = 15,
        CanGroupUpdate = 16,
        CanGroupCreate = 17,
        CanGroupDelete = 18,
        //End - Group

        //Begin - Dashboard
        CanDashboardAll = 19,
        CanDashboardClientList = 20,
        CanDashboardACList = 21,
        //End - Dashboard

        //Begin - Client
        CanClientAll = 22,
        CanClientList = 23,
        CanClientRead = 24,
        CanClientUpdate = 25,
        CanClientCreate = 26,
        CanClientDelete = 27,
        CanClientAlterStatus = 28,
        CanClientTPAll = 29,
        CanClientTPListOne = 30,
        CanClientListOne = 31,
        //End - Client

        //Begin - Asset
        CanServicoAll = 32,
        CanServicoList = 33,
        CanServicoRead = 34,
        CanServicoUpdate = 35,
        CanServicoCreate = 36,
        CanServicoDelete = 37,
        CanServicoAlterStatus = 38,
        //End - Asset

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