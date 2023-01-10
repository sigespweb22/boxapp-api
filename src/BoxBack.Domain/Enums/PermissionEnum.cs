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

        #region Title
        [Description("Pode listar o título do sistema")]
        CanTitleSystemList = 5001,
        [Description("Pode listar o título dos negócios")]
        CanTitleBussinesList = 5002,
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
        CanProdutoCreate = 11004,
        [Description("Pode atualizar um produtos")]
        CanProdutoUpdate = 11005,
        [Description("Pode deletar um produtos")]
        CanProdutoDelete = 11006,
        #endregion

        #region Cliente Contrato
        [Description("Pode realizar todas as ações/operações em todos os contratos de clientes")]
        CanClienteContratoAll = 12001,
        [Description("Pode listar os dados de todos os contratos de clientes")]
        CanClienteContratoList = 12002,
        [Description("Pode listar os dados de um contrato de cliente")]
        CanClienteContratoRead = 12003,
        [Description("Pode criar um contrato de cliente")]
        CanClienteContratoCreate = 12004,
        [Description("Pode atualizar um contrato de cliente")]
        CanClienteContratoUpdate = 12005,
        [Description("Pode deletar um contrato de cliente")]
        CanClienteContratoDelete = 12006,
        #endregion

        #region Cliente Produto
        [Description("Pode realizar todas as ações/operações em todos os produtos de clientes")]
        CanClienteProdutoAll = 13001,
        [Description("Pode listar os dados de todos os produtos de clientes")]
        CanClienteProdutoList = 13002,
        [Description("Pode listar os dados de um produto de cliente")]
        CanClienteProdutoRead = 13003,
        [Description("Pode criar um produto de cliente")]
        CanClienteProdutoCreate = 13004,
        [Description("Pode atualizar um produto de cliente")]
        CanClienteProdutoUpdate = 13005,
        [Description("Pode deletar um produto de cliente")]
        CanClienteProdutoDelete = 13006,
        #endregion

        #region Fornecedor Produto
        [Description("Pode realizar todas as ações/operações em todos os produtos de fornecedores")]
        CanFornecedorProdutoAll = 14001,
        [Description("Pode listar os dados de todos os produtos de fornecedores")]
        CanFornecedorProdutoList = 14002,
        [Description("Pode listar os dados de um produto de fornecedor")]
        CanFornecedorProdutoRead = 14003,
        [Description("Pode visualizar um produto de fornecedor")]
        CanFornecedorProdutoCreate = 14004,
        [Description("Pode criar um produto de fornecedor")]
        CanFornecedorProdutoUpdate = 14005,
        [Description("Pode deletar um produto de fornecedor")]
        CanFornecedorProdutoDelete = 14006,
        #endregion

        #region Dashboard Comercial
        [Description("Pode realizar todas as ações/operações em dashboard comercial")]
        CanDashboardComercialAll = 15001,
        CanDashboardComercialClienteContratoList = 15002,
        #endregion

        #region Chave Api Terceiro
        [Description("Pode realizar todas as ações/operações em todas as chaves de api de terceiro")]
        CanChaveApiTerceiroAll = 16001,
        [Description("Pode listar os dados de todas as chaves de api de terceiro")]
        CanChaveApiTerceiroList = 16001,
        [Description("Pode listar os dados de uma chave de api de terceiro")]
        CanChaveApiTerceiroRead = 16001,
        [Description("Pode criar uma chave de api de terceiro")]
        CanChaveApiTerceiroCreate = 16001,
        [Description("Pode atualizar uma chave de api de terceiro")]
        CanChaveApiTerceiroUpdate = 16001,
        [Description("Pode deletar uma chave de api de terceiro")]
        CanChaveApiTerceiroDelete = 16001,
        #endregion

        #region Dashboard Publica
        [Description("Pode realizar todas as ações/operações em dashboard publica")]
        CanDashboardPublicaAll = 17001,
        CanDashboardPublicaClienteContratoList = 17002,
        #endregion

        #region Vendedor
        [Description("Pode realizar todas as ações/operações em todos os vendedores")]
        CanVendedorAll = 18001,
        [Description("Pode listar os dados de todos os vendedores")]
        CanVendedorList = 18002,
        [Description("Pode listar os dados de um vendedor")]
        CanVendedorRead = 18003,
        [Description("Pode visualizar um vendedor")]
        CanVendedorCreate = 18004,
        [Description("Pode criar um vendedor")]
        CanVendedorUpdate = 18005,
        [Description("Pode deletar um vendedor")]
        CanVendedorDelete = 18006,
        #endregion

        #region Vendedor Comissão
        [Description("Pode realizar todas as ações/operações em todas as comissões de vendedores")]
        CanVendedorComissaoAll = 19001,
        [Description("Pode listar os dados de comissão de vendedores")]
        CanVendedorComissaoList = 19002,
        [Description("Pode listar os dados de uma comissão de vendedor")]
        CanVendedorComissaoRead = 19003,
        [Description("Pode visualizar uma comissão de vendedor")]
        CanVendedorComissaoCreate = 19004,
        [Description("Pode criar uma comissão de vendedor")]
        CanVendedorComissaoUpdate = 19005,
        [Description("Pode deletar uma comissão de vendedor")]
        CanVendedorComissaoDelete = 19006,
        #endregion

        #region Vendedor Contrato
        [Description("Pode realizar todas as ações/operações em todos os contratos vinculados a vendedores")]
        CanVendedorContratoAll = 20001,
        [Description("Pode listar os dados de todos os contratos vinculados a vendedores")]
        CanVendedorContratoList = 20002,
        [Description("Pode listar os dados de um contrato vinculado a um vendedor")]
        CanVendedorContratoRead = 20003,
        [Description("Pode visualizar um contrato vinculado a um ou vários vendedores")]
        CanVendedorContratoCreate = 20004,
        [Description("Pode criar um vínculo de contrato a um vendedor")]
        CanVendedorContratoUpdate = 20005,
        [Description("Pode deletar um vínculo de contrato com um vendedor")]
        CanVendedorContratoDelete = 20006,
        #endregion

        #region Cliente Contrato Fatura
        [Description("Pode realizar todas as ações/operações em todas as faturas de contratos de clientes")]
        CanClienteContratoFaturaAll = 21001,
        [Description("Pode listar os dados de todas as faturas de contratos de clientes")]
        CanClienteContratoFaturaList = 21002,
        [Description("Pode listar os dados de uma fatura de contrato de cliente")]
        CanClienteContratoFaturaRead = 21003,
        [Description("Pode visualizar uma fatura de contrato de cliente")]
        CanClienteContratoFaturaCreate = 21004,
        [Description("Pode criar uma fatura de contrato de cliente")]
        CanClienteContratoFaturaUpdate = 21005,
        [Description("Pode deletar uma fatura de contrato de cliente")]
        CanClienteContratoFaturaDelete = 21006,
        #endregion

        #region Rotina
        [Description("Pode realizar todas as ações/operações relacionadas a entidade de sistema rotina")]
        CanRotinaAll = 21100,
        [Description("Pode listar todas as rotinas de sistema")]
        CanRotinaList = 21101,
        [Description("Pode atualizar os dados de rotinas")]
        CanRotinaUpdate = 21102,
        [Description("Pode listar os dados de uma rotina")]
        CanRotinaRead = 21103,
        #endregion

        #region Rotina event history
        [Description("Pode realizar todas as ações/operações relacionadas a entidade rotina event history")]
        CanRotinaEventHistoryAll = 21200,
        [Description("Pode listar todas as rotinas events histories")]
        CanRotinaEventHistoryList = 21201,
        [Description("Pode listar os dados de uma rotina event history")]
        CanRotinaEventHistoryRead = 21202,
        #endregion

        #region Vendedor relatórios
        [Description("Pode realizar todas as ações/operações relacionadas a relatórios de vendedores")]
        CanVendedorRelatorioComissaoList = 21300,

        [Description("Pode listar todas as rotinas events histories")]
        CanVendedorRelatorioAll = 21301
        #endregion
    }
}