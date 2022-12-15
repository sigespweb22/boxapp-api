using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class v009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendedoresContratos_ClienteContratos_VendedorId",
                table: "VendedoresContratos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f19597-a642-4a55-b9b6-69d604e53eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046890e1-a1f9-4d91-9bbd-ca30dedf6135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0df5f517-0c13-4a5b-8a81-c8858d9ad9fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eff79bc-a0a5-43dc-83fb-b26cb8ccb967");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "137c52ce-f1dd-4b1b-a8a5-b76a15d6ed16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "146a4c8a-edb2-4b4f-af5e-f80a96b59224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed5f9ac-6971-41a2-a29b-1493cc8111c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f3f9166-0927-425d-836f-492599ff0b26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "205f5b99-d2ad-411a-83d6-d229c8ccbb72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23503d39-b4e3-4d9e-ae51-8f9388e34fc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "258eac1f-b457-41f0-b2dc-d2cb56679e0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f7242ba-4bb6-47a5-b6b0-23c783b74f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3139b0b7-3727-4ed2-8366-e89184d505d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3284be54-3270-4303-bd4f-5e5a2c2d00f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348198f1-ac50-4c56-9de7-9b2e77d3a35f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c8474c1-9024-480e-aca5-d7eef04ce870");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40569b30-4c3e-48f5-b68d-688e52b98d18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42f307b8-1f16-402b-87e5-9033f7befdbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a1904bb-2561-4a91-a7a0-c7d9f8e3ae74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c6be8b0-5ea8-42f1-8935-e26c050748f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbd8c0b-a6d0-4252-8296-7d04516f557f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9022ad-e19a-4759-8789-84e58464aed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dac756b-0a98-47fb-a3b1-de0c8edbaad3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e60cafe-e227-4f08-aa64-d0e364a61222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "531fc797-b4bf-48b2-8bc2-e56110d63b00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55f60567-999d-485c-9fd7-6be8f5afc3e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c3519e-6d29-4e25-bb8d-0a5783d04477");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a8d2b83-992a-4189-b280-1325fec9ce13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cc5eb16-1454-4c33-8c26-0b23eb180763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e34b01-058d-4a56-a7db-e2a89365421f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ec9ae9-2e06-4f33-98cb-b9d18efcb448");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63df456e-17cb-40ce-add2-162dedfac862");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696d6c3f-df33-47d2-8284-79c2ba9b7900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "699b2a97-f954-4aac-b82e-3b3fe14d5bca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a4888ac-716b-4144-9aae-7e2ebf1d505b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a9bda5f-cf19-4110-aadc-8bceea362ac2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b671faa-3156-4674-ad04-487d36214f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "720f9617-0565-4db9-866c-f4a4c42d0576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751403d3-352a-4485-b697-47a4347168b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "764cf495-f6a2-4978-a85d-3e23f3ae3e7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e323f2-e1fd-41dd-b984-5731c7e8216e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b5732c-8c6e-401d-9c99-c0fe3df23757");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a608a0f-91be-4cc9-99cd-67f805184d8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6f3c89-4267-4343-913c-7304d39f9b01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e41dbcf-7b3f-47fd-997b-b7a1ad2c5a2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e3f1b5-49e0-48af-9364-7f43cb6631b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8102d0c5-74e3-4fc0-96d8-1ed52a5386ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "821f8dd8-e8ff-4071-b965-8edade439883");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83856d4d-0bcf-4aca-8a2d-156fa08dbcc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f8c6b1-2d3b-4910-ad24-513f79f7804c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8539cf9f-a525-49e5-9645-54078b68b2d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8668b3db-7404-404d-ab7e-ceeafcbcc1d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac09307-c7a3-47c1-a49c-d771fbbdf87f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cd8e7d2-290b-4ec2-a0af-c65bb96333e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d3f564e-fdc6-4f56-a6d2-5153659239f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b2e9c2-1b76-45b6-bfe9-20243aab16da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a5a85e-d672-4b64-a2c1-6eb622d2d668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f8662e1-b373-4748-8ca0-305b76eb60f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1dc7c81-0128-4833-9a5d-32ded4c99438");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3c80bfa-f35b-40eb-80cd-398bc1550017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6bf18a4-1acb-4447-a2cf-a6cd178c8c4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac54e9a8-9aa0-4eba-8ecf-e7a07f7fe9df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad75795c-8755-4b14-ab7e-c354bc90c1d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1d8d920-86fd-4706-8d4d-e4b5f2569931");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4620e74-8583-43a7-8f88-87e81084f57e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7ee2521-f50f-4bfa-a99d-aa1d027f74b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b994d683-9b18-4593-9077-c78f0be25075");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bad037c9-8bc2-4a85-bafb-fe1e8aa9b009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0946215-a59b-4a52-a8d0-c1c66ff9f165");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4b3f2b6-8f1f-46cc-bc14-324499b6d0ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5afe9e0-fcee-455b-9e93-c985a686071a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5ba59f9-73bb-4a34-9dd2-fad0cff363e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c72eea32-69b3-43da-99a8-89a93f52b17e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76240a8-7f77-4130-b0fd-b8c0155b61a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c832aebc-b338-4e57-9f74-c5ccc43fa639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c97d4433-bdd5-4192-a52d-de6d5b5efc64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9eef962-d667-4f0f-8ab0-56ef387d122a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce25146c-6cb5-404c-b214-d5d214e98b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ced6e1a3-0a70-466e-b4d9-a1c8b2dbc01a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cef4b0db-c1ca-4caa-9ed6-3e080889f393");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b7b2fc-cda4-4aa3-ad23-8e1aeb3742fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3ac5ea2-a175-4570-8ea4-41eadaa222f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d41c08cb-2e30-4771-bf56-32f083615f99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5dbdf90-b8a4-464a-abb6-68a94ad9d7e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7159e7c-d352-4542-a425-e6805f3c2bd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78bc5c1-b57c-489e-bd84-75ff219452f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbce915e-416b-4d10-9499-667e9f634439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2802139-dff7-4fd0-99bb-a58f5bf906cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e281b791-0665-40ab-9518-7943e0d765ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3586e47-5b0c-4e35-b2d3-de08c4632276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e535d8cd-c1d8-4c9f-b4de-39de9da29e66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e811cfc8-bf50-4536-827c-5db18bdfd8ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb191d63-e236-40d8-b69f-dc16479809f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb481bb3-e0d5-451d-8554-600eaf5baf2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec67342e-ca09-4026-9348-f70b97be0635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5f3a1a-ebf2-4ace-bcba-566fff4e1b90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd8bb9a-820d-4b4d-b697-032d93c9863c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f03570bf-4f55-46fa-8a92-3e4647d442d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0c65e1f-1c43-4c8c-948e-0fa2c09301d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f29f3fdc-791c-4307-8d54-9cf2a3cc47f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a03505-38b9-4b49-a422-969fc307753a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d8cf56-a4b1-401e-b3ac-d5d05db00e43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5e15907-92ff-4c7f-933e-2837560b4b7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7736e72-b401-4592-a729-da608a16bab7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f03be7-471d-4276-af51-8b9e19cac312");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb79905d-2457-4f78-951c-a5c03af78b7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc71b9e7-8201-4580-b17a-54b11b204e99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc60971-38c8-4f30-8fd0-d898382d206f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffe8c5a1-93b6-41d9-b4fc-daa142874f73");

            migrationBuilder.DeleteData(
                table: "ChavesApiTerceiro",
                keyColumn: "Id",
                keyValue: new Guid("207911a8-6a66-4407-bd18-a857bf5314c0"));

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 15, 11, 45, 27, 486, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 15, 11, 45, 27, 486, DateTimeKind.Unspecified).AddTicks(9713), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
                values: new object[,]
                {
                    { "016f9113-7037-4af2-8367-1ed7407d52ef", new[] { 5 }, "2d8aae2d-3f97-4908-9c0f-aa8047c41992", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
                    { "0599d8be-fc2c-4a1c-948f-b6b849874c14", new[] { 1 }, "0caee24b-4078-4a75-8919-3d7213a707e8", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
                    { "05d319d0-9352-4f70-850d-3d25871ae256", new[] { 1 }, "3e14e349-b40d-40de-9a47-c1b3ea041c50", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
                    { "066969cf-a6d2-4277-8e38-c55654718c6d", new[] { 5 }, "dd2d4cb5-2508-4a57-bbdc-7e2613c49c9a", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
                    { "07aa70b2-f701-4ad8-b74f-d23d5f36884c", new[] { 1, 2, 3, 4, 5 }, "eaea06ba-32c2-410e-86a8-b763af994c60", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
                    { "0b08eec4-350b-43df-8ea4-12994c030849", new[] { 1, 2, 3, 4, 5 }, "4046122e-6f8a-4463-aa6d-679518747e81", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
                    { "0b2ce7bd-8649-46a3-9ebe-6936597c1364", new[] { 5 }, "68362694-71a1-418e-85cb-5e48054bffad", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
                    { "0b648895-ea54-45f9-a6c1-ec2edb47e3f3", new[] { 1, 2, 3, 4, 5 }, "b0826c11-9446-48d4-bdb9-0f5f2a3c3304", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
                    { "10c049bf-f1b2-4893-8e93-13a410764c02", new[] { 1 }, "1fc3bb77-5eab-4454-a1ff-47d0cc695d0e", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" },
                    { "1cf11ebd-ab73-4dc9-8a42-c8cd46f3ab53", new[] { 2 }, "13e6ab4b-1861-4d42-a90b-69fdd9fd949f", "Pode listar os dados de um produto de fornecedor", "CanVendedorRead", "CANVENDEDORREAD", "ac-vendedor-page" },
                    { "1e79ca5a-4923-41c4-860d-188d8014ee27", new[] { 1, 2, 3, 4, 5 }, "36119104-4abb-4e9a-b9dc-18328758afae", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
                    { "244c0062-3ebd-4b8b-9136-6fb324880783", new[] { 1, 2, 3, 4, 5 }, "4b5cb889-78ca-40e8-a29a-afb959231507", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
                    { "267b646b-f17f-45f0-ab0a-0aa7b05d6fa4", new[] { 1, 2, 3, 4, 5 }, "80f2cf9b-f0c9-445e-9858-9d7c7929cf8d", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
                    { "283206c0-d22e-4cf8-81d6-e2dc718f3317", new[] { 2 }, "3e1773b5-b1f9-44aa-b05f-314df8bc7eda", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
                    { "29e20fdc-953d-45af-8bae-bae9c9f3586b", new[] { 4 }, "f045f480-106d-4fa1-a05e-3e9fe4c3a45e", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
                    { "3055b642-ef41-40f3-802d-7bc0c9fd67fa", new[] { 5 }, "17f8a4c1-b510-472a-ba9c-b09f3fd5b25c", "Pode deletar um produto de fornecedor", "CanVendedorDelete", "CANVENDEDORDELETE", "ac-vendedor-page" },
                    { "3055eca1-138d-4da7-9018-05f12a02b564", new[] { 2 }, "4804adca-1d91-44e6-a17e-f53c66f16051", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
                    { "321b3e00-c394-43ed-9d9a-6279776a02ed", new[] { 5 }, "38786d91-b1d2-4825-8bae-80280b844d07", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
                    { "34e4341b-24d0-47db-8028-0bc09b2a9353", new[] { 2 }, "09f08a35-a203-4e0d-bbc7-29db838ffea2", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
                    { "365d560d-6030-48d0-96c9-dd9d7178bd61", new[] { 1 }, "61e68c5f-cf88-4582-af0c-3ed61a046faf", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
                    { "38a1ed96-7a71-45f9-8fce-43559b9d30bf", new[] { 2 }, "0dcd237f-5ddf-4467-afd0-4b2856836ac9", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
                    { "3cd432b7-f5f6-4640-add8-f4f177d418d8", new[] { 1, 2, 3, 4, 5 }, "dae0c7ff-f423-47f4-b72b-bb7a74c5c6f8", "Pode realizar todas as ações/operações em dashboard publica", "CanDashboardPublicaAll", "CANDASHBOARDPUBLICAALL", "ac-dashboardPublica-page" },
                    { "3ea7a8a6-d7da-4adb-8b2d-671f1e6630b8", new[] { 3 }, "f8de984f-b0d4-431e-9d2d-add7d713cd13", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
                    { "3f73254a-8e19-43fc-9201-b5ace9c8ed50", new[] { 2 }, "15466004-c46d-4ed8-b05d-a40875ecb9b5", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
                    { "423023da-60a5-47ef-a48c-52b2a8a8c3f4", new[] { 4 }, "12b1f7c4-31a7-43a9-a45c-122da7c89a10", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
                    { "42d4f056-6ccf-4026-9b94-3f18d3c59f91", new[] { 4 }, "342caad1-daca-40e0-b588-ddc1a05837b7", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" },
                    { "436c218c-c408-4aaf-ba19-5e5f2248ed59", new[] { 4 }, "3af460b7-c558-49dc-8279-375c15e79f42", "Pode criar um produto de fornecedor", "CanVendedorUpdate", "CANVENDEDORUPDATE", "ac-vendedor-page" },
                    { "455328b6-3a29-49a6-975e-4ffc591bf769", new[] { 5 }, "51d112dd-f877-42b7-ab9c-4df7826b3900", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
                    { "456b5abc-90cf-4f0e-9ff6-53f2a9ab201a", new[] { 4 }, "27cbded9-d2c3-4ebc-8c41-b6cf533113b9", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
                    { "47f94030-648a-434b-916e-31c6e20a137b", new[] { 1, 2, 3, 4, 5 }, "6439b43a-093c-4b2c-b8e0-e9c93ec78b45", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
                    { "4aaaf0fb-b38e-4678-a61d-73e4722fabb6", new[] { 1 }, "f9129332-930f-4c66-836c-f0d134a03843", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
                    { "4ec2c3bd-734c-493d-bfeb-51ce2d7bed4e", new[] { 1, 2, 3, 4, 5 }, "4c5f9317-9dae-4e0d-b7cb-e296079f4389", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
                    { "538f0bfc-5a35-4a02-80c2-e2274f99e056", new[] { 3 }, "05394ed1-b92e-4063-8293-bfc9eaa7e102", "Pode visualizar um produto de fornecedor", "CanVendedorComissaoCreate", "CANVENDEDORCOMISSAOCREATE", "ac-vendedorComissao-page" },
                    { "58b5c6c6-8fd8-4cab-9c03-f8427e9bac22", new[] { 5 }, "039330f0-b9d6-489a-be3d-f859813f26c5", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
                    { "5c329486-126b-4e9a-a9c6-ec0fd1051748", new[] { 1 }, "fec544b4-6e67-46fb-9b2f-b88b9053a44a", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
                    { "5d7bf649-04d6-4a08-aad5-af0ccb034b4f", new[] { 5 }, "0bc22889-eda0-41c4-b8a9-2a219f8c8673", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
                    { "5f576638-d844-4037-a7a2-7d0225816f8f", new[] { 3 }, "9d14666c-3e5b-480b-9e46-c8cc95731815", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
                    { "646ecf31-3ee6-4e0d-bb8d-3e21dad16e50", new[] { 1, 2, 3, 4, 5 }, "64f007ad-9d2c-47ef-936c-8ac1bf3aaf3b", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
                    { "64b6e57d-176b-4e13-8936-8d2c2bb8687d", new[] { 1 }, "7c472c1a-1f89-4652-9672-c120f4a3b887", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
                    { "64e94d32-f963-45ba-a919-2b8c68c402a2", new[] { 1 }, "74e631d2-ad0f-4c6c-a578-a23c25d171bc", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
                    { "64ff7235-87a5-44ab-a0af-e0b78807d4e7", new[] { 5 }, "5067d294-06b9-4823-a66d-bbc591f9f376", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
                    { "679f3053-7b51-4271-a83e-cedebf225caf", new[] { 3 }, "356a9e4f-11d5-4989-898f-8e889238f3cc", "Pode visualizar um produto de fornecedor", "CanVendedorCreate", "CANVENDEDORCREATE", "ac-vendedor-page" },
                    { "6fa942a8-a109-45ab-a367-7a8c3efde243", new[] { 1, 2, 3, 4, 5 }, "e5234b3c-44a9-4928-afdd-c41410487671", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
                    { "71066d5f-2e3e-4770-b12f-e4fe59d92a6c", new[] { 5 }, "4a4a5f73-ef25-4fa3-ba0e-f71fcf900d7b", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
                    { "71a80ffd-8fe3-4b7c-92d0-ebd4107a78d0", new[] { 1, 2, 3, 4, 5 }, "f3e340ea-9fe4-47c2-8613-d84e669a656d", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorAll", "CANVENDEDORALL", "ac-vendedor-page" },
                    { "792d5786-fa27-41e1-9856-7613b035453b", new[] { 1 }, "7e5c69f5-79e3-4703-b1f1-5ac4c079e22a", "Pode listar o título dos negócios", "CanTitleBussinesList", "CANTITLEBUSSINESLIST", "ac-titleBussines-page" },
                    { "7a14c990-97ce-45ea-bd94-67254e6b6b0d", new[] { 2 }, "48ad8532-b8da-4bed-b958-799ace43ec4e", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
                    { "7b4af599-87d9-4ea0-8c90-3a2a05d4b12a", new[] { 4 }, "6ec049f9-4ce7-4267-9323-cc2875a2226c", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
                    { "7e9e4664-89cd-4ac1-baf4-34090d9f4d6d", new[] { 1, 2, 3, 4, 5 }, "8c00b90f-3ca4-465a-97e8-e18ae4461fc1", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
                    { "7f025be3-f026-4917-b439-3f4ada90459c", new[] { 4 }, "77911cf4-d10b-4ab8-a804-26346d17daae", "Pode criar um produto de fornecedor", "CanVendedorContratoUpdate", "CANVENDEDORCONTRATOUPDATE", "ac-vendedorContrato-page" },
                    { "808087a3-7267-429f-9a21-2f209adac93b", new[] { 1 }, "b0a7f354-6df3-4680-b278-b8ac0a7b4aa4", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
                    { "8131098d-e358-4a9b-8a51-8f137ce2d20c", new[] { 1 }, "e0e3e6ff-9619-4b69-810f-e0f08d980cbd", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
                    { "8467ae2c-edce-4127-abfb-653fd0e2d74f", new[] { 3 }, "39a307eb-a5c4-49ca-8244-0a99dd9ca267", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
                    { "85185c71-9e64-4e27-96e9-3313a69acab2", new[] { 5 }, "fc715c41-252c-44d3-99e4-fda89f214bb1", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
                    { "87b821d0-7edd-49a6-b50b-5a506b0d149a", new[] { 4 }, "e4b13630-67c6-4cd4-a6c5-eaa3497353f8", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
                    { "896b837f-5bbb-4bfd-8480-6844bdb55bd7", new[] { 4 }, "0b4b1e87-e69d-4753-9c3a-637b25d3d541", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
                    { "89e09474-9c12-4b79-9afa-6e1e617542d0", new[] { 1 }, "914905ec-198d-44b7-bea0-ed4dbb87a3b4", "CanDashboardPublicaClienteContratoList", "CanDashboardPublicaClienteContratoList", "CANDASHBOARDPUBLICACLIENTECONTRATOLIST", "ac-dashboardPublicaClienteContrato-page" },
                    { "8adaf54a-d9ad-4af4-a169-778f3c484045", new[] { 3 }, "e6456e75-c489-4aee-8aa4-68f8a35c95cf", "Pode visualizar um produto de fornecedor", "CanVendedorContratoCreate", "CANVENDEDORCONTRATOCREATE", "ac-vendedorContrato-page" },
                    { "8ae3fcac-da0a-4690-ab29-83b251d1e1c4", new[] { 4 }, "33fd0e58-407b-4e3a-80ed-a2925a96b474", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
                    { "8ec9209e-5c4b-4b01-9212-f7d166c6a335", new[] { 1, 2, 3, 4, 5 }, "785d366d-1887-4eee-a599-25a9d0c88296", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
                    { "992f9b14-748d-438f-9f8a-acfe38a1cf7a", new[] { 4 }, "fef791de-81a7-4d71-85c0-a0f2916f9bb8", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
                    { "9e0363d5-db1b-4999-8b0f-4116c94e6c2b", new[] { 1 }, "63ae641f-8587-46ee-a150-0b515b2c5161", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
                    { "9e533aca-e8f4-4035-bf16-f542c0c0d286", new[] { 1 }, "83aaf770-b671-41f4-86d0-b39e4ea4ebf9", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorList", "CANVENDEDORLIST", "ac-vendedor-page" },
                    { "9f9f4147-1226-43b3-90d3-a80c8a88d8b5", new[] { 3 }, "0b366945-6113-475b-8cf1-5348caf75397", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
                    { "a272b732-b67b-4e16-a31d-b12263644c2d", new[] { 5 }, "d0289d46-7b51-4bd3-9594-abb1fc9aea24", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
                    { "a2fc8aca-b389-495d-a39d-d88eb6b57c12", new[] { 5 }, "f7ea5b46-0634-4996-8517-7eff54c96884", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" },
                    { "a831e067-c792-466a-adc1-612c0c0b939a", new[] { 5 }, "20d79340-1978-4b27-a341-9624ac73a999", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
                    { "aaf82b5c-afc3-4ab0-93cc-2a5451e27450", new[] { 3 }, "72cc1cee-1c1b-46ef-8b14-4dea0eb994ce", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
                    { "ad32c323-ffaa-437c-bedf-110814cc5867", new[] { 1, 2, 3, 4, 5 }, "c602d109-9730-47ad-aa9f-a779c8772757", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
                    { "ada4cdc1-ade3-49fa-8fdd-b739e81072e6", new[] { 4 }, "8b2fdebf-2008-46a8-81b2-5f012dbb9c1e", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
                    { "add57028-7279-41e2-ac89-5d675f7fd25a", new[] { 2 }, "65ca49b6-7251-41f4-ae46-83b22e66dd4f", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
                    { "aea4b3b1-20a7-49ec-8f3a-b30cdb7d4775", new[] { 1 }, "cd5424a5-e764-48fb-a057-fc8fece0b355", "Pode listar o título do sistema", "CanTitleSystemList", "CANTITLESYSTEMLIST", "ac-titleSystem-page" },
                    { "b3b805f6-401b-4d20-878d-bfa8a0971aab", new[] { 4 }, "b915665a-7e57-4cb9-97ba-6385717ad910", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
                    { "b4f9ee7d-25d2-4ac2-a4e2-c2589c35e8cf", new[] { 3 }, "c1e02594-2872-422c-a19d-201a436a0ab7", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
                    { "b5579cf2-7eaf-4cc2-bbd3-f389e325a9d9", new[] { 2 }, "1b705217-85a7-4053-8ae5-9fb9f29cbed6", "Pode listar os dados de um produto de fornecedor", "CanVendedorContratoRead", "CANVENDEDORCONTRATOREAD", "ac-vendedorContrato-page" },
                    { "b5e15b2d-efea-4093-8bd0-be553c00fa1a", new[] { 1, 2, 3, 4, 5 }, "48233bf0-d0db-4ddf-8e87-3fc88c070453", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
                    { "b8debce7-24d7-4b34-a0f7-5e46413acff9", new[] { 3 }, "d79c49c1-9cc6-4f77-87cc-af4327f02e83", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
                    { "b9b13cd5-0a38-45b7-b3cc-1032ec177d05", new[] { 4 }, "789a27d6-c917-40a6-b6c4-908f5bb89540", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
                    { "ba165d12-bbb2-457f-b9f3-ed657940e718", new[] { 1 }, "bb6fa03d-9f2f-4820-a620-9ae1d45925a4", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
                    { "c11a6ca8-6624-40a4-b093-375910ccf50c", new[] { 1, 2, 3, 4, 5 }, "a0feb753-1011-4c30-86dd-093a8e5a764f", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorComissaoAll", "CANVENDEDORCOMISSAOALL", "ac-vendedorComissao-page" },
                    { "c8aa202f-6fcb-42cf-bb44-06faf869718f", new[] { 2 }, "a3f6d17f-9982-4e26-818f-25962a026727", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
                    { "cb119d3f-eb03-431a-b00f-21a97b9b3551", new[] { 5 }, "688394c0-2a34-45ec-b62d-5bd776e0d348", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" },
                    { "ce4a3712-9053-4b80-9733-c94272babe07", new[] { 1 }, "d807db51-f98e-4680-8264-2541e1521c2c", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
                    { "d1aa0224-2d76-4f45-ad04-aeb837dd89b0", new[] { 1 }, "abf723e2-085f-447e-a369-aa8a7945f5b7", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
                    { "d6680956-a28a-4d26-b403-d803feb48f36", new[] { 3 }, "594a8498-d344-4352-92da-ba60fe5e0b9d", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
                    { "da366783-178e-44ae-a01c-0f786a775ba0", new[] { 5 }, "5ffabe6b-0983-45f7-b1bb-246f8767d437", "Pode deletar um produto de fornecedor", "CanVendedorComissaoDelete", "CANVENDEDORCOMISSAODELETE", "ac-vendedorComissao-page" },
                    { "da65068f-bf95-40af-ba26-8554a5b7937f", new[] { 4 }, "4f9e405a-0cb6-42ac-a8a4-42a38ddb2ee2", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
                    { "dd3551e5-bf11-483d-87fb-62d43ec75385", new[] { 3 }, "4952b243-9bdb-4b3b-b20a-9b6f4b31fc13", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
                    { "de0d9e83-c5f5-4377-ba63-7e3d8bd8c52f", new[] { 2 }, "c8f52d6c-5e7b-4cc5-b007-2be3c82e444a", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
                    { "df2cc724-e9e8-436d-9146-eac742f7b93f", new[] { 3 }, "45e4f022-2cf4-4e37-af8e-0eb6544a479e", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
                    { "dfbb87d9-b68b-42f6-a2ef-9e5731e09083", new[] { 1, 2, 3, 4, 5 }, "722fc8a9-5185-435f-9840-4290683ef0e4", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
                    { "e1707ae7-fcec-4f89-9efd-d72e0e5df6f3", new[] { 1, 2, 3, 4, 5 }, "5a4b4bd7-d9c5-4b17-93f2-8d8d87b1d994", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
                    { "e2c831b7-25bf-4385-8a14-3168b2c22350", new[] { 1, 2, 3, 4, 5 }, "94a58825-c029-4dc9-b09a-2a491160e81c", "Pode realizar todas as ações/operações em dashboard comercial", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
                    { "e45d0b87-8aff-4e1c-b50c-c437984ecf95", new[] { 2 }, "0b0f4800-627c-430d-ab5c-971654e2aea2", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
                    { "e4e79514-7526-4e12-b8b4-086cd9a7c9aa", new[] { 2 }, "ac808683-dac5-475c-830b-4114007608d7", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
                    { "e7285402-256d-4f58-8f03-ecc566af7a97", new[] { 3 }, "4385919d-eef5-4b33-8d58-da185cf030e3", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
                    { "e74ad7c7-d248-40bb-ac67-735ae887896f", new[] { 5 }, "a9c75180-3cbc-40c2-b13a-aad23e6fb967", "Pode deletar um produto de fornecedor", "CanVendedorContratoDelete", "CANVENDEDORCONTRATODELETE", "ac-vendedorContrato-page" },
                    { "e808138e-f049-4515-82ea-a5b215dcd6c5", new[] { 2 }, "1280e976-88f3-4fb9-9e89-b1bf57a87ada", "Pode listar os dados de um produto de fornecedor", "CanVendedorComissaoRead", "CANVENDEDORCOMISSAOREAD", "ac-vendedorComissao-page" },
                    { "ebe48ecf-1b76-4e8d-aecc-3f9099f39337", new[] { 2 }, "21f64df8-7b61-4c7d-b32c-44632e7beb0a", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
                    { "eecaa02d-ad11-4cf2-b8ed-254953536db9", new[] { 1 }, "77de52dc-2116-435b-ba2b-61c2870abcbf", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorContratoList", "CANVENDEDORCONTRATOLIST", "ac-vendedorContrato-page" },
                    { "ef4e7311-1f4f-416b-83b6-bbc175fd4ba8", new[] { 4 }, "17e24e94-7ffd-4ccb-af43-602c90a9437b", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
                    { "efb0b74e-7413-4ebc-86d1-36fc1d34ae1c", new[] { 2 }, "571ae89b-fb67-44e8-94b4-a48a436b106b", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
                    { "f285d955-51f4-455e-b570-02cb1caeaa5c", new[] { 1 }, "c59e8c63-d453-4e70-9c2c-3496f8c45b5c", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
                    { "f5736050-77c3-469e-9233-22ce24529e00", new[] { 3 }, "5b6b003f-984c-4255-a077-624210285d76", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
                    { "f5961b08-58d4-4fd3-bcaf-8f94fc8df18b", new[] { 4 }, "bf34bfb7-55c0-4a73-b58a-28d929720090", "Pode criar um produto de fornecedor", "CanVendedorComissaoUpdate", "CANVENDEDORCOMISSAOUPDATE", "ac-vendedorComissao-page" },
                    { "f65cc632-323d-45ab-856b-a97ff67cf3ce", new[] { 3 }, "85747b50-7e2a-409a-a127-e12a423e6423", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
                    { "f6ec666d-6de4-4568-acf2-004e1070f445", new[] { 1 }, "ccbbba49-4c63-4044-bc4a-bb22b4a01de4", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorComissaoList", "CANVENDEDORCOMISSAOLIST", "ac-vendedorComissao-page" },
                    { "f75f13c8-d6ab-4f51-b6be-79cef293ef1d", new[] { 2 }, "f66b6d87-2508-44bc-8287-93ed128b934b", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
                    { "f89b756a-d4e5-43a2-9d20-ce50386e8db6", new[] { 1, 2, 3, 4, 5 }, "fb73dc6f-36ca-4d05-87c4-38fc489eba3e", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
                    { "fb3902c0-998a-41df-9bf4-1fef6cc80b36", new[] { 3 }, "05f598d2-a57a-484b-9be9-38e4366fb517", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
                    { "fd22e0f8-2e3b-4e2c-ae61-de6082d71ce2", new[] { 1, 2, 3, 4, 5 }, "a848f886-0993-436f-9adb-53a4cdd4b5c1", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorContratoAll", "CANVENDEDORCONTRATOALL", "ac-vendedorContrato-page" }
                });

            migrationBuilder.InsertData(
                table: "ChavesApiTerceiro",
                columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("3c648d46-3158-486c-87bf-fadc3501e86e"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 15, 11, 45, 27, 481, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 15, 11, 45, 27, 481, DateTimeKind.Unspecified).AddTicks(9510), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresContratos_ClienteContratoId",
                table: "VendedoresContratos",
                column: "ClienteContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendedoresContratos_ClienteContratos_ClienteContratoId",
                table: "VendedoresContratos",
                column: "ClienteContratoId",
                principalTable: "ClienteContratos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendedoresContratos_ClienteContratos_ClienteContratoId",
                table: "VendedoresContratos");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresContratos_ClienteContratoId",
                table: "VendedoresContratos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "016f9113-7037-4af2-8367-1ed7407d52ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0599d8be-fc2c-4a1c-948f-b6b849874c14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d319d0-9352-4f70-850d-3d25871ae256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "066969cf-a6d2-4277-8e38-c55654718c6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07aa70b2-f701-4ad8-b74f-d23d5f36884c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b08eec4-350b-43df-8ea4-12994c030849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b2ce7bd-8649-46a3-9ebe-6936597c1364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b648895-ea54-45f9-a6c1-ec2edb47e3f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10c049bf-f1b2-4893-8e93-13a410764c02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf11ebd-ab73-4dc9-8a42-c8cd46f3ab53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e79ca5a-4923-41c4-860d-188d8014ee27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "244c0062-3ebd-4b8b-9136-6fb324880783");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267b646b-f17f-45f0-ab0a-0aa7b05d6fa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "283206c0-d22e-4cf8-81d6-e2dc718f3317");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e20fdc-953d-45af-8bae-bae9c9f3586b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3055b642-ef41-40f3-802d-7bc0c9fd67fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3055eca1-138d-4da7-9018-05f12a02b564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "321b3e00-c394-43ed-9d9a-6279776a02ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34e4341b-24d0-47db-8028-0bc09b2a9353");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "365d560d-6030-48d0-96c9-dd9d7178bd61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a1ed96-7a71-45f9-8fce-43559b9d30bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd432b7-f5f6-4640-add8-f4f177d418d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea7a8a6-d7da-4adb-8b2d-671f1e6630b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f73254a-8e19-43fc-9201-b5ace9c8ed50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "423023da-60a5-47ef-a48c-52b2a8a8c3f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42d4f056-6ccf-4026-9b94-3f18d3c59f91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "436c218c-c408-4aaf-ba19-5e5f2248ed59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "455328b6-3a29-49a6-975e-4ffc591bf769");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "456b5abc-90cf-4f0e-9ff6-53f2a9ab201a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47f94030-648a-434b-916e-31c6e20a137b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aaaf0fb-b38e-4678-a61d-73e4722fabb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec2c3bd-734c-493d-bfeb-51ce2d7bed4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "538f0bfc-5a35-4a02-80c2-e2274f99e056");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58b5c6c6-8fd8-4cab-9c03-f8427e9bac22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c329486-126b-4e9a-a9c6-ec0fd1051748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d7bf649-04d6-4a08-aad5-af0ccb034b4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f576638-d844-4037-a7a2-7d0225816f8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "646ecf31-3ee6-4e0d-bb8d-3e21dad16e50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b6e57d-176b-4e13-8936-8d2c2bb8687d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e94d32-f963-45ba-a919-2b8c68c402a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ff7235-87a5-44ab-a0af-e0b78807d4e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679f3053-7b51-4271-a83e-cedebf225caf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa942a8-a109-45ab-a367-7a8c3efde243");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71066d5f-2e3e-4770-b12f-e4fe59d92a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a80ffd-8fe3-4b7c-92d0-ebd4107a78d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "792d5786-fa27-41e1-9856-7613b035453b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a14c990-97ce-45ea-bd94-67254e6b6b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b4af599-87d9-4ea0-8c90-3a2a05d4b12a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e9e4664-89cd-4ac1-baf4-34090d9f4d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f025be3-f026-4917-b439-3f4ada90459c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808087a3-7267-429f-9a21-2f209adac93b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8131098d-e358-4a9b-8a51-8f137ce2d20c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8467ae2c-edce-4127-abfb-653fd0e2d74f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85185c71-9e64-4e27-96e9-3313a69acab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b821d0-7edd-49a6-b50b-5a506b0d149a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "896b837f-5bbb-4bfd-8480-6844bdb55bd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e09474-9c12-4b79-9afa-6e1e617542d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8adaf54a-d9ad-4af4-a169-778f3c484045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ae3fcac-da0a-4690-ab29-83b251d1e1c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec9209e-5c4b-4b01-9212-f7d166c6a335");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "992f9b14-748d-438f-9f8a-acfe38a1cf7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0363d5-db1b-4999-8b0f-4116c94e6c2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e533aca-e8f4-4035-bf16-f542c0c0d286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f9f4147-1226-43b3-90d3-a80c8a88d8b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a272b732-b67b-4e16-a31d-b12263644c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2fc8aca-b389-495d-a39d-d88eb6b57c12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a831e067-c792-466a-adc1-612c0c0b939a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaf82b5c-afc3-4ab0-93cc-2a5451e27450");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad32c323-ffaa-437c-bedf-110814cc5867");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada4cdc1-ade3-49fa-8fdd-b739e81072e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "add57028-7279-41e2-ac89-5d675f7fd25a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea4b3b1-20a7-49ec-8f3a-b30cdb7d4775");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b805f6-401b-4d20-878d-bfa8a0971aab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f9ee7d-25d2-4ac2-a4e2-c2589c35e8cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5579cf2-7eaf-4cc2-bbd3-f389e325a9d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5e15b2d-efea-4093-8bd0-be553c00fa1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8debce7-24d7-4b34-a0f7-5e46413acff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9b13cd5-0a38-45b7-b3cc-1032ec177d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba165d12-bbb2-457f-b9f3-ed657940e718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c11a6ca8-6624-40a4-b093-375910ccf50c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8aa202f-6fcb-42cf-bb44-06faf869718f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb119d3f-eb03-431a-b00f-21a97b9b3551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce4a3712-9053-4b80-9733-c94272babe07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1aa0224-2d76-4f45-ad04-aeb837dd89b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6680956-a28a-4d26-b403-d803feb48f36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da366783-178e-44ae-a01c-0f786a775ba0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da65068f-bf95-40af-ba26-8554a5b7937f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd3551e5-bf11-483d-87fb-62d43ec75385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0d9e83-c5f5-4377-ba63-7e3d8bd8c52f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df2cc724-e9e8-436d-9146-eac742f7b93f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfbb87d9-b68b-42f6-a2ef-9e5731e09083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1707ae7-fcec-4f89-9efd-d72e0e5df6f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c831b7-25bf-4385-8a14-3168b2c22350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e45d0b87-8aff-4e1c-b50c-c437984ecf95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e79514-7526-4e12-b8b4-086cd9a7c9aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7285402-256d-4f58-8f03-ecc566af7a97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74ad7c7-d248-40bb-ac67-735ae887896f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e808138e-f049-4515-82ea-a5b215dcd6c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe48ecf-1b76-4e8d-aecc-3f9099f39337");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eecaa02d-ad11-4cf2-b8ed-254953536db9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4e7311-1f4f-416b-83b6-bbc175fd4ba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb0b74e-7413-4ebc-86d1-36fc1d34ae1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f285d955-51f4-455e-b570-02cb1caeaa5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5736050-77c3-469e-9233-22ce24529e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5961b08-58d4-4fd3-bcaf-8f94fc8df18b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f65cc632-323d-45ab-856b-a97ff67cf3ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ec666d-6de4-4568-acf2-004e1070f445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f75f13c8-d6ab-4f51-b6be-79cef293ef1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f89b756a-d4e5-43a2-9d20-ce50386e8db6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb3902c0-998a-41df-9bf4-1fef6cc80b36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd22e0f8-2e3b-4e2c-ae61-de6082d71ce2");

            migrationBuilder.DeleteData(
                table: "ChavesApiTerceiro",
                keyColumn: "Id",
                keyValue: new Guid("3c648d46-3158-486c-87bf-fadc3501e86e"));

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 14, 15, 29, 1, 850, DateTimeKind.Unspecified).AddTicks(7385), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 14, 15, 29, 1, 850, DateTimeKind.Unspecified).AddTicks(7407), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
                values: new object[,]
                {
                    { "00f19597-a642-4a55-b9b6-69d604e53eab", new[] { 2 }, "ecaa5546-4560-4d2c-b3e4-3f6418c50022", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
                    { "046890e1-a1f9-4d91-9bbd-ca30dedf6135", new[] { 4 }, "7eae96bb-ed3f-48a5-94ab-10bf3de6ae18", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
                    { "0df5f517-0c13-4a5b-8a81-c8858d9ad9fe", new[] { 4 }, "b94644cf-3c0a-4cf2-8fcf-0c9f7fef027b", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
                    { "0eff79bc-a0a5-43dc-83fb-b26cb8ccb967", new[] { 1, 2, 3, 4, 5 }, "44d29c28-9982-4f7b-84d6-929fbc7fd0b4", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
                    { "137c52ce-f1dd-4b1b-a8a5-b76a15d6ed16", new[] { 3 }, "1e688e48-327d-499b-a3d1-97a8b7fc35ba", "Pode visualizar um produto de fornecedor", "CanVendedorComissaoCreate", "CANVENDEDORCOMISSAOCREATE", "ac-vendedorComissao-page" },
                    { "146a4c8a-edb2-4b4f-af5e-f80a96b59224", new[] { 2 }, "88e00395-be21-461b-af98-9e3e316162f6", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
                    { "1ed5f9ac-6971-41a2-a29b-1493cc8111c3", new[] { 4 }, "51eb0d39-1790-4ecc-8132-03a4a1c5efaf", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
                    { "1f3f9166-0927-425d-836f-492599ff0b26", new[] { 4 }, "58118405-95d2-4fcb-9f05-bfc79075a154", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
                    { "205f5b99-d2ad-411a-83d6-d229c8ccbb72", new[] { 1 }, "9542c905-3a96-4824-8a8f-0546e29548b5", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
                    { "23503d39-b4e3-4d9e-ae51-8f9388e34fc7", new[] { 4 }, "b778707c-ba8d-4d3d-b914-991dfa650783", "Pode criar um produto de fornecedor", "CanVendedorContratoUpdate", "CANVENDEDORCONTRATOUPDATE", "ac-vendedorContrato-page" },
                    { "258eac1f-b457-41f0-b2dc-d2cb56679e0a", new[] { 1, 2, 3, 4, 5 }, "fc30e161-4c49-41fd-83cb-a5d83195ce27", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorAll", "CANVENDEDORALL", "ac-vendedor-page" },
                    { "2f7242ba-4bb6-47a5-b6b0-23c783b74f15", new[] { 4 }, "a9517120-8656-4fe8-adbf-ba8aff822e2c", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
                    { "3139b0b7-3727-4ed2-8366-e89184d505d7", new[] { 4 }, "95c54a86-c1ca-4916-a0dc-c664001a89da", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
                    { "3284be54-3270-4303-bd4f-5e5a2c2d00f8", new[] { 1 }, "9db3b9f9-d942-4d7c-884c-47a4c6e83cc8", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
                    { "348198f1-ac50-4c56-9de7-9b2e77d3a35f", new[] { 3 }, "4464a880-8d1d-426d-9bd3-9681e9e2c9c6", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
                    { "3c8474c1-9024-480e-aca5-d7eef04ce870", new[] { 1, 2, 3, 4, 5 }, "ebd905bd-95bc-4b53-8fb7-985131ca033d", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
                    { "40569b30-4c3e-48f5-b68d-688e52b98d18", new[] { 1, 2, 3, 4, 5 }, "18618185-fbe2-4a7d-ac6e-791d024c65b5", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
                    { "42f307b8-1f16-402b-87e5-9033f7befdbd", new[] { 1 }, "eafa7288-4ab1-40c6-ad49-e3c6cf3b5ded", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
                    { "4a1904bb-2561-4a91-a7a0-c7d9f8e3ae74", new[] { 3 }, "f312ae92-55d9-4b58-bb79-a4019560ad3d", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
                    { "4c6be8b0-5ea8-42f1-8935-e26c050748f2", new[] { 5 }, "f02a9801-29f9-4f7d-b47d-94832dc416e4", "Pode deletar um produto de fornecedor", "CanVendedorComissaoDelete", "CANVENDEDORCOMISSAODELETE", "ac-vendedorComissao-page" },
                    { "4cbd8c0b-a6d0-4252-8296-7d04516f557f", new[] { 5 }, "a8e70c99-8002-453c-b642-3305c97a80ec", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
                    { "4d9022ad-e19a-4759-8789-84e58464aed4", new[] { 2 }, "b5b7c5a9-4bd0-4943-8fbb-172754df357a", "Pode listar os dados de um produto de fornecedor", "CanVendedorRead", "CANVENDEDORREAD", "ac-vendedor-page" },
                    { "4dac756b-0a98-47fb-a3b1-de0c8edbaad3", new[] { 4 }, "286c206d-fb51-43de-b67b-762de353541a", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" },
                    { "4e60cafe-e227-4f08-aa64-d0e364a61222", new[] { 5 }, "d56277c6-c9c8-40c8-bc12-b2d024af4a63", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
                    { "531fc797-b4bf-48b2-8bc2-e56110d63b00", new[] { 3 }, "a37bbfaf-7871-43ce-b45f-331ba446fb41", "Pode visualizar um produto de fornecedor", "CanVendedorCreate", "CANVENDEDORCREATE", "ac-vendedor-page" },
                    { "55f60567-999d-485c-9fd7-6be8f5afc3e6", new[] { 3 }, "a42bd7de-c020-408e-aa0e-aff48bbf7959", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
                    { "56c3519e-6d29-4e25-bb8d-0a5783d04477", new[] { 3 }, "acb1db1c-b77e-4ee1-98d0-2e37d24d8baa", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
                    { "5a8d2b83-992a-4189-b280-1325fec9ce13", new[] { 3 }, "8341e3e7-841c-495f-ba65-4162ae49f46f", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
                    { "5cc5eb16-1454-4c33-8c26-0b23eb180763", new[] { 5 }, "5ae663dd-e151-4461-ae01-fd3f8c81db8f", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
                    { "60e34b01-058d-4a56-a7db-e2a89365421f", new[] { 1, 2, 3, 4, 5 }, "57bc2c25-6978-4d9b-9be8-7c3c3776ece8", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
                    { "61ec9ae9-2e06-4f33-98cb-b9d18efcb448", new[] { 1, 2, 3, 4, 5 }, "a1f517ae-a264-44c2-83f9-fc280fe23372", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
                    { "63df456e-17cb-40ce-add2-162dedfac862", new[] { 1 }, "02df4f0a-8117-4610-ad0c-e0b58f591ac9", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
                    { "696d6c3f-df33-47d2-8284-79c2ba9b7900", new[] { 1 }, "e13ed365-c239-415c-952c-42e8d9f73c7b", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
                    { "699b2a97-f954-4aac-b82e-3b3fe14d5bca", new[] { 5 }, "6c789e9f-65a4-4111-a0d3-7ae0a0d9e8ba", "Pode deletar um produto de fornecedor", "CanVendedorContratoDelete", "CANVENDEDORCONTRATODELETE", "ac-vendedorContrato-page" },
                    { "6a4888ac-716b-4144-9aae-7e2ebf1d505b", new[] { 3 }, "fe395898-d2d8-417e-b108-89f0b09c1a33", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
                    { "6a9bda5f-cf19-4110-aadc-8bceea362ac2", new[] { 4 }, "f5a52107-dc28-4a75-bbfe-c99262a83f44", "Pode criar um produto de fornecedor", "CanVendedorComissaoUpdate", "CANVENDEDORCOMISSAOUPDATE", "ac-vendedorComissao-page" },
                    { "6b671faa-3156-4674-ad04-487d36214f84", new[] { 1 }, "44741673-3b87-4807-ab8e-8fb69c47ca93", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
                    { "720f9617-0565-4db9-866c-f4a4c42d0576", new[] { 5 }, "a311a108-f0c7-46e8-93e5-3977ad9c709d", "Pode deletar um produto de fornecedor", "CanVendedorDelete", "CANVENDEDORDELETE", "ac-vendedor-page" },
                    { "751403d3-352a-4485-b697-47a4347168b2", new[] { 2 }, "c3be0a0b-b2e8-45a5-9c8e-441f6f13b88f", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
                    { "764cf495-f6a2-4978-a85d-3e23f3ae3e7e", new[] { 1 }, "44361420-4de7-4327-807a-21c383ea9926", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorComissaoList", "CANVENDEDORCOMISSAOLIST", "ac-vendedorComissao-page" },
                    { "77e323f2-e1fd-41dd-b984-5731c7e8216e", new[] { 5 }, "3d62620d-cb23-474b-aac5-c432b9c1b29a", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" },
                    { "78b5732c-8c6e-401d-9c99-c0fe3df23757", new[] { 2 }, "5fcfbc49-f47e-4703-bdd5-8949bcacb496", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
                    { "7a608a0f-91be-4cc9-99cd-67f805184d8a", new[] { 2 }, "59d454fd-6039-46a6-b216-0a4ab6c76c45", "Pode listar os dados de um produto de fornecedor", "CanVendedorComissaoRead", "CANVENDEDORCOMISSAOREAD", "ac-vendedorComissao-page" },
                    { "7b6f3c89-4267-4343-913c-7304d39f9b01", new[] { 1 }, "275d45d0-d947-4894-81dd-d5270c1a9310", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
                    { "7e41dbcf-7b3f-47fd-997b-b7a1ad2c5a2a", new[] { 1, 2, 3, 4, 5 }, "b6f84c18-b7de-46e0-a54b-7c7ed23d68a2", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
                    { "80e3f1b5-49e0-48af-9364-7f43cb6631b6", new[] { 4 }, "290e6d05-b385-4703-b597-1a3bf43239bb", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
                    { "8102d0c5-74e3-4fc0-96d8-1ed52a5386ed", new[] { 1 }, "278efdd4-c3bf-48ba-a515-4c43fb42f753", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
                    { "821f8dd8-e8ff-4071-b965-8edade439883", new[] { 1, 2, 3, 4, 5 }, "e8824e99-5e49-406c-a3eb-9a92660628e9", "Pode realizar todas as ações/operações em dashboard comercial", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
                    { "83856d4d-0bcf-4aca-8a2d-156fa08dbcc5", new[] { 3 }, "a60c6a93-474c-4dfb-8c6d-7c39c0e967ed", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
                    { "84f8c6b1-2d3b-4910-ad24-513f79f7804c", new[] { 3 }, "02481438-235a-4003-8a3b-a5f85fc44c08", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
                    { "8539cf9f-a525-49e5-9645-54078b68b2d0", new[] { 5 }, "fa38c95e-1511-4e18-848b-4bcaebf4113e", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
                    { "8668b3db-7404-404d-ab7e-ceeafcbcc1d8", new[] { 2 }, "e795a0e4-6c40-4cfc-84ae-d9ff63f6daa7", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
                    { "8ac09307-c7a3-47c1-a49c-d771fbbdf87f", new[] { 2 }, "5910a1f9-91a0-4a59-af52-146d46551b95", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
                    { "8cd8e7d2-290b-4ec2-a0af-c65bb96333e4", new[] { 1, 2, 3, 4, 5 }, "e9c20abf-acba-40e5-a879-f3fa5ab0272f", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
                    { "8d3f564e-fdc6-4f56-a6d2-5153659239f8", new[] { 1, 2, 3, 4, 5 }, "7609aa98-a768-4d71-bd6a-9855f50d35b1", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
                    { "90b2e9c2-1b76-45b6-bfe9-20243aab16da", new[] { 2 }, "006cf39b-cb5e-448c-8e4c-8fa1122b248f", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
                    { "95a5a85e-d672-4b64-a2c1-6eb622d2d668", new[] { 2 }, "2686194c-10bd-49a3-8b46-0872df4f052e", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
                    { "9f8662e1-b373-4748-8ca0-305b76eb60f9", new[] { 1, 2, 3, 4, 5 }, "a10ee7c2-bfe6-4abb-ab80-592965390640", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
                    { "a1dc7c81-0128-4833-9a5d-32ded4c99438", new[] { 1, 2, 3, 4, 5 }, "551200d9-dcba-4eb5-ae70-b5d48f38a589", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
                    { "a3c80bfa-f35b-40eb-80cd-398bc1550017", new[] { 3 }, "cee0be7c-0375-4ffe-9101-84d14c753d0e", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
                    { "a6bf18a4-1acb-4447-a2cf-a6cd178c8c4b", new[] { 1 }, "23e11cda-8a97-44d8-94c4-1041274c94ff", "CanDashboardPublicaClienteContratoList", "CanDashboardPublicaClienteContratoList", "CANDASHBOARDPUBLICACLIENTECONTRATOLIST", "ac-dashboardPublicaClienteContrato-page" },
                    { "ac54e9a8-9aa0-4eba-8ecf-e7a07f7fe9df", new[] { 1, 2, 3, 4, 5 }, "866d9273-93a6-4551-bcb8-fcb283467c5d", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorComissaoAll", "CANVENDEDORCOMISSAOALL", "ac-vendedorComissao-page" },
                    { "ad75795c-8755-4b14-ab7e-c354bc90c1d2", new[] { 1, 2, 3, 4, 5 }, "e06db523-65f7-4905-9af7-dfb745dc7e3b", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
                    { "b1d8d920-86fd-4706-8d4d-e4b5f2569931", new[] { 4 }, "bc2173b6-634f-4ec4-a59b-f8aae73c5d60", "Pode criar um produto de fornecedor", "CanVendedorUpdate", "CANVENDEDORUPDATE", "ac-vendedor-page" },
                    { "b4620e74-8583-43a7-8f88-87e81084f57e", new[] { 5 }, "ed5ade88-18e1-41a3-818e-573b9875b0d6", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
                    { "b7ee2521-f50f-4bfa-a99d-aa1d027f74b7", new[] { 1 }, "151d8415-f54e-407a-bd0a-d2d75e065fc1", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
                    { "b994d683-9b18-4593-9077-c78f0be25075", new[] { 4 }, "dbaecfe2-007f-4591-92e5-e75fcba36ccc", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
                    { "bad037c9-8bc2-4a85-bafb-fe1e8aa9b009", new[] { 2 }, "854c2f86-1f79-4fed-8047-026af6f4fd88", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
                    { "c0946215-a59b-4a52-a8d0-c1c66ff9f165", new[] { 2 }, "ed187ad2-7be2-43bb-af77-86cea0f2d6e5", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
                    { "c4b3f2b6-8f1f-46cc-bc14-324499b6d0ac", new[] { 5 }, "3083336a-9224-490e-9b68-5d37e8bc1489", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
                    { "c5afe9e0-fcee-455b-9e93-c985a686071a", new[] { 1 }, "0a8e1c2d-ad7d-4f27-af54-e7ae0a7b3f1f", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
                    { "c5ba59f9-73bb-4a34-9dd2-fad0cff363e0", new[] { 1 }, "75ced805-d361-4ee5-94a5-96aa5a4b4d75", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
                    { "c72eea32-69b3-43da-99a8-89a93f52b17e", new[] { 1 }, "ad8ed792-d2e9-4a25-9c69-3747adc0638c", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
                    { "c76240a8-7f77-4130-b0fd-b8c0155b61a3", new[] { 1, 2, 3, 4, 5 }, "0f614573-d236-4445-95c4-6d3da238eabe", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
                    { "c832aebc-b338-4e57-9f74-c5ccc43fa639", new[] { 1, 2, 3, 4, 5 }, "f780d001-8bd9-442e-90f4-9356bdaf6edc", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
                    { "c97d4433-bdd5-4192-a52d-de6d5b5efc64", new[] { 4 }, "50c6f420-0a62-417d-afd6-de231d443b52", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
                    { "c9eef962-d667-4f0f-8ab0-56ef387d122a", new[] { 5 }, "8a5d2e9d-896e-4521-9dbb-efb827da70c7", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" },
                    { "ce25146c-6cb5-404c-b214-d5d214e98b14", new[] { 1, 2, 3, 4, 5 }, "183a9d71-ca97-49a5-82c7-a812badccb24", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
                    { "ced6e1a3-0a70-466e-b4d9-a1c8b2dbc01a", new[] { 1 }, "46ea2dcd-4cc1-4870-87a0-24cb1975669e", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorList", "CANVENDEDORLIST", "ac-vendedor-page" },
                    { "cef4b0db-c1ca-4caa-9ed6-3e080889f393", new[] { 2 }, "8b2e5267-0353-46a4-ba4a-8dcf8faa63a3", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
                    { "d1b7b2fc-cda4-4aa3-ad23-8e1aeb3742fe", new[] { 1 }, "e866e524-ccd9-4392-95e9-563d4cbd35a9", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
                    { "d3ac5ea2-a175-4570-8ea4-41eadaa222f8", new[] { 3 }, "dd4c100b-5fec-451f-afe6-3e33f5109434", "Pode visualizar um produto de fornecedor", "CanVendedorContratoCreate", "CANVENDEDORCONTRATOCREATE", "ac-vendedorContrato-page" },
                    { "d41c08cb-2e30-4771-bf56-32f083615f99", new[] { 4 }, "4577b1f4-5820-4189-81ed-8fae844c7823", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
                    { "d5dbdf90-b8a4-464a-abb6-68a94ad9d7e6", new[] { 3 }, "b3697a81-b478-4022-a535-897e23ef6425", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
                    { "d7159e7c-d352-4542-a425-e6805f3c2bd9", new[] { 1 }, "83096ba3-2bf6-4b1b-b057-d794e4b95f82", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorContratoList", "CANVENDEDORCONTRATOLIST", "ac-vendedorContrato-page" },
                    { "d78bc5c1-b57c-489e-bd84-75ff219452f7", new[] { 2 }, "b4ca72a1-10ba-41b7-b266-8f75f1ed3a2b", "Pode deletar uma chave de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
                    { "dbce915e-416b-4d10-9499-667e9f634439", new[] { 1, 2, 3, 4, 5 }, "5cf92f4c-b532-4c52-9088-d03e6ae4e920", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
                    { "e2802139-dff7-4fd0-99bb-a58f5bf906cd", new[] { 5 }, "435b9b28-82cf-46e8-bffa-4549e6dfeefe", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
                    { "e281b791-0665-40ab-9518-7943e0d765ad", new[] { 2 }, "6b864be1-e6ec-4aea-8ca1-e612ba168c9c", "Pode listar os dados de um produto de fornecedor", "CanVendedorContratoRead", "CANVENDEDORCONTRATOREAD", "ac-vendedorContrato-page" },
                    { "e3586e47-5b0c-4e35-b2d3-de08c4632276", new[] { 4 }, "1e377158-442a-49cf-9860-24ab355d1358", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
                    { "e535d8cd-c1d8-4c9f-b4de-39de9da29e66", new[] { 4 }, "6034dc01-df95-4c29-917a-9b41f9fcf899", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
                    { "e811cfc8-bf50-4536-827c-5db18bdfd8ed", new[] { 3 }, "12220b17-e821-4f0f-a57b-ea0742656f9d", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
                    { "eb191d63-e236-40d8-b69f-dc16479809f0", new[] { 3 }, "d68497bd-b334-45d9-b8b0-8ea9310e12ce", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
                    { "eb481bb3-e0d5-451d-8554-600eaf5baf2e", new[] { 1, 2, 3, 4, 5 }, "6e6b598d-15a1-444e-add5-f03740b5bf0c", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
                    { "ec67342e-ca09-4026-9348-f70b97be0635", new[] { 3 }, "36e7cd80-582a-4748-9875-2e3d8cdf3704", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
                    { "ed5f3a1a-ebf2-4ace-bcba-566fff4e1b90", new[] { 5 }, "09e29a79-5827-43fb-a47d-1e2d132c2059", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
                    { "edd8bb9a-820d-4b4d-b697-032d93c9863c", new[] { 1 }, "1e1aec65-9291-4b4c-8316-9ff1a0899ea6", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" },
                    { "f03570bf-4f55-46fa-8a92-3e4647d442d9", new[] { 5 }, "21694b33-93a7-4fa5-9c29-f6ea9bc46d3f", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
                    { "f0c65e1f-1c43-4c8c-948e-0fa2c09301d1", new[] { 1, 2, 3, 4, 5 }, "ec6de2d5-1cee-4801-a6c1-389a39e08148", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
                    { "f29f3fdc-791c-4307-8d54-9cf2a3cc47f8", new[] { 3 }, "2eb33799-331f-40ea-946c-79ea6db64f28", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
                    { "f4a03505-38b9-4b49-a422-969fc307753a", new[] { 1 }, "069bce71-a7ce-4426-924e-08eef4dc356b", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
                    { "f4d8cf56-a4b1-401e-b3ac-d5d05db00e43", new[] { 5 }, "390b5f6d-2686-4d9e-979e-4dd2f73a50b6", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
                    { "f5e15907-92ff-4c7f-933e-2837560b4b7c", new[] { 5 }, "6d03a3de-1f06-4ac8-826a-5bad73c36d95", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
                    { "f7736e72-b401-4592-a729-da608a16bab7", new[] { 1, 2, 3, 4, 5 }, "62ea31c3-cac2-4222-abf9-ed11d929cd82", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorContratoAll", "CANVENDEDORCONTRATOALL", "ac-vendedorContrato-page" },
                    { "f7f03be7-471d-4276-af51-8b9e19cac312", new[] { 2 }, "0d2adcc2-0971-486b-8629-205f0b07560b", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
                    { "fb79905d-2457-4f78-951c-a5c03af78b7a", new[] { 5 }, "498e3d5a-d655-427e-88eb-871750bcd735", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
                    { "fc71b9e7-8201-4580-b17a-54b11b204e99", new[] { 4 }, "f3d1d01c-8222-4af2-8d82-3598afaabae6", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
                    { "fdc60971-38c8-4f30-8fd0-d898382d206f", new[] { 2 }, "e255cbe6-8386-44bb-a61b-bf2e152a03c2", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
                    { "ffe8c5a1-93b6-41d9-b4fc-daa142874f73", new[] { 1, 2, 3, 4, 5 }, "dbc7fdc7-8785-4c36-927b-0a49ce29c050", "Pode realizar todas as ações/operações em dashboard publica", "CanDashboardPublicaAll", "CANDASHBOARDPUBLICAALL", "ac-dashboardPublica-page" }
                });

            migrationBuilder.InsertData(
                table: "ChavesApiTerceiro",
                columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("207911a8-6a66-4407-bd18-a857bf5314c0"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 14, 15, 29, 1, 845, DateTimeKind.Unspecified).AddTicks(9559), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 14, 15, 29, 1, 845, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_VendedoresContratos_ClienteContratos_VendedorId",
                table: "VendedoresContratos",
                column: "VendedorId",
                principalTable: "ClienteContratos",
                principalColumn: "Id");
        }
    }
}
