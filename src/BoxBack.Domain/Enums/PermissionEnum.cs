using System.Linq;
using System.Collections.Generic;
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

        public static List<string> GetNames()
        {
            return EnumHelper.GetNames<PermissionEnum>().ToList();
        }
    }

    public enum PermissionEnum
    {
        #region Master
        [Description("Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades")]
        Master = 0,
        #endregion

        #region Dashboard
        [Description("Pode realizar todas as ações/operações em todas as dashboards")]
        CanDashboardAll = 1,

        [Description("Pode visualizar todas as dashboards do cliente")]
        CanDashboardClienteAll = 2,

        [Description("Pode visualizar todas as dashboards de controle de acesso")]
        CanDashboardControleAcessoAll = 3,
        #endregion

        #region Usuário
        [Description("Pode realizar todas as ações/operações em todos os usuários")]
        CanUserAll = 1001,
        [Description("Pode listar os dados de todos os usuários")]
        CanUserList = 1002,
        [Description("Pode listar os dados de um usuários")]
        CanUserRead = 1003,
        [Description("Pode criar um usuário")]
        CanUserCreate = 1004,
        [Description("Pode atualizar os dados de um usuário")]
        CanUserUpdate = 1005,
        [Description("Pode deletar um usuário")]
        CanUserDelete = 1006,
        #endregion

        #region Roles (Permissões)
        [Description("Pode realizar todas as ações/operações em todos as roles/permissões")]
        CanRoleAll = 2001,
        [Description("Pode listar os dados de todas as roles/permissões")]
        CanRoleList = 2002,
        [Description("Pode listar os dados de uma roles/permissão")]
        CanRoleRead = 2003,
        [Description("Pode criar uma role/permissão")]
        CanRoleCreate = 2004,
        [Description("Pode atualizar os dados de uma roles/permissão")]
        CanRoleUpdate = 2005,
        [Description("Pode deletar uma role/permissão")]
        CanRoleDelete = 2006,
        #endregion

        #region Grupo de usuários
        [Description("Pode realizar todas as ações/operações em todos os grupos")]
        CanGroupAll = 3001,
        [Description("Pode listar os dados de todos os grupos")]
        CanGroupList = 3002,
        [Description("Pode listar os dado de um grupo")]
        CanGroupRead = 3003,
        [Description("Pode criar um grupo")]
        CanGroupCreate = 3004,
        [Description("Pode atualizar os dados de um grupo")]
        CanGroupUpdate = 3005,
        [Description("Pode deletar um grupo")]
        CanGroupDelete = 3006,
        #endregion

        #region Cliente
        [Description("Pode visualizar todos os indicadores da dashboard comercial")]
        CanClienteAll = 4001,
        [Description("Pode listar os dados de todos os clientes")]
        CanClienteList = 4002,
        [Description("Pode listar os dado de um cliente")]
        CanClienteRead = 4003,
        [Description("Pode criar um cliente")]
        CanClienteCreate = 4004,
        [Description("Pode atualizar os dados de um cliente")]
        CanClienteUpdate = 4005,
        [Description("Pode deletar um cliente")]
        CanClienteDelete = 4006,
        #endregion

        #region TP - CNPJ
        [Description("Pode realizar todas as ações/operações em todos os Third party CNPJ - Api de terceiro para busca de CNPJ")]
        CanCnpjTPAll = 5001,
        [Description("Pode listar os dados de um Third party CNPJ - Api de terceiro para busca de CNPJ")]
        CanCnpjTPRead = 5002,
        #endregion

        #region Cliente Serviço
        [Description("Pode realizar todas as ações/operações em todos os serviços de clientes")]
        CanClienteServicoAll = 6001,
        [Description("Pode listar os dados de todos os serviços de clientes")]
        CanClienteServicoList = 6002,
        [Description("Pode listar os dado de um serviço de cliente")]
        CanClienteServicoRead = 6003,
        [Description("Pode criar um serviço para um cliente")]
        CanClienteServicoCreate = 6004,
        [Description("Pode atualizar um serviço de um cliente")]
        CanClienteServicoUpdate = 6005,
        [Description("Pode deletar um serviço de um cliente")]
        CanClienteServicoDelete = 6006,
        #endregion

        #region Serviço
        [Description("Pode realizar todas as ações/operações em todos os serviços")]
        CanServicoAll = 7001,
        [Description("Pode listar os dados de todos os serviços")]
        CanServicoList = 7002,
        [Description("Pode listar os dados de um serviço")]
        CanServicoRead = 7003,
        [Description("Pode atualizar um serviço")]
        CanServicoUpdate = 7004,
        [Description("Pode criar um serviço")]
        CanServicoCreate = 7005,
        [Description("Pode deletar um serviço")]
        CanServicoDelete = 7006,
        #endregion

        #region Pipeline
        [Description("Pode realizar todas as ações/operações em todos os pipelines")]
        CanPipelineAll = 8001,
        [Description("Pode listar os dados de todos os pipelines")]
        CanPipelineList = 8002,
        [Description("Pode listar os dados de um pipeline")]
        CanPipelineRead = 8003,
        [Description("Pode criar um pipeline")]
        CanPipelineCreate = 8004,
        [Description("Pode atualizar um pipeline")]
        CanPipelineUpdate = 8005,
        [Description("Pode deletar um pipeline")]
        CanPipelineDelete = 8006,
        #endregion

        #region Fornecedor
        [Description("Pode realizar todas as ações/operações em todos os fornecedores")]
        CanFornecedorAll = 9001,
        [Description("Pode listar os dados de todos os fornecedores")]
        CanFornecedorList = 9002,
        [Description("Pode listar os dados de um fornecedor")]
        CanFornecedorRead = 9003,
        [Description("Pode criar um fornecedor")]
        CanFornecedorCreate = 9004,
        [Description("Pode atualizar um fornecedor")]
        CanFornecedorUpdate = 9005,
        [Description("Pode deletar um fornecedor")]
        CanForncedorDelete = 9006,
        #endregion

        #region Fornecedor Serviço
        [Description("Pode realizar todas as ações/operações em todos os serviços de fornecedores")]
        CanFornecedorServicoAll = 10001,
        [Description("Pode listar os dados de todos os serviços de fornecedores")]
        CanFornecedorServicoList = 10002,
        [Description("Pode listar os dado de um serviço de fornecedor")]
        CanFornecedorServicoRead = 10003,
        [Description("Pode criar um serviço para um fornecedor")]
        CanFornecedorServicoCreate = 10004,
        [Description("Pode atualizar um serviço de um fornecedor")]
        CanFornecedorServicoUpdate = 10005,
        [Description("Pode deletar um serviço de um fornecedor")]
        CanFornecedorServicoDelete = 10006,
        #endregion

        #region Produto
        [Description("Pode realizar todas as ações/operações em todos os produtos")]
        CanProdutoAll = 11001,
        [Description("Pode listar os dados de todos os produtos")]
        CanProdutoList = 11002,
        [Description("Pode listar os dados de um produtos")]
        CanProdutoRead = 11003,
        [Description("Pode criar um produtos")]
        CanProdutoCreate = 11001,
        [Description("Pode atualizar um produtos")]
        CanProdutoUpdate = 11001,
        [Description("Pode deletar um produtos")]
        CanProdutoDelete = 11001,
        #endregion

        #region Dashboard Comercial
        [Description("Pode realizar todas as ações/operações em todos os serviços de fornecedores")]
        CanDashboardComercialAll = 12001,
        [Description("Pode listar o indicador de clientes ativos com contratos")]
        CanDashboardComercialClienteContratoList = 12002,
        #endregion

        #region Cliente Serviço
        [Description("Pode realizar todas as ações/operações em todos os contratos de clientes")]
        CanClienteContratoAll = 13001,
        [Description("Pode listar os dados de todos os contratos de clientes")]
        CanClienteContratoList = 13002,
        [Description("Pode listar os dado de um contrato de cliente")]
        CanClienteContratoRead = 13003,
        [Description("Pode criar um contrato para um cliente")]
        CanClienteContratoCreate = 13004,
        [Description("Pode atualizar um contrato de um cliente")]
        CanClienteContratoUpdate = 13005,
        [Description("Pode deletar um contrato de um cliente")]
        CanClienteContratoDelete = 13006
        #endregion
    }
}