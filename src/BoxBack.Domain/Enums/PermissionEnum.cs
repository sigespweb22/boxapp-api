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

        //Begin - Cliente
        CanClienteAll = 22,
        CanClienteList = 23,
        CanClienteRead = 24,
        CanClienteUpdate = 25,
        CanClienteCreate = 26,
        CanClienteDelete = 27,
        CanClienteAlterStatus = 28,
        CanClienteTPAll = 29,
        CanClienteTPListOne = 30
        //End - Cliente
    }
}