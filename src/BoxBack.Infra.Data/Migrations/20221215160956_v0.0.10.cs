using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class v0010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendedoresComissoes_ClienteContratos_VendedorId",
                table: "VendedoresComissoes");

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

            migrationBuilder.DropColumn(
                name: "ComissaoPercentual",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "ComissaoReais",
                table: "Vendedores");

            migrationBuilder.AddColumn<int>(
                name: "ComissaoPercentual",
                table: "VendedoresContratos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ComissaoReais",
                table: "VendedoresContratos",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 15, 13, 9, 54, 729, DateTimeKind.Unspecified).AddTicks(8302), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 15, 13, 9, 54, 729, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
                values: new object[,]
                {
                    { "0198772f-e7d7-4879-b6ca-1d0eeb9cd1f9", new[] { 2 }, "78f965e3-01be-4387-80fc-633902e12b18", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
                    { "030e13d1-c1f3-4a18-aae6-7bcd728ac484", new[] { 5 }, "0845b0d1-7493-4b5f-8ed0-7adca9a81752", "Pode deletar um produto de fornecedor", "CanVendedorContratoDelete", "CANVENDEDORCONTRATODELETE", "ac-vendedorContrato-page" },
                    { "039390cc-94a3-488b-9976-03e69bc9608d", new[] { 3 }, "d62c97d2-1d94-4925-a816-3c7b99b1e9e6", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
                    { "044cdc82-1775-4f6d-94d7-3cb932a675d6", new[] { 1 }, "aa29021f-f313-42ff-a57a-88f5ccd1f9a8", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
                    { "04caabb2-37a2-4ab9-9ace-048971c9b7f6", new[] { 4 }, "f9f83055-3350-4b37-b201-be88c8be57e7", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
                    { "0ad746c3-954c-46fc-81c9-2aaf4775fb36", new[] { 2 }, "de017b02-8c6a-4cee-a699-34b5915f7331", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
                    { "0fb1ac02-08af-452f-88a4-d88fe2f41af2", new[] { 1 }, "411fc1ad-7891-4f96-9b4f-a8619c88a46b", "Pode listar o título dos negócios", "CanTitleBussinesList", "CANTITLEBUSSINESLIST", "ac-titleBussines-page" },
                    { "0fbdfe8d-6aae-454f-a603-71bb0cec4272", new[] { 1 }, "442a4f0d-d170-41d8-8986-c022d88062ad", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorContratoList", "CANVENDEDORCONTRATOLIST", "ac-vendedorContrato-page" },
                    { "1002b698-1f1c-4ecb-9ece-82789f628f21", new[] { 1 }, "057f21ad-331b-4eb9-9c58-733270cd19bb", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
                    { "1229a3c1-bac8-410e-b51d-2e90ab904e9a", new[] { 5 }, "188c7e84-7b45-4ce8-9ab1-696272c5c615", "Pode deletar um produto de fornecedor", "CanVendedorComissaoDelete", "CANVENDEDORCOMISSAODELETE", "ac-vendedorComissao-page" },
                    { "12365d9b-be40-4b9a-a4a6-eb315148d64b", new[] { 5 }, "01dea08c-6dea-48af-9f72-8a42e98e157d", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
                    { "1374676b-40f3-42db-9fa4-eade2107efa4", new[] { 3 }, "5cc10487-57d3-4fae-a830-c17adf769773", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
                    { "15226821-4708-41a3-8d94-eeecc10cabe9", new[] { 3 }, "e55f7baa-6205-4bdc-bef6-e838af435f80", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
                    { "1695b933-6c1b-45c2-bd1d-51d31032ac47", new[] { 3 }, "51f1ea00-ad05-42ec-8d2b-f51447e26706", "Pode visualizar um produto de fornecedor", "CanVendedorCreate", "CANVENDEDORCREATE", "ac-vendedor-page" },
                    { "17d75209-3355-48ac-b65b-0c881d047bcd", new[] { 5 }, "45394819-d964-4e68-ad31-7990218c8e6e", "Pode deletar um produto de fornecedor", "CanVendedorDelete", "CANVENDEDORDELETE", "ac-vendedor-page" },
                    { "1953c3f5-75d8-4a5f-a289-f14620b22c95", new[] { 4 }, "2cbe51b5-8a52-4880-b126-10a99c2d7157", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
                    { "1d5d17a1-c3c0-425d-91b2-a17a037642a7", new[] { 2 }, "ca5972c2-6c50-4f00-9378-82694c5e05d6", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
                    { "1f78fdfb-27f8-4e27-bdc9-7f877e06646c", new[] { 2 }, "22dea440-0fa9-4a8b-89f1-10dbdda324f8", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
                    { "1fcf4f3f-4838-4e07-964d-a1b4313e9ee3", new[] { 1 }, "3ba1f2e8-1718-4312-8eef-ecccfe034c83", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
                    { "23ec9735-6ec0-4cdc-bd19-e86d8f50fe04", new[] { 1, 2, 3, 4, 5 }, "ceec22ad-b4e2-4fc3-af3d-1440c078c83b", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
                    { "23f02d89-5785-4580-8b27-212f56e150b7", new[] { 1, 2, 3, 4, 5 }, "bf592c4b-8260-4f81-8c26-463f533f53bc", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
                    { "2a8e716d-660e-46bb-9b2d-b11dd9d06061", new[] { 4 }, "27896100-c7db-43fd-a92b-4bffcf8ad9f1", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
                    { "2b0aa983-3617-4ff8-9d36-552741bae6b9", new[] { 2 }, "1eb3a6ed-589b-4a7f-816a-5677375eb8a3", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
                    { "2b7fc8e5-11fe-46f0-876a-1ab32aa333c6", new[] { 3 }, "9197866f-4d58-42f0-b80e-d88c30e90252", "Pode visualizar um produto de fornecedor", "CanVendedorComissaoCreate", "CANVENDEDORCOMISSAOCREATE", "ac-vendedorComissao-page" },
                    { "2ba0b8d2-6668-424b-adc7-e0173bffa885", new[] { 1, 2, 3, 4, 5 }, "cd8065d3-456a-4931-b893-ac60680e15e3", "Pode realizar todas as ações/operações em dashboard comercial", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
                    { "2d3c09c1-fe51-4583-b2da-47a4530233b2", new[] { 2 }, "e8c24a37-512b-45aa-aa82-c77d7bd22491", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
                    { "32106e50-55bb-451a-a9df-68cefe745275", new[] { 5 }, "fad0c984-62ab-4e76-843e-072596fc4f5b", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
                    { "33d569e4-563b-49f5-a553-b099da248068", new[] { 1, 2, 3, 4, 5 }, "cd0f850a-df11-4edb-86a2-b1985d6d033c", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
                    { "349ea31a-7802-4017-8a2a-e835fd032ce4", new[] { 1 }, "402c937d-b43d-4864-b815-cd9786bd603e", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorList", "CANVENDEDORLIST", "ac-vendedor-page" },
                    { "3796b241-01a3-4d0f-81b5-64b3f028c403", new[] { 3 }, "ca9d70d6-20bf-481f-88d7-ece5d014e6d7", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
                    { "3a7dc460-3bf0-461c-870d-dfad47b86286", new[] { 4 }, "b916ae3d-63c4-4578-85d8-45425e94e691", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
                    { "3ab7e6a3-6c69-41d5-b2e0-018d63d17823", new[] { 1, 2, 3, 4, 5 }, "1b9325e7-502b-491e-b436-2bc7d95f53ea", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
                    { "3bd295b0-d89a-44f7-ae64-6b21db71972a", new[] { 2 }, "3a06d8a5-4d43-47ab-aa12-a5cfe85a8d11", "Pode listar os dados de um produto de fornecedor", "CanVendedorComissaoRead", "CANVENDEDORCOMISSAOREAD", "ac-vendedorComissao-page" },
                    { "3d9ed0ea-ec23-4a6e-a50c-807351453c0e", new[] { 4 }, "c50e0e98-1bb3-49b4-89cf-af66fec88207", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
                    { "3f230d2f-608a-47f7-a002-0cc99096d988", new[] { 1 }, "1069ced1-1b95-4cce-a151-357005d50f70", "Pode listar os dados de todos os produtos de fornecedores", "CanVendedorComissaoList", "CANVENDEDORCOMISSAOLIST", "ac-vendedorComissao-page" },
                    { "42c9ac34-ce40-4cc0-b847-b5403ad4d0bb", new[] { 3 }, "edf43242-273c-4482-a25c-2c56d4465043", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
                    { "4773921c-8d58-47c2-8510-fde528c8dfee", new[] { 4 }, "6f25b95e-2a70-4f15-90c9-50a5f1dfd34e", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
                    { "4cfe07e9-c79f-4df3-b0e3-7610b5d1133f", new[] { 4 }, "e4f28a22-161b-4e4b-9e9e-32f947f6f535", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
                    { "4ffd031b-94bc-4b9d-bf52-b1fad209e097", new[] { 1, 2, 3, 4, 5 }, "69bf75f8-3275-4fa4-a879-99c994a83df3", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
                    { "535b139f-338e-4f8f-8296-47e3f6a67b54", new[] { 1 }, "d50abede-9e64-4d2e-a2e5-975b3df569fe", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" },
                    { "537201d4-1e66-411d-99a6-1b676d3eb8d5", new[] { 5 }, "ab2608bc-2902-463a-a279-63061fc7f21a", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
                    { "571bc529-e7e2-423e-8a80-7bf87efd8684", new[] { 5 }, "cf42e462-b22a-494c-807e-6fbeec0f1c2c", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
                    { "58a853c0-7f33-4826-856c-fb6098fe4a7e", new[] { 4 }, "8434edbd-8bc9-419d-801f-cd1dbee67e5a", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
                    { "5a595bc2-1cbe-45c3-8dbc-2c161a601f95", new[] { 5 }, "c8ff6bb7-335d-4fdf-9e8d-c33fba0b74f9", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
                    { "5f2ba0c1-ad98-45c8-bb49-05579a1e4d3e", new[] { 1 }, "318c0bd9-ef41-4e1e-9c55-6c0d4a18354e", "CanDashboardPublicaClienteContratoList", "CanDashboardPublicaClienteContratoList", "CANDASHBOARDPUBLICACLIENTECONTRATOLIST", "ac-dashboardPublicaClienteContrato-page" },
                    { "60db8d3a-6571-4b60-8e9f-58e4e8c3f3c9", new[] { 1, 2, 3, 4, 5 }, "fff0151b-e742-4f31-9d14-921801e61eb9", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
                    { "626ab733-b80b-4917-b380-080caea0f790", new[] { 4 }, "44741a3b-5902-4810-932a-bbdac20cd6fb", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
                    { "62f89b64-a030-49b6-88e4-33598d5a060b", new[] { 2 }, "45e325bc-7d39-4945-91ae-e8d984b37e7c", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
                    { "6aa79c3d-1bf4-4ad1-89c2-13c62ab97309", new[] { 2 }, "e9eae2e7-6e9d-43f7-a740-bc21de160eb9", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
                    { "71e30f59-6276-44f3-8aa0-e424cfd81208", new[] { 1 }, "077fa2a2-445c-4055-a14f-9003e9ccda2c", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
                    { "776b82f4-71e2-4f59-bc97-3f83ba5f2263", new[] { 1 }, "0d68ad2b-a7c4-4376-b773-a55506b25525", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
                    { "79153eb7-8987-48f9-b0aa-089ff908116f", new[] { 4 }, "d618943f-3b8c-494b-98d5-41d783614343", "Pode criar um produto de fornecedor", "CanVendedorContratoUpdate", "CANVENDEDORCONTRATOUPDATE", "ac-vendedorContrato-page" },
                    { "7936b728-ae40-4d71-83b4-901ebbd1d7d4", new[] { 5 }, "e3ae289e-8f6c-4a40-82a0-a36192c878b1", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
                    { "7994dc30-c330-4f4e-8c3b-6aefea61dd0f", new[] { 1, 2, 3, 4, 5 }, "1c2caa0a-7587-479e-a932-b800967d4d5e", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
                    { "7a6b99e6-c9bd-4203-a99f-36243956fcec", new[] { 1, 2, 3, 4, 5 }, "8d90c4f4-c383-4362-a157-35c9b86205cc", "Pode realizar todas as ações/operações em dashboard publica", "CanDashboardPublicaAll", "CANDASHBOARDPUBLICAALL", "ac-dashboardPublica-page" },
                    { "7b6efe4f-6b1a-410d-b422-0749a7949e05", new[] { 1, 2, 3, 4, 5 }, "1a90ba50-cf4e-41c9-b6a3-5b87b30f3c55", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
                    { "7daf07eb-79d7-4578-8774-4c39823527bd", new[] { 5 }, "f3b9e46f-c45f-4d1b-8228-24a80166ac9e", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
                    { "7df8a52b-1f12-45ef-a40b-534701356316", new[] { 1 }, "ca7266b0-2c32-4a75-b8f2-5fddf16b8bb5", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
                    { "824c9fc4-2759-4d13-95e6-80448e5f0918", new[] { 1, 2, 3, 4, 5 }, "1656bccf-d7d4-4219-a622-19f16b862f38", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorContratoAll", "CANVENDEDORCONTRATOALL", "ac-vendedorContrato-page" },
                    { "834eb13e-c79a-40f4-9431-9221f50c7b7c", new[] { 1, 2, 3, 4, 5 }, "f509f4da-e0a4-422c-914c-454959d75cf7", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
                    { "84b0ad32-b39b-42a9-957b-1790b80df96e", new[] { 3 }, "e7c9ad92-deca-456d-8766-6971b9442165", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
                    { "8628972f-0762-4dfd-8928-d9cc59dbbb6b", new[] { 1 }, "13d8c04b-1dd9-4a88-a152-de444d8a58f2", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
                    { "883d37d6-fcf9-4747-bbe3-f76dc16c9738", new[] { 3 }, "1623f277-6357-4c7e-936f-32cb869ff8e0", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
                    { "93d83205-2471-46c2-bf65-4e55e8a7c368", new[] { 4 }, "3a88e1f2-e24f-40f0-843f-4f93bb3fddee", "Pode criar um produto de fornecedor", "CanVendedorUpdate", "CANVENDEDORUPDATE", "ac-vendedor-page" },
                    { "957abd60-544b-46cb-9098-e3562313d954", new[] { 1, 2, 3, 4, 5 }, "9139d5e0-680a-42d4-ba0d-e03b95a76c24", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorAll", "CANVENDEDORALL", "ac-vendedor-page" },
                    { "a2527067-93b6-464a-b2f8-a9586a8eead4", new[] { 1 }, "7ed41cb1-d0ac-4ed8-a741-ae53a47e677a", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
                    { "a62617b8-f9f8-4ea8-aa27-6b845922bed8", new[] { 4 }, "3c0cd844-f173-4d8a-9f69-96e53dfc3bf8", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
                    { "a6f2f812-3f58-4363-9ec5-22eb2d157aeb", new[] { 1, 2, 3, 4, 5 }, "96c044f2-96be-4615-8ad5-c13cbe93d5ee", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
                    { "a92f749e-fe5c-4ccf-8cc6-30d5c49daf11", new[] { 3 }, "818f8893-c044-451a-8efb-2723940e23cc", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
                    { "aacaf8ea-160e-4fdc-9384-37574641b0b1", new[] { 3 }, "40a52bf5-4ee4-4b43-9fcb-319fcc348f06", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
                    { "ae961b2f-c47e-410b-842b-a64076c9d1e2", new[] { 1, 2, 3, 4, 5 }, "a5fee100-14e4-452d-a530-f9545f2d43d1", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
                    { "b0f94f81-be79-4426-8463-456f5e03fc22", new[] { 1, 2, 3, 4, 5 }, "f7d556f4-aadc-4f18-8e38-364cd788c5c7", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
                    { "b16964ca-3689-41ba-b818-85b5295cb254", new[] { 2 }, "40e4cbac-bf12-414d-8e20-43b9e59a56bb", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
                    { "b422648b-c176-4141-b6b3-e7f9c69cf369", new[] { 1, 2, 3, 4, 5 }, "2c66c261-d9ec-4321-aa5b-6e4e4ffcd1f0", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
                    { "b6a6356b-072f-40fa-b343-b34367a43f8d", new[] { 4 }, "78a92850-fddc-4c7d-b5ad-5440f1a32826", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
                    { "b7518611-ddbe-4b7f-a402-b195730760a5", new[] { 1, 2, 3, 4, 5 }, "3c6f40d4-edc7-4f77-8007-ba155dc832c5", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanVendedorComissaoAll", "CANVENDEDORCOMISSAOALL", "ac-vendedorComissao-page" },
                    { "b8a7d54f-80c0-4691-97e2-a17c03aecce3", new[] { 4 }, "db851e58-6c5f-4ace-b96e-57fa94cc7c46", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
                    { "bbdb21d8-977a-4459-a068-1649bf2530ef", new[] { 4 }, "9efc75c7-dc31-4fd9-80e9-28d8f4cc6caa", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" },
                    { "bd024264-842c-460b-9e17-1ba12dcc72b8", new[] { 3 }, "5367eadf-7dbb-42d2-97ce-65129e48f180", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
                    { "be9b77cf-6cca-4e35-88d3-4aef073310ce", new[] { 5 }, "9b495098-8509-4bc1-bc81-c9e042e3c797", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
                    { "c12da038-3bd8-4b3c-b136-0a1c36917aec", new[] { 1, 2, 3, 4, 5 }, "cdcc945d-13cb-46cc-94fb-360b459f3802", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
                    { "c253cc91-acce-476f-bc38-769219e3dbac", new[] { 1, 2, 3, 4, 5 }, "5577c888-b88e-4bfb-8cf4-8c69ad7c9fb1", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
                    { "c29d3836-9e95-468c-bfd2-36ecf99366b4", new[] { 1 }, "c2fa6687-8b48-4212-aed1-ab90fbc48900", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
                    { "c495dbc8-2a36-483a-a18c-99c6c34a59f4", new[] { 5 }, "e306c74a-aefc-40cd-a8be-167c975dc4aa", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
                    { "c6f6c49a-9cd0-4378-b0ed-fbb49719a501", new[] { 1, 2, 3, 4, 5 }, "d6da6573-92b6-47b4-b378-bec4a9037ba3", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
                    { "c7f6c1ad-6720-4b07-ab5e-b4c641823ead", new[] { 2 }, "88564dc6-b4ae-4c51-a252-ff3c876762b6", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
                    { "cae1e04e-fd0d-44c4-8e34-25dee53f7ba1", new[] { 3 }, "83e72538-2608-4c64-87ba-690c21ee2f21", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
                    { "cb9653c5-e849-418a-b462-717cd4dcdeb5", new[] { 4 }, "ac020dba-aacb-49bd-937a-0e953293189e", "Pode criar um produto de fornecedor", "CanVendedorComissaoUpdate", "CANVENDEDORCOMISSAOUPDATE", "ac-vendedorComissao-page" },
                    { "cbb095b1-19d6-4873-8bc0-f583a017420a", new[] { 5 }, "c8080d0d-fe4f-40ff-88de-cfd18edac998", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
                    { "cdd97d7b-d3d5-4e48-9c76-dc28430985fd", new[] { 2 }, "0303fb31-ed0d-4a6b-ada2-dbb7ec416295", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
                    { "cf0210a1-28fe-44ae-9336-b4b4f4aefeb3", new[] { 5 }, "8c7f8925-d955-4a17-b863-88a24af660aa", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
                    { "d63c6669-b8b3-4d47-b16b-658460c1edd8", new[] { 3 }, "bb303e63-1641-4639-8e92-c66e03c4c6e1", "Pode visualizar um produto de fornecedor", "CanVendedorContratoCreate", "CANVENDEDORCONTRATOCREATE", "ac-vendedorContrato-page" },
                    { "d6601710-6272-4e4e-a6ee-4b2a7cfc682f", new[] { 5 }, "5d7d1573-864c-4b6a-aa11-a8a232dacd31", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
                    { "d696ea48-8b43-45e7-8679-5c6f04c5436d", new[] { 2 }, "bc0e5a51-dc05-459b-b634-a86601a2d777", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
                    { "df0e9010-f3f1-48cf-afd8-e6b4c9d0597d", new[] { 4 }, "def45492-bfc9-44ed-a1d2-0c5f899c948c", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
                    { "df7d0e84-c3a5-4de4-a624-1224f792949b", new[] { 2 }, "efc5dddc-0943-4401-8433-62644dc776c0", "Pode listar os dados de um produto de fornecedor", "CanVendedorContratoRead", "CANVENDEDORCONTRATOREAD", "ac-vendedorContrato-page" },
                    { "dfdd5b5b-edd1-4bc1-a09c-1dc4928b0e2a", new[] { 3 }, "a873a700-79cd-4d69-a747-31c77bf07a81", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
                    { "e11b2436-2ca0-4cfe-a929-f3da1500138f", new[] { 5 }, "85ec4efe-e769-4b61-be08-2c3bc36cc64d", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" },
                    { "e15937ef-395d-4488-85cc-d7e303653ff2", new[] { 1, 2, 3, 4, 5 }, "9f42e142-7d33-4ee3-b7b4-f21dd9ddf0a3", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
                    { "e5365261-e909-4f12-83bb-35aae4dd988b", new[] { 2 }, "3cbea139-2572-4d77-ab23-2cd63d2ccf2c", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
                    { "e581b61a-2f70-4533-bd5e-75e2c654ddda", new[] { 3 }, "99e09043-ae24-4d1e-98a8-22fd0e840667", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
                    { "e9ad4c3e-fd33-4989-bd7e-00024da1a52a", new[] { 1 }, "9dfe401f-dc41-4e7f-8971-098ada574a00", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
                    { "e9d5bf5c-f05e-46f5-a79b-abeb6d8756e9", new[] { 3 }, "c636fd2d-caa9-4f0f-80fe-5cd5299258ab", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
                    { "eb36462d-20b1-4133-a840-c28dd1495711", new[] { 1 }, "6de2cf99-85fb-4523-bc6e-fd3379408f3d", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
                    { "ed3a07c5-25a0-47b4-b2c7-ee256b52d0c6", new[] { 2 }, "9199a1fc-e5e2-4212-a78e-707feb64a573", "Pode listar os dados de um produto de fornecedor", "CanVendedorRead", "CANVENDEDORREAD", "ac-vendedor-page" },
                    { "ee5238e3-3130-433f-8ac1-fcfc027e8c95", new[] { 1 }, "3d904039-ee78-4463-87a8-be303cdbe3bc", "Pode listar o título do sistema", "CanTitleSystemList", "CANTITLESYSTEMLIST", "ac-titleSystem-page" },
                    { "efb4b1ae-c6a3-4810-af3b-e839ffafb9df", new[] { 1 }, "fcc008f2-bd65-429b-8cb7-b48f1042de29", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
                    { "f479e176-f3f6-455a-a4ec-51b34184eb6d", new[] { 1 }, "82faef94-562b-4fee-92d6-5f2a028bd6ed", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
                    { "f48271da-0362-4fa5-b53b-4d3ee04240f0", new[] { 1 }, "ec3474c4-ffb8-4dec-a1f1-c4bf0248e1b5", "Pode atualizar uma chave de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
                    { "f9447866-9348-433e-b671-e542b200bb88", new[] { 2 }, "eba876b2-eab1-41dd-a7b1-600e3434c132", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
                    { "ff0b12eb-4d86-47ff-ae2d-871cf221353c", new[] { 5 }, "ab06718e-99f0-4ebe-9fb5-3123f0b89c37", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" }
                });

            migrationBuilder.InsertData(
                table: "ChavesApiTerceiro",
                columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("06edad37-fbbc-477f-97da-4bde55b72f1c"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 12, 15, 13, 9, 54, 723, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 15, 13, 9, 54, 723, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendedoresComissoes_ClienteContratos_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId",
                principalTable: "ClienteContratos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendedoresComissoes_ClienteContratos_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0198772f-e7d7-4879-b6ca-1d0eeb9cd1f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "030e13d1-c1f3-4a18-aae6-7bcd728ac484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "039390cc-94a3-488b-9976-03e69bc9608d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "044cdc82-1775-4f6d-94d7-3cb932a675d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04caabb2-37a2-4ab9-9ace-048971c9b7f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ad746c3-954c-46fc-81c9-2aaf4775fb36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fb1ac02-08af-452f-88a4-d88fe2f41af2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fbdfe8d-6aae-454f-a603-71bb0cec4272");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1002b698-1f1c-4ecb-9ece-82789f628f21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1229a3c1-bac8-410e-b51d-2e90ab904e9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12365d9b-be40-4b9a-a4a6-eb315148d64b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1374676b-40f3-42db-9fa4-eade2107efa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15226821-4708-41a3-8d94-eeecc10cabe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1695b933-6c1b-45c2-bd1d-51d31032ac47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d75209-3355-48ac-b65b-0c881d047bcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1953c3f5-75d8-4a5f-a289-f14620b22c95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d5d17a1-c3c0-425d-91b2-a17a037642a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f78fdfb-27f8-4e27-bdc9-7f877e06646c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fcf4f3f-4838-4e07-964d-a1b4313e9ee3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23ec9735-6ec0-4cdc-bd19-e86d8f50fe04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23f02d89-5785-4580-8b27-212f56e150b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8e716d-660e-46bb-9b2d-b11dd9d06061");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0aa983-3617-4ff8-9d36-552741bae6b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b7fc8e5-11fe-46f0-876a-1ab32aa333c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ba0b8d2-6668-424b-adc7-e0173bffa885");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3c09c1-fe51-4583-b2da-47a4530233b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32106e50-55bb-451a-a9df-68cefe745275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33d569e4-563b-49f5-a553-b099da248068");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "349ea31a-7802-4017-8a2a-e835fd032ce4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3796b241-01a3-4d0f-81b5-64b3f028c403");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a7dc460-3bf0-461c-870d-dfad47b86286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ab7e6a3-6c69-41d5-b2e0-018d63d17823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd295b0-d89a-44f7-ae64-6b21db71972a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d9ed0ea-ec23-4a6e-a50c-807351453c0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f230d2f-608a-47f7-a002-0cc99096d988");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c9ac34-ce40-4cc0-b847-b5403ad4d0bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4773921c-8d58-47c2-8510-fde528c8dfee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfe07e9-c79f-4df3-b0e3-7610b5d1133f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ffd031b-94bc-4b9d-bf52-b1fad209e097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "535b139f-338e-4f8f-8296-47e3f6a67b54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "537201d4-1e66-411d-99a6-1b676d3eb8d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "571bc529-e7e2-423e-8a80-7bf87efd8684");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a853c0-7f33-4826-856c-fb6098fe4a7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a595bc2-1cbe-45c3-8dbc-2c161a601f95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f2ba0c1-ad98-45c8-bb49-05579a1e4d3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60db8d3a-6571-4b60-8e9f-58e4e8c3f3c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626ab733-b80b-4917-b380-080caea0f790");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62f89b64-a030-49b6-88e4-33598d5a060b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aa79c3d-1bf4-4ad1-89c2-13c62ab97309");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e30f59-6276-44f3-8aa0-e424cfd81208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "776b82f4-71e2-4f59-bc97-3f83ba5f2263");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79153eb7-8987-48f9-b0aa-089ff908116f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7936b728-ae40-4d71-83b4-901ebbd1d7d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7994dc30-c330-4f4e-8c3b-6aefea61dd0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a6b99e6-c9bd-4203-a99f-36243956fcec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6efe4f-6b1a-410d-b422-0749a7949e05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7daf07eb-79d7-4578-8774-4c39823527bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7df8a52b-1f12-45ef-a40b-534701356316");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824c9fc4-2759-4d13-95e6-80448e5f0918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "834eb13e-c79a-40f4-9431-9221f50c7b7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b0ad32-b39b-42a9-957b-1790b80df96e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8628972f-0762-4dfd-8928-d9cc59dbbb6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883d37d6-fcf9-4747-bbe3-f76dc16c9738");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d83205-2471-46c2-bf65-4e55e8a7c368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "957abd60-544b-46cb-9098-e3562313d954");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2527067-93b6-464a-b2f8-a9586a8eead4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62617b8-f9f8-4ea8-aa27-6b845922bed8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6f2f812-3f58-4363-9ec5-22eb2d157aeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92f749e-fe5c-4ccf-8cc6-30d5c49daf11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aacaf8ea-160e-4fdc-9384-37574641b0b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae961b2f-c47e-410b-842b-a64076c9d1e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f94f81-be79-4426-8463-456f5e03fc22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b16964ca-3689-41ba-b818-85b5295cb254");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b422648b-c176-4141-b6b3-e7f9c69cf369");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6a6356b-072f-40fa-b343-b34367a43f8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7518611-ddbe-4b7f-a402-b195730760a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a7d54f-80c0-4691-97e2-a17c03aecce3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbdb21d8-977a-4459-a068-1649bf2530ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd024264-842c-460b-9e17-1ba12dcc72b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be9b77cf-6cca-4e35-88d3-4aef073310ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12da038-3bd8-4b3c-b136-0a1c36917aec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c253cc91-acce-476f-bc38-769219e3dbac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29d3836-9e95-468c-bfd2-36ecf99366b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c495dbc8-2a36-483a-a18c-99c6c34a59f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f6c49a-9cd0-4378-b0ed-fbb49719a501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7f6c1ad-6720-4b07-ab5e-b4c641823ead");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cae1e04e-fd0d-44c4-8e34-25dee53f7ba1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9653c5-e849-418a-b462-717cd4dcdeb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbb095b1-19d6-4873-8bc0-f583a017420a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdd97d7b-d3d5-4e48-9c76-dc28430985fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0210a1-28fe-44ae-9336-b4b4f4aefeb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d63c6669-b8b3-4d47-b16b-658460c1edd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6601710-6272-4e4e-a6ee-4b2a7cfc682f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d696ea48-8b43-45e7-8679-5c6f04c5436d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df0e9010-f3f1-48cf-afd8-e6b4c9d0597d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df7d0e84-c3a5-4de4-a624-1224f792949b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfdd5b5b-edd1-4bc1-a09c-1dc4928b0e2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e11b2436-2ca0-4cfe-a929-f3da1500138f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15937ef-395d-4488-85cc-d7e303653ff2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5365261-e909-4f12-83bb-35aae4dd988b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e581b61a-2f70-4533-bd5e-75e2c654ddda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ad4c3e-fd33-4989-bd7e-00024da1a52a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d5bf5c-f05e-46f5-a79b-abeb6d8756e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb36462d-20b1-4133-a840-c28dd1495711");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed3a07c5-25a0-47b4-b2c7-ee256b52d0c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee5238e3-3130-433f-8ac1-fcfc027e8c95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb4b1ae-c6a3-4810-af3b-e839ffafb9df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f479e176-f3f6-455a-a4ec-51b34184eb6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f48271da-0362-4fa5-b53b-4d3ee04240f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9447866-9348-433e-b671-e542b200bb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff0b12eb-4d86-47ff-ae2d-871cf221353c");

            migrationBuilder.DeleteData(
                table: "ChavesApiTerceiro",
                keyColumn: "Id",
                keyValue: new Guid("06edad37-fbbc-477f-97da-4bde55b72f1c"));

            migrationBuilder.DropColumn(
                name: "ComissaoPercentual",
                table: "VendedoresContratos");

            migrationBuilder.DropColumn(
                name: "ComissaoReais",
                table: "VendedoresContratos");

            migrationBuilder.AddColumn<int>(
                name: "ComissaoPercentual",
                table: "Vendedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ComissaoReais",
                table: "Vendedores",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddForeignKey(
                name: "FK_VendedoresComissoes_ClienteContratos_VendedorId",
                table: "VendedoresComissoes",
                column: "VendedorId",
                principalTable: "ClienteContratos",
                principalColumn: "Id");
        }
    }
}
