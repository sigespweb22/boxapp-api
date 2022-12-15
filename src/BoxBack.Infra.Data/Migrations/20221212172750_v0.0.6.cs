using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class v006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChavesApiTerceiro",
                keyColumn: "Id",
                keyValue: new Guid("c39b289a-96ea-47fd-936e-0ed631bc048b"));

            migrationBuilder.AddColumn<int[]>(
                name: "Actions",
                table: "AspNetRoles",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 12, 14, 27, 49, 598, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 12, 14, 27, 49, 598, DateTimeKind.Unspecified).AddTicks(5377), new TimeSpan(0, -3, 0, 0, 0)) });

            

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
                values: new object[,]
                {
                    { "07148ae3-5871-4543-9482-bf882cb62d25", new[] { 5 }, "5cb493af-3196-4d75-80b3-2e3bf7883237", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
                    { "0bf9c1f5-12b3-46a3-a954-4024fab22f2d", new[] { 2 }, "e60875ce-3599-486d-a550-9b6f3eafa137", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
                    { "0c1ba200-7ef0-45be-bf38-599944930936", new[] { 2 }, "c16f581d-5218-49cb-9205-f266842c396a", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
                    { "0c8d4cea-5637-4d14-85a4-8c556c9bdfce", new[] { 1, 2, 3, 4, 5 }, "743dc1d5-fa5d-4356-84b4-ddbf77c5dfda", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
                    { "0f986edd-7b2a-47d9-a3e8-6f13897ffe41", new[] { 1, 2, 3, 4, 5 }, "ea9a5fa9-624c-41bc-9c55-876e18c62996", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
                    { "150d9bed-9579-41ee-b47e-6f9fc20cb840", new[] { 5 }, "c4024710-3af1-410b-a7cd-1e611d7575a7", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
                    { "1571f7cd-431f-4614-a5dc-d29ff680f73b", new[] { 2 }, "9d4d5aae-dae9-4522-ba3f-fb5ad45002ac", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
                    { "15746bfc-05e7-4da6-9393-3637771a9fef", new[] { 1 }, "427244a0-4711-4d93-9278-ec73c8aeff1e", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
                    { "194e54d6-6e46-4035-a66d-8de87b8885b1", new[] { 1 }, "426326cd-0de2-4b36-bf04-401507212421", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
                    { "1abd14f5-e482-44ff-ae2d-e47c9b0a7955", new[] { 3 }, "a4cb65c8-a558-490d-83a2-10272bcdb2e6", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
                    { "1fae131c-db76-4249-8a65-afbc05e48380", new[] { 4 }, "dfb8131e-dfa5-494d-82df-cf01d381e848", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
                    { "20267382-b4d5-4fcb-9699-49227dc9d742", new[] { 3 }, "eea25623-a49c-4a13-8dc6-6baeac8284f5", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
                    { "223ad836-d5ae-4447-84ea-35c5ebba7adb", new[] { 5 }, "9306c73b-69fe-40b9-bed9-07e2a25d3839", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
                    { "26107dbb-6173-4e0a-90bc-c6664699e2b3", new[] { 2 }, "1240408d-8d83-451f-86ab-cd798fe2fa6b", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
                    { "2a4fc896-45e4-4dec-b421-659aa044dede", new[] { 4 }, "38259bba-3161-4a95-8cda-c0b902188fb0", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
                    { "2d1bc752-16e1-4ba6-9ec9-6fd9ac4a0708", new[] { 5 }, "1641ad4c-3261-4002-9faf-99ff07ab94fc", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" },
                    { "301c817e-9711-49ca-a804-ec8937a173b1", new[] { 2 }, "50bbccd8-4c6e-419d-98d3-ad53930450df", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
                    { "313f2c5f-4ec4-42b3-87d9-40177420be6e", new[] { 2 }, "b3086e66-28af-44cd-b34a-ac08e31c99da", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
                    { "361a5a0a-88db-47c2-9382-47f50650d406", new[] { 3 }, "20b1b58e-2fb5-4b39-b872-4dbf1f9c0713", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
                    { "3648020e-9da9-414c-9915-4d628d25445f", new[] { 4 }, "4fb3d029-cd22-4556-ab62-143336f89716", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
                    { "36e82c44-16cb-49b6-9e0d-b90d6c78f51a", new[] { 1 }, "3d083871-f102-4363-8231-c38d772cf8ff", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
                    { "3852861a-2b49-4ae4-bc25-9eb0d66a0921", new[] { 1, 2, 3, 4, 5 }, "97b3a3d9-3599-4923-804b-b3ce77c9008b", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
                    { "38cd8c4e-c5da-4291-81af-866f9a679566", new[] { 1, 2, 3, 4, 5 }, "66dc0e59-0f0f-4316-9bbd-358d30421016", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
                    { "4651e3a7-b07f-4545-9243-7ecd07ae0ae3", new[] { 1, 2, 3, 4, 5 }, "de9af1df-5006-4564-ac33-30291d69d294", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
                    { "4809df2e-6ddc-4862-95ee-bdab31f2e978", new[] { 1 }, "f90d99ce-82d8-4196-94aa-c5341df4ba8e", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
                    { "484bd20b-32ca-4501-84e4-6777a0b9be24", new[] { 4 }, "c9819524-f500-4ee8-be2b-40a12869298e", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
                    { "4a7fdee0-683e-4f54-9996-a9f456f417fe", new[] { 1 }, "8df3566a-fead-4240-9adc-7845cfb516de", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
                    { "4d8c8d80-63ab-4142-9e2f-2dacb1c670e9", new[] { 3 }, "10203d37-d3e3-4d6d-9b05-f97c845a0992", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
                    { "506121dd-8f90-49fb-9ab1-6ca094498702", new[] { 5 }, "d486339d-1fc2-4784-b4b8-f099a8767066", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
                    { "520c6188-c4c9-4f07-ae15-0abf10a6fb52", new[] { 5 }, "dbb7718e-de17-4f64-acb8-1aabb6de7df7", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
                    { "5430d5d2-af89-46bd-8905-4891d552f0a5", new[] { 5 }, "850f9a7f-718e-4f9e-a125-520b7df56227", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
                    { "558f024c-6c80-479a-8b6a-39b9a1444158", new[] { 2 }, "4b10f3ba-c205-4a9c-8811-7e37c4929d5d", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
                    { "55b54f58-28be-4d42-9ac2-f0c625b339c4", new[] { 1 }, "11dacc98-cbee-4a9b-ab30-aa5895fe3fa7", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
                    { "56a65b3a-bb57-439f-9ba3-643dfa229d43", new[] { 3 }, "f084cc27-d3e9-442a-9741-7acf209e3f75", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
                    { "57987f31-928d-42ca-ae71-c0963b5ca557", new[] { 5 }, "a6929dfc-7a18-4b52-ade8-745a03649564", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
                    { "599e6a76-3f7d-4f1c-b024-e99960692868", new[] { 1 }, "0313da9b-64c2-405a-8254-a7683f8b5a09", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
                    { "5af1363e-1b37-4d98-b126-a4be48d1d7b9", new[] { 1, 2, 3, 4, 5 }, "9494febc-2fb2-4cca-9f63-531c994c9306", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
                    { "5e2565e8-0fbe-4fca-b3f1-4ec4ff6e85f8", new[] { 1, 2, 3, 4, 5 }, "11104278-74ae-4979-a15f-7415b4adfbb4", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
                    { "602eefd5-e715-47d8-a1f6-f16312533795", new[] { 5 }, "f4a93d97-fe73-40aa-80cc-33b6f97a18d9", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" },
                    { "60c1aad6-c23f-4aa3-800b-5d498f2499b9", new[] { 3 }, "e1b02607-61a0-40f2-971f-295e81860288", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
                    { "6347a4c1-7cb6-4e66-ac81-7bc02652c912", new[] { 2 }, "7c0632d9-04e4-42a8-8b27-6d69d9923224", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
                    { "64db0219-a8c9-42d4-9985-2de54498363c", new[] { 4 }, "383992a3-c2ae-4fb8-9983-63f0043a690f", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
                    { "66ec27af-0f26-4651-a5cc-4cc4adb293ed", new[] { 4 }, "2524a0f1-45ba-4bde-a76b-38ee1542620f", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
                    { "6a331b29-26ca-4fbf-bbd1-152f530930b5", new[] { 1, 2, 3, 4, 5 }, "79063eff-ee86-4971-b258-77f3f78db93d", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
                    { "6b42243f-e83a-4b78-966d-4e251fb44212", new[] { 4 }, "748914ed-3669-4de8-b114-696d8bc9f8d8", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
                    { "6d3c35a7-e146-4c6c-a76d-5d6a5572a017", new[] { 1, 2, 3, 4, 5 }, "48da83d0-2426-49bc-b020-95588c96b8d9", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
                    { "6d3f6741-8015-4b06-8920-e49dd99be030", new[] { 3 }, "7d8adbaa-85ca-4a31-a97f-21ab04cbf0bb", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
                    { "6e0fbe72-a1e0-4082-a8a3-dad6289f5ce9", new[] { 1 }, "ffe6b666-9b93-4fde-8f1e-1d5758ee58a6", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
                    { "768a8a9a-6b38-4dfc-85d0-70cf8d4accf0", new[] { 2 }, "dfa4234b-d2fe-44cf-8e71-7c73f514c666", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
                    { "7700a0c9-9708-4961-ae56-13214f7a5bb9", new[] { 2 }, "69fe3df7-5231-4061-a2ee-8c6e7bff30a1", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
                    { "7a3c148e-ae63-4b6f-9a94-489b1f3bda97", new[] { 1, 2, 3, 4, 5 }, "10c23fc5-43dd-469b-b5c2-09bb43528d74", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
                    { "7a62f156-c516-40eb-a256-d44c428ceb59", new[] { 2 }, "b49ca0e9-4c65-41dc-9dfa-2a53c0af64a2", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
                    { "7ca945c5-5151-49dd-8339-d58f76fbd3e2", new[] { 4 }, "2f8c372d-f4d3-421c-9f7a-e188fd406126", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
                    { "8799544b-0bca-4bdf-87f6-3304ad3ca281", new[] { 1, 2, 3, 4, 5 }, "fe4914c4-69ab-47a9-a93f-384b445289ac", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
                    { "8981e5a3-826e-46ed-ba8b-68f1d7c43c04", new[] { 5 }, "41610ee7-2af2-4872-8e8e-3e87858d9c4f", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
                    { "8c23c165-a632-4d73-9a0c-0bbf61447880", new[] { 4 }, "309d1c8c-eaaf-4816-a5fd-4bd679f84f21", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
                    { "9400af5c-59b8-46aa-a918-a18d09e60f5d", new[] { 3 }, "ef1d2c1b-f2b1-42a8-95c8-6e7e6c485e4a", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
                    { "94818fb7-74e1-4579-b536-6407f1235ec5", new[] { 5 }, "3930e762-4b42-4a43-8ac2-bccfba7fd459", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
                    { "9650e427-6583-4bde-bd66-2340212bc1ff", new[] { 1, 2, 3, 4, 5 }, "f18725ea-9d68-4768-a12d-fdb10e0662f2", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
                    { "98030071-7722-40c8-8486-081cf358f0f6", new[] { 3 }, "c9804ad4-4ed1-4e92-9f5d-a259eea1a9e4", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
                    { "9bb3197b-deaa-4b63-9a54-e38b838f0fcf", new[] { 3 }, "40ff26cd-b605-4d22-ab13-abc5e5636a63", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
                    { "9e787217-70d0-441b-9304-74eafa202e11", new[] { 3 }, "0d050fc2-1e9b-417b-ad9f-ae138dc07720", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
                    { "9fc86974-2d4a-4777-b15a-6b8629ae30c2", new[] { 1 }, "10b34a4c-b278-4d2f-a33f-304669c1e07d", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
                    { "a15eee08-83ae-410b-ba97-e2dfe71812cf", new[] { 5 }, "3bc0ca6b-2f11-4534-881b-da81c264f42a", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
                    { "a2732607-3090-4981-9e58-5487104a5529", new[] { 3 }, "7acf3af1-231a-4c9d-801b-d66bb519119f", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
                    { "a5a69f4a-2200-4b93-9732-68b85e35b0a1", new[] { 4 }, "f92bae90-1e7c-4cea-a5f0-525d5c59321d", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
                    { "a8bcfe3d-92c7-4e38-bd4a-5035f0532a02", new[] { 5 }, "e44747a2-2df1-475a-9eb7-6ca512eea6e7", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
                    { "aac41081-b865-4e17-bf5e-9288a9f8f515", new[] { 1, 2, 3, 4, 5 }, "07d20157-2f80-4428-bd80-64eb5c009e4b", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
                    { "ab40f165-b594-423f-8dcc-fe34dec701f4", new[] { 1, 2, 3, 4, 5 }, "a8be7a86-ffad-4a5c-a1d8-f8442c2674a4", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
                    { "afac8155-e85a-469b-aa88-dd988d5fe74c", new[] { 4 }, "36c09605-fbd1-4003-84c9-463b3ec4aa22", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
                    { "b0f96d85-3647-4651-9f78-b7529b577ec0", new[] { 0 }, "4629cea3-3b65-43b9-9c4e-7cc68fe4e4e4", "Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades", "Master", "MASTER", "all" },
                    { "b8bfe123-e8a7-429c-a73d-dde1db5fcded", new[] { 4 }, "efacad8e-169f-47be-be2a-afc61efe5eaa", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
                    { "b8d37114-be28-4cc3-885e-60e5d594d5ea", new[] { 1, 2, 3, 4, 5 }, "c80aa8da-da86-455e-b692-35478e5a415e", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
                    { "bf7df28a-5ba5-4c63-9536-fed66fc44d0f", new[] { 4 }, "f94476c3-39d4-48c7-bbbc-6e72c070d511", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" },
                    { "c0fae096-6406-43b3-ad11-90ecfd89a4c8", new[] { 1 }, "8682aca6-4cec-4026-a6c9-48bb65b4a4ee", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
                    { "c765241f-e920-4c87-b59c-0ae5eb2196d9", new[] { 1, 2, 3, 4, 5 }, "b6ad8e1d-7ab3-4e94-a435-a6ca5bc21fd9", "Pode realizar todas as ações/operações em todas as chaves de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
                    { "d30fa63a-2b87-4fff-8510-6438e50c9d96", new[] { 2 }, "5026115e-c8b3-459b-8022-a6b067bd8da9", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
                    { "d32c80fa-7aea-4880-a6b9-b8052297c5e3", new[] { 3 }, "37875ca0-b6c1-4494-927c-a1966b44bcc4", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
                    { "d670ae5c-716b-4348-aa8e-7ff78f99812d", new[] { 2 }, "2711e3b9-acff-4967-8eaf-544c7bba90ad", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
                    { "da363447-9dd5-402c-abe0-4b1d49a8922d", new[] { 1 }, "349345da-f884-48c8-a81e-c6f76dd7d37c", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
                    { "e17959bc-54d8-4c69-b41a-6b98c64728f6", new[] { 3 }, "e9e3fcbd-618c-4da5-8cbf-9dadbef83b79", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
                    { "e5016046-1464-4d91-be38-6b09dfae5be1", new[] { 1, 2, 3, 4, 5 }, "d68cbc2e-dc89-4b46-89d1-9be535ca4517", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
                    { "e5304c7a-ab4a-47a5-890c-6eed73a7489c", new[] { 1 }, "181a0966-a819-4c3e-bdc6-3fe5ad880c57", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
                    { "e5a26123-b6ab-4fd2-891c-122ab92dca6e", new[] { 1, 2, 3, 4, 5 }, "21fb6c7c-d8e5-4b51-b71c-0d2347e98f6a", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
                    { "e7e988ae-2f21-4cdc-b4a8-d75e4fb450fa", new[] { 2 }, "7e3e3148-f7a9-47f0-bc69-3dbdd70d6917", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
                    { "ed0296b2-3977-4b48-aeb8-d6921d233ac9", new[] { 4 }, "17e55728-b5dd-4b2c-bbb0-0eb6fd00f983", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
                    { "efa141e1-ed73-410f-95e0-b955ab04e402", new[] { 5 }, "471e3983-e40b-48e0-bb3e-161b36322b49", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
                    { "f90c2c1e-0e56-4886-8be4-9b04152f949e", new[] { 1 }, "c852c54f-d75c-4b03-a477-252bf0aec3e9", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
                    { "fce3882c-763a-4c8e-bc8c-746a5b5a3548", new[] { 1 }, "8bf02bc4-18a9-4a4d-88fa-c769e21c6f0b", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
                    { "ff24d644-0f99-4ea5-9126-916e47816c3b", new[] { 1 }, "69806ed6-e4d7-4645-b879-43bad310b154", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" }
                });
            
            migrationBuilder.InsertData(
                table: "AspNetRoleGroups",
                columns: new[] { "RoleId", "GroupId" },
                values: new object[,]
                {
                    { "b0f96d85-3647-4651-9f78-b7529b577ec0", "23e63d9c-283b-496b-b7d8-7dac2ef7a822" }
                });

            migrationBuilder.InsertData(
                table: "ChavesApiTerceiro",
                columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("650e797c-571e-4dee-a2db-c6cfa7119bd4"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 12, 14, 27, 49, 594, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 12, 14, 27, 49, 594, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07148ae3-5871-4543-9482-bf882cb62d25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bf9c1f5-12b3-46a3-a954-4024fab22f2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1ba200-7ef0-45be-bf38-599944930936");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c8d4cea-5637-4d14-85a4-8c556c9bdfce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f986edd-7b2a-47d9-a3e8-6f13897ffe41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "150d9bed-9579-41ee-b47e-6f9fc20cb840");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1571f7cd-431f-4614-a5dc-d29ff680f73b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15746bfc-05e7-4da6-9393-3637771a9fef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "194e54d6-6e46-4035-a66d-8de87b8885b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1abd14f5-e482-44ff-ae2d-e47c9b0a7955");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fae131c-db76-4249-8a65-afbc05e48380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20267382-b4d5-4fcb-9699-49227dc9d742");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "223ad836-d5ae-4447-84ea-35c5ebba7adb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26107dbb-6173-4e0a-90bc-c6664699e2b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a4fc896-45e4-4dec-b421-659aa044dede");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1bc752-16e1-4ba6-9ec9-6fd9ac4a0708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "301c817e-9711-49ca-a804-ec8937a173b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "313f2c5f-4ec4-42b3-87d9-40177420be6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361a5a0a-88db-47c2-9382-47f50650d406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3648020e-9da9-414c-9915-4d628d25445f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36e82c44-16cb-49b6-9e0d-b90d6c78f51a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3852861a-2b49-4ae4-bc25-9eb0d66a0921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38cd8c4e-c5da-4291-81af-866f9a679566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4651e3a7-b07f-4545-9243-7ecd07ae0ae3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4809df2e-6ddc-4862-95ee-bdab31f2e978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484bd20b-32ca-4501-84e4-6777a0b9be24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a7fdee0-683e-4f54-9996-a9f456f417fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d8c8d80-63ab-4142-9e2f-2dacb1c670e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "506121dd-8f90-49fb-9ab1-6ca094498702");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "520c6188-c4c9-4f07-ae15-0abf10a6fb52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5430d5d2-af89-46bd-8905-4891d552f0a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558f024c-6c80-479a-8b6a-39b9a1444158");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55b54f58-28be-4d42-9ac2-f0c625b339c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56a65b3a-bb57-439f-9ba3-643dfa229d43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57987f31-928d-42ca-ae71-c0963b5ca557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599e6a76-3f7d-4f1c-b024-e99960692868");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af1363e-1b37-4d98-b126-a4be48d1d7b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e2565e8-0fbe-4fca-b3f1-4ec4ff6e85f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "602eefd5-e715-47d8-a1f6-f16312533795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60c1aad6-c23f-4aa3-800b-5d498f2499b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6347a4c1-7cb6-4e66-ac81-7bc02652c912");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64db0219-a8c9-42d4-9985-2de54498363c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66ec27af-0f26-4651-a5cc-4cc4adb293ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a331b29-26ca-4fbf-bbd1-152f530930b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b42243f-e83a-4b78-966d-4e251fb44212");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d3c35a7-e146-4c6c-a76d-5d6a5572a017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d3f6741-8015-4b06-8920-e49dd99be030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e0fbe72-a1e0-4082-a8a3-dad6289f5ce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "768a8a9a-6b38-4dfc-85d0-70cf8d4accf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7700a0c9-9708-4961-ae56-13214f7a5bb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a3c148e-ae63-4b6f-9a94-489b1f3bda97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a62f156-c516-40eb-a256-d44c428ceb59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca945c5-5151-49dd-8339-d58f76fbd3e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8799544b-0bca-4bdf-87f6-3304ad3ca281");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8981e5a3-826e-46ed-ba8b-68f1d7c43c04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c23c165-a632-4d73-9a0c-0bbf61447880");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9400af5c-59b8-46aa-a918-a18d09e60f5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94818fb7-74e1-4579-b536-6407f1235ec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9650e427-6583-4bde-bd66-2340212bc1ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98030071-7722-40c8-8486-081cf358f0f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb3197b-deaa-4b63-9a54-e38b838f0fcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e787217-70d0-441b-9304-74eafa202e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc86974-2d4a-4777-b15a-6b8629ae30c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a15eee08-83ae-410b-ba97-e2dfe71812cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2732607-3090-4981-9e58-5487104a5529");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5a69f4a-2200-4b93-9732-68b85e35b0a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8bcfe3d-92c7-4e38-bd4a-5035f0532a02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac41081-b865-4e17-bf5e-9288a9f8f515");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab40f165-b594-423f-8dcc-fe34dec701f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afac8155-e85a-469b-aa88-dd988d5fe74c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f96d85-3647-4651-9f78-b7529b577ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8bfe123-e8a7-429c-a73d-dde1db5fcded");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8d37114-be28-4cc3-885e-60e5d594d5ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7df28a-5ba5-4c63-9536-fed66fc44d0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fae096-6406-43b3-ad11-90ecfd89a4c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c765241f-e920-4c87-b59c-0ae5eb2196d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30fa63a-2b87-4fff-8510-6438e50c9d96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d32c80fa-7aea-4880-a6b9-b8052297c5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d670ae5c-716b-4348-aa8e-7ff78f99812d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da363447-9dd5-402c-abe0-4b1d49a8922d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17959bc-54d8-4c69-b41a-6b98c64728f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5016046-1464-4d91-be38-6b09dfae5be1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5304c7a-ab4a-47a5-890c-6eed73a7489c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5a26123-b6ab-4fd2-891c-122ab92dca6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e988ae-2f21-4cdc-b4a8-d75e4fb450fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0296b2-3977-4b48-aeb8-d6921d233ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efa141e1-ed73-410f-95e0-b955ab04e402");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f90c2c1e-0e56-4886-8be4-9b04152f949e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fce3882c-763a-4c8e-bc8c-746a5b5a3548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff24d644-0f99-4ea5-9126-916e47816c3b");

            migrationBuilder.DeleteData(
                table: "ChavesApiTerceiro",
                keyColumn: "Id",
                keyValue: new Guid("650e797c-571e-4dee-a2db-c6cfa7119bd4"));

            migrationBuilder.DropColumn(
                name: "Actions",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoleClaims");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 8, 10, 22, 56, 462, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 10, 22, 56, 462, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ChavesApiTerceiro",
                columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("c39b289a-96ea-47fd-936e-0ed631bc048b"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 8, 10, 22, 56, 459, DateTimeKind.Unspecified).AddTicks(4400), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 10, 22, 56, 459, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
