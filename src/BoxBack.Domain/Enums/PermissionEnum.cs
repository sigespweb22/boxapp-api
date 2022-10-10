using System.ComponentModel.DataAnnotations;

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
        //End - Client

        //Begin - Asset
        CanAssetAll = 31,
        CanAssetList = 32,
        CanAssetRead = 33,
        CanAssetUpdate = 34,
        CanAssetCreate = 35,
        CanAssetDelete = 36,
        CanAssetAlterStatus = 37,
        //End - Asset

        //Begin - Fornecedor
        CanFornecedorAll = 22,
        CanFornecedorList = 23,
        CanFornecedorRead = 24,
        CanFornecedorUpdate = 25,
        CanFornecedorCreate = 26,
        CanForncedorDelete = 27,
        CanClientAlterStatus = 28,
        CanClientTPAll = 29,
        CanClientTPListOne = 30,
        //End - Fornecedor
    }
}