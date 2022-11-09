using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateSeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleGroups",
                keyColumns: new[] { "GroupId", "RoleId" },
                keyValues: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 16, 32, 21, 288, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 16, 32, 21, 288, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01352fa5-9558-4dfd-937b-7dea765bc599", "c000f812-2d7e-4e34-86e2-06bed498fa1c", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL" },
                    { "046f64df-8338-4028-8401-c3ebc0ad3ccf", "7ff18454-0729-49c3-a239-ec8a62dfb933", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL" },
                    { "04774343-83d4-453c-975c-3cdefd0075de", "7a677929-043d-470e-9206-4a3d236e449b", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE" },
                    { "068d3787-addd-49f3-922d-d320a299545c", "c749f6ab-5273-4642-9e0d-28f85dc92a02", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE" },
                    { "0cac4fc5-5592-4a3e-a34e-e8ee9f7348ff", "19f4c498-4a7d-46e2-8d6f-aca2724245c5", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE" },
                    { "12e635aa-bc6e-4048-98d3-78aa9fb75980", "f3442ec6-d53a-4d3a-a9b2-0d45831ee132", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE" },
                    { "164e986e-ca62-4f68-a628-47be31b392f8", "2d6e05ff-ff9e-4aad-8069-e6c659029703", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE" },
                    { "175dd3a5-4720-43bd-9655-de65eb6cd0e6", "cf85becb-cafa-48fd-82e1-7739b5724fad", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD" },
                    { "1d8888a4-a43f-49e2-ae15-78e198c9f4c7", "f27e57a8-4594-458a-bf5e-440c91bbe99e", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD" },
                    { "1faca8c6-4f03-4fbc-8170-f4e52d83dd48", "4e60e0e1-a917-4504-80de-d624e3e040bd", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST" },
                    { "2ca0bd66-26cc-4404-be40-596fcef5c761", "41b3bf85-eb75-49f9-8953-de94d21bc6c7", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL" },
                    { "2d17105c-a496-4163-b021-26a605500d40", "b0045b8d-1bfd-4a83-a7b6-48613e8f98c2", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE" },
                    { "2f2bd42e-0224-4af5-8cf5-9bfeb2ab80e3", "dbe8e3eb-8065-4720-ba8f-72542ade2456", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST" },
                    { "3abe9cf3-5123-47dc-b1e1-17a02cc13bde", "0a00ff1c-9246-4f42-bc9b-361eadb547b0", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD" },
                    { "4005260c-b6e9-4f96-a281-83132b929804", "650e31d3-aae3-444b-8d22-5f3d8f6021e9", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE" },
                    { "46938f22-1da1-4302-bb52-d66a1b5d358d", "2238e1db-d6a6-4814-9af9-a4107753d09c", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL" },
                    { "46f6b203-a8bd-46bf-8ea0-3a7e9a0a09db", "fe5dc9fa-4e51-44b0-a5de-9df1019c6ab9", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE" },
                    { "5d728f35-86fc-4948-ac42-d32f2de8de2d", "c355dc45-db1f-40bd-8695-ee8f87a5b57d", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL" },
                    { "5d8e4da0-bfbb-449b-b2ee-de80ac19393a", "9f621ed2-6399-443d-bea4-8e9469732221", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST" },
                    { "5eaabf67-2d41-4ce8-84cc-fa76b10db85e", "c74432e0-96be-4d4a-81e2-992cdbba3df8", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE" },
                    { "5fc5fb90-aa9c-481b-adf0-9a354f38520c", "97e74dee-bdd4-4904-8b10-0c7458261bb2", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE" },
                    { "5fe3146c-1075-4f1d-8a4b-de111ed2481e", "60100653-8ce3-49fd-90a7-ffa05d20ede2", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE" },
                    { "6549a5cc-37cf-4ec2-8b92-addbd3dfa5b4", "36fc8fa9-9b0e-44f6-a794-8f7980eb2219", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST" },
                    { "65a86c3a-d079-4149-9899-da76449c171e", "5ffc14e3-803a-4059-a539-12e24709d096", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE" },
                    { "6c192641-5ae5-448e-9d02-7589471f3cb1", "3e9834ea-df3b-47b2-bb61-89461d25f309", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD" },
                    { "73130a57-f333-47e3-a956-c8dd8ff39d0b", "dbcf68c0-3027-4ec7-bcba-6f3a3dadd83e", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD" },
                    { "7a80199a-def8-46d0-93c6-d8c16164ee8f", "986a62eb-88f7-4f2e-b4b7-580cabfaf56f", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL" },
                    { "7b55d0ad-d644-444f-8c9c-902a15fd6cfa", "e99886b2-2d42-4b5c-86f2-144c0dae50c9", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD" },
                    { "7e317bfd-e649-4bc7-8973-a8f1f809104c", "46b5bda1-91de-43b4-934d-81b70cb14db4", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL" },
                    { "7e39f9f5-0051-4e22-8783-75ac85267097", "b2baa8a5-830e-424d-8ebf-5b8d3ec27b7b", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE" },
                    { "7ef99728-e512-4215-bc2d-25efeab840a7", "fa6fc3e0-253b-4816-9fa8-9c26db8f221a", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST" },
                    { "83d0c2c1-25e8-42ff-8d95-4a8af8ca2cbd", "a33a281d-d5c2-4fb2-81ec-6b34fcb62e90", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE" },
                    { "8966c7b2-84d6-46be-9b96-c0b12e5893aa", "1ee2ae99-4dd8-4501-b260-6efec3089266", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE" },
                    { "8d3229c1-f1f6-4245-a18a-ca635876b98c", "e80eccd2-da20-4b22-8ace-552c13eacb6a", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE" },
                    { "8e4e85c2-2fba-4cfb-a56d-424aa1c01704", "5a622cf0-0b27-446f-abba-79c204965e7e", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL" },
                    { "9240c7ed-7e82-49f9-882b-bb35b059261e", "c4f5f872-438a-480c-86df-fd1abd9729b4", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE" },
                    { "93e94c4d-b7b9-40a2-be2d-b69c87fba7f3", "3d0aefb3-8b9f-4c8e-b409-f76d0e569988", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD" },
                    { "94153744-42f4-4e09-8228-798f0cf019f5", "3fe9cb1d-9030-4efd-bdc6-d84654df4a30", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST" },
                    { "99d444f0-47ff-495a-8c34-e3f53c9ebf76", "bebfd735-ffc8-486f-abb5-dfe4f3b3be57", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE" },
                    { "9ced545e-6812-4d93-a6bb-22810d824fee", "0cb63fb7-dac8-491a-9c87-a1a25d9bcca6", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST" },
                    { "9ecf02cd-1b55-4e24-8be4-3d400552c821", "bcf345d8-fea7-4fa0-a488-45c29e320367", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST" },
                    { "9f5eaaab-45a8-45e3-b0c3-b7e8ed35e330", "d219b074-6f77-48f2-b2d1-28c2b6d125dc", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL" },
                    { "a4b970d6-83e6-493a-b5b6-18e7aa190bf6", "fc232c1f-7d4e-44f9-b757-dbd107a2542e", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE" },
                    { "b0f96d85-3647-4651-9f78-b7529b577ec0", "4629cea3-3b65-43b9-9c4e-7cc68fe4e4e4", "Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades", "Master", "MASTER" },
                    { "b1e649f0-14f2-40e0-a81e-94defd1d32d4", "2904553c-2479-4255-822f-d984fab13aaf", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE" },
                    { "b2924499-01c8-4410-a582-7c18a3545f5c", "f0d928bc-72a3-4eb7-a9e8-cd081ecac5f5", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL" },
                    { "bee45f09-2d45-433b-b676-bc367bec2195", "dd18ff8b-3f4c-42b3-b56f-0397b6953bc5", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD" },
                    { "c80fc26f-68be-4676-a06a-21361049307c", "901863bd-877e-4c24-951a-ef4be20a7acc", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL" },
                    { "ca061d4b-5c65-4f2e-a185-f10d78fbaf52", "7c6cb20e-990c-4480-8c18-a43dbe3108ec", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE" },
                    { "cc0d578f-4477-44d7-b7b9-7022ad600b46", "8078c071-70ac-4419-b55c-4fbafc3713d6", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE" },
                    { "ce614117-1066-403d-9789-ecec87e6c504", "0add4d40-a9ed-4a88-96cd-50d8a779efde", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE" },
                    { "ce7de7a3-eb3f-40ad-9be4-09b982df5306", "cfb138ac-7084-4433-bc1c-83831bf0b6a5", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE" },
                    { "d4d4dd87-6f08-45a0-b7c5-b8cc46f7095e", "66be0227-409d-4ed8-80e8-b7493182fe2d", "Pode realizar todas as ações/operações em todos os clientes", "CanClienteAll", "CANCLIENTEALL" },
                    { "d60a8a3a-7daa-42ec-9194-1d089b36326a", "177779f3-3947-4fb5-a586-3524cab329ca", "Pode listar os dados de um Third party CNPJ - Api de terceiro para busca de CNPJ", "CanCnpjTPRead", "CANCNPJTPREAD" },
                    { "d752de6a-93df-4b20-9180-2a1c1f79a1a8", "01ea925a-e0bb-4da5-afbe-275ec5869606", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE" },
                    { "db167f0b-c265-461a-8b73-f0c538402069", "12d9f6b6-d2ce-4a64-b326-846a1b711168", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST" },
                    { "db179469-3a2a-4d77-8fca-6e62770ae58b", "75decb69-4277-47c1-85e6-6312b787ae2c", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE" },
                    { "e2eeb0e8-6014-47f8-83d2-aeca35fe044f", "ac99f10d-751f-4bee-8ecc-1b8a9207329a", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE" },
                    { "f110281f-cd1f-4686-b9b5-7c9b19b3233f", "bc64b943-a71a-437f-80c3-da61f53bd39b", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD" },
                    { "f8a50035-0cd8-42b6-bc6b-14e71f457ad6", "9433e060-f5ca-4453-9d2e-dde854273e92", "Pode realizar todas as ações/operações em todos os Third party CNPJ - Api de terceiro para busca de CNPJ", "CanCnpjTPAll", "CANCNPJTPALL" }
                });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 16, 32, 21, 286, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 16, 32, 21, 286, DateTimeKind.Unspecified).AddTicks(1002), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoleGroups",
                columns: new[] { "GroupId", "RoleId" },
                values: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "b0f96d85-3647-4651-9f78-b7529b577ec0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleGroups",
                keyColumns: new[] { "GroupId", "RoleId" },
                keyValues: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "b0f96d85-3647-4651-9f78-b7529b577ec0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01352fa5-9558-4dfd-937b-7dea765bc599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046f64df-8338-4028-8401-c3ebc0ad3ccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04774343-83d4-453c-975c-3cdefd0075de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068d3787-addd-49f3-922d-d320a299545c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cac4fc5-5592-4a3e-a34e-e8ee9f7348ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12e635aa-bc6e-4048-98d3-78aa9fb75980");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164e986e-ca62-4f68-a628-47be31b392f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "175dd3a5-4720-43bd-9655-de65eb6cd0e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d8888a4-a43f-49e2-ae15-78e198c9f4c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1faca8c6-4f03-4fbc-8170-f4e52d83dd48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca0bd66-26cc-4404-be40-596fcef5c761");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d17105c-a496-4163-b021-26a605500d40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f2bd42e-0224-4af5-8cf5-9bfeb2ab80e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abe9cf3-5123-47dc-b1e1-17a02cc13bde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4005260c-b6e9-4f96-a281-83132b929804");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46938f22-1da1-4302-bb52-d66a1b5d358d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f6b203-a8bd-46bf-8ea0-3a7e9a0a09db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d728f35-86fc-4948-ac42-d32f2de8de2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d8e4da0-bfbb-449b-b2ee-de80ac19393a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eaabf67-2d41-4ce8-84cc-fa76b10db85e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fc5fb90-aa9c-481b-adf0-9a354f38520c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fe3146c-1075-4f1d-8a4b-de111ed2481e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6549a5cc-37cf-4ec2-8b92-addbd3dfa5b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65a86c3a-d079-4149-9899-da76449c171e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c192641-5ae5-448e-9d02-7589471f3cb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73130a57-f333-47e3-a956-c8dd8ff39d0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a80199a-def8-46d0-93c6-d8c16164ee8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b55d0ad-d644-444f-8c9c-902a15fd6cfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e317bfd-e649-4bc7-8973-a8f1f809104c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e39f9f5-0051-4e22-8783-75ac85267097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef99728-e512-4215-bc2d-25efeab840a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83d0c2c1-25e8-42ff-8d95-4a8af8ca2cbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8966c7b2-84d6-46be-9b96-c0b12e5893aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d3229c1-f1f6-4245-a18a-ca635876b98c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4e85c2-2fba-4cfb-a56d-424aa1c01704");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9240c7ed-7e82-49f9-882b-bb35b059261e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93e94c4d-b7b9-40a2-be2d-b69c87fba7f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94153744-42f4-4e09-8228-798f0cf019f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d444f0-47ff-495a-8c34-e3f53c9ebf76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ced545e-6812-4d93-a6bb-22810d824fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ecf02cd-1b55-4e24-8be4-3d400552c821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f5eaaab-45a8-45e3-b0c3-b7e8ed35e330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4b970d6-83e6-493a-b5b6-18e7aa190bf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1e649f0-14f2-40e0-a81e-94defd1d32d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2924499-01c8-4410-a582-7c18a3545f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bee45f09-2d45-433b-b676-bc367bec2195");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c80fc26f-68be-4676-a06a-21361049307c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca061d4b-5c65-4f2e-a185-f10d78fbaf52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0d578f-4477-44d7-b7b9-7022ad600b46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce614117-1066-403d-9789-ecec87e6c504");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7de7a3-eb3f-40ad-9be4-09b982df5306");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d4dd87-6f08-45a0-b7c5-b8cc46f7095e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60a8a3a-7daa-42ec-9194-1d089b36326a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d752de6a-93df-4b20-9180-2a1c1f79a1a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db167f0b-c265-461a-8b73-f0c538402069");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db179469-3a2a-4d77-8fca-6e62770ae58b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2eeb0e8-6014-47f8-83d2-aeca35fe044f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f110281f-cd1f-4686-b9b5-7c9b19b3233f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8a50035-0cd8-42b6-bc6b-14e71f457ad6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f96d85-3647-4651-9f78-b7529b577ec0");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 28, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 28, DateTimeKind.Unspecified).AddTicks(6161), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "da8e4f70-8be9-4d8f-a684-5b97f19d252c", null, "Master", "MASTER" });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 26, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 26, DateTimeKind.Unspecified).AddTicks(4851), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoleGroups",
                columns: new[] { "GroupId", "RoleId" },
                values: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "2c5e174e-3b0e-446f-86af-483d56fd7210" });
        }
    }
}
