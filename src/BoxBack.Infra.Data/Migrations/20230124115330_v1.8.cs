using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "01cb5b35-ac32-49f4-a53b-474290066341");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "020aac79-58f1-4098-9953-8b51ef499c15");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "032b0f41-9fb7-4c08-a2a2-24622 16abe63");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0504e7bd-7781-4613-9a96-196530c36287");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "08e51725-3c71-4de4-b6fd-4b9b40815ff5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0b44358b-b206-42a8-9d45-9256825d13a0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0d5b8ded-8481-445c-9d30-c37d9d3a0b28");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0e4ddc3f-e334-4492-aeb3-8e9f53dd55f1");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1155f307-eaba-45bb-8269-017870d4b35b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "15732b5b-69a1-4377-ac00-04fc85b51bbf");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "175a5db6-725d-4a65-9a6e-e1524926ab2e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "19f4cb22-74e9-4eee-9b59-cb4c02ece493");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1b07d539-c496-413e-ab4a-0367d64f0aba");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1c1006bf-2e42-4ca7-b341-28bbdd0ddd83");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1c9719b0-3e86-4854-97b3-cc537b673c7c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1cfa5695-571a-4f86-95f9-019157a438d6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1fceeb52-d49b-4435-83c5-0df368cf9e02");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2276e451-0526-4585-9a72-fd4bf035ccf3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2312500c-14bf-46cc-9ef5-82197cec6802");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "23c5a47d-f6b0-4a2c-8e0a-3ba3e50a597d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "23d6b762-8461-4c3f-b9f7-fbef9b94c57f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2552dcb4-da38-4668-bf88-e7df25688317");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "268fda58-2a65-4d53-840a-9fa1843d1f28");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "26c4b410-8922-4f8d-b68c-7239ca180876");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "28b1f836-f7ef-4651-b97d-06fd33107abd");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "295afcc5-1691-48f9-bcf4-38eb472a3bc5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "29dd8437-c26d-40e3-ac26-de4923d55326");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "29fcb479-301c-457e-b9b7-1d870b170884");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "33721ce6-e228-48ac-850a-ff7588319315");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "33e48694-c90c-451c-b69b-4723eb88a1b2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "35a55e98-6ecd-4293-9168-9ec783a12c85");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "38c7c998-d564-4533-b648-cb6cda2a3c2b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "38efb290-228d-4292-92b9-38be763a10a7");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "3e4bbb05-42d4-4706-9cd8-63cf737b5c76");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "3e5a5862-c63b-4dd2-8766-6309996b5638");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "42260cbe-4ebe-4018-ad51-e9700281029f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "43366c38-2876-41c3-b9c5-18f2c0311f66");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "47c7e3af-2291-4309-84b0-7d0fd24059fc");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4981c700-9fcc-4d4a-b7cb-272c9048fb8a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "49a44459-7b88-4d4b-8cb6-a09e8a03b420");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4a739549-7512-4329-b2b4-ff6f638ee5a2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "511fe119-f53a-47c1-8745-643f8e349c37");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5179f2e9-d838-48ba-9ca3-716076d66dca");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "52c0f0ec-4476-45fe-b114-a8975ee2bc7f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5324fd04-1bd1-4794-8ab8-efbc5a821c55");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "569e5883-a0b9-430b-8b63-e68e2602d706");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5805bc43-ac33-45b4-a27d-df8386e76d7d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "583073cc-a5cb-4a44-a069-ad310547e706");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5a9e5e40-e115-461b-9be7-d311b0034dac");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5bef938a-f4ba-4b16-b4f4-2378cf552a8e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5ebf202c-80ed-4a4b-a4d5-b90a96a7bb41");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "62e62a0d-554e-41b3-8ca3-3741b635a110");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "67c32341-8bb4-46d8-b32a-7fc7936ae3cf");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6a6c7633-a368-47d5-8e50-0fbd98d69ca6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6b2cde43-d01c-4515-a27d-038fedac9d0b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6bf47b91-c240-48b4-831d-73a3d4aa8f8c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6e2aadd0-f602-4994-8be1-7335841e2833");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6ec1a617-e64f-474d-9919-5ff12fcd3db3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "7762c29c-54cd-4aee-99c3-ff137477a62f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "77f38da9-6ec3-45b4-8aa0-e5304643bbc5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "7dcdf7d4-5893-4852-988f-bdaf2050b72f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "800e5440-7418-4e7a-a9f9-be1d6b3839ad");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "80577342-1614-4f59-950b-c11be1154b68");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "806a3871-9d97-4e61-a256-c4be7f5fd5d7");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "80cc9503-68bd-4c00-8b49-79dbee4d5865");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "83872a28-bc5d-4cb5-be96-62a383f7591d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8b670ed0-2309-489d-a2d3-303b426ce48a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8ce77d59-d2ae-42be-95ea-59cf4367c208");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8e6dcf1d-2811-450a-9dbc-239bcb5b1206");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "90e0f385-d4dc-4333-b0d5-db253975fe53");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9232ceeb-750c-4541-b08e-96b4e7098349");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "97fab8af-928c-407b-8b22-21621a14f966");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "98107257-6d0a-476a-a168-b381f35495b0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9cd9443f-b2ea-4687-825c-8f052a35741a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9d3bbf52-658c-4394-9a0f-58cd89ac5aee");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9f1760d1-01bb-4120-a18c-965d4f5012c8");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a2bbd3be-b8ce-4321-9741-81c03efc610a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a2ce58be-a29f-47c9-bab0-e8a6c06476c2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a6b939c2-5608-4c79-b4c3-08fa0b429bcf");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a71163a1-dc83-4e94-b217-7a97efc0e581");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a77c203d-ac9f-4fca-8ccf-973b4da1b380");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a7ea47d8-ddc1-4dfe-9947-9405c908dcdd");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a920cd4f-0348-47b4-a092-3dcee3302321");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a9b49c93-b0f3-4f02-b4c6-00eebac46768");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "aa6b5b30-fb88-4f5d-8d1e-655e8d037a36");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ac66de24-7be5-4562-a810-876ef9d51c9d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b20c4735-935d-4eb6-b52f-5707737feeb5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b359df5a-a976-4968-9c84-f75e9d589748");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b60fcbca-1396-48d8-bfc6-2ade7d83a0e8");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b8c257ea-d285-4e2c-b78f-57ca3e94914f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b9e8caea-1efc-43ad-a192-38424750a8be");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "bdfd8af9-cbaa-45ee-848f-655d0fef94a1");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c0e784a2-0da9-438a-9ab4-03442d1aa406");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c5d14df8-7d4b-44ce-b3cf-c11191c5cef1");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "cf0d1a3f-572b-49fb-b4c7-43fb3a67ecb0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d0437f3a-01af-4b90-84c1-76ef30302ba0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d1caad0b-6144-47c8-990f-440ad8e0d9e6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d48df6b3-8980-4307-a18e-e9e62d39220f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d4a88bb1-41ce-4c2b-adf5-981bce86d31c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d630b732-d1b5-4eea-a522-24c9b70f646a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d641a5dc-9b77-4a5f-be1d-c5a9bc2feca8");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d6693bbb-cebb-447f-8e34-ff2406c6a663");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d66b1b10-45e0-42cf-979e-fa7331f188dd");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d76420b9-679e-4228-9e90-b18f016c892a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d800fcd5-fa7f-4e74-8609-958252ad2768");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d8e6a17e-4a72-405e-8f59-203b7fbda34b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dc2b83cf-1288-4f0a-843d-c0c36dd22911");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dc50cea3-c74c-497f-b1c7-4959950a823c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dc85707e-363f-47dc-9dff-be1cbd6b4ecf");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dcea8d21-44c7-4d29-b175-d5096ebeee2e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dd1079f7-f351-4104-96bf-12bf9ded9d89");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "deaa6e06-6135-48a7-b77e-882d62c2998d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "df65ac42-b0ab-4655-b53a-2843d74603f2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e166ac6b-f975-40ff-986f-db41a2228852");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e2f9b919-c5ed-451c-8125-693aadb68a49");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e4ac0a28-d024-48f8-9929-209a058641e9");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e6632632-425e-47d7-8dfb-f586c0521015");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e961cc22-5414-48bb-9de0-b574df4591c3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "eb44f73e-0410-4914-be7d-5871f3a2dd9e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ed070297-7fff-4ae1-8c75-25168daa85bb");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f04e4519-724d-48f7-bbfd-46014478e9b6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f0f62193-bed7-4040-b438-f9fa025da083");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f5b28a98-524a-43fa-b650-71e69e2ef7d1");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f8384892-39f2-442a-b948-a0f647898e90");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f8c89084-01de-4cf7-a297-2f3c1fac8c72");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f964bc3f-de68-46a9-b1c6-21fd3945fed5");

            // migrationBuilder.DeleteData(
            //     table: "ChavesApiTerceiro",
            //     keyColumn: "Id",
            //     keyValue: new Guid("eeeb471a-2d8c-4bd3-b772-974a3d8612e5"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("06cbc6d5-216a-45f9-8496-d0d2fe93bcf3"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("2556044d-dcdc-4355-9e57-d1fa336a5363"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("52538e24-79c2-4eca-823c-e124a8b4a213"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("587a5f91-37ec-42ce-a79f-229d6a4d43a8"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("6c0ff275-2dd5-42a0-b488-e0665616fd24"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("85611459-4fa5-422a-b6ac-1a5bd5a83d9a"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("ac9faa63-bdff-4c0a-8469-b188f710cae7"));

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 482, DateTimeKind.Unspecified).AddTicks(1223), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 482, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, -3, 0, 0, 0)) });

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
            //     values: new object[,]
            //     {
            //         { "010ca467-0bde-450f-8126-fc00c9fbb841", new[] { 1, 2, 3, 4, 5 }, "80f1fb47-b23d-45a5-b783-95114da064cb", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
            //         { "012c67b8-23e9-4925-8616-2aaae38019ec", new[] { 1 }, "a9f651b1-1bf4-41cf-ac01-81b6853cd4db", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
            //         { "012c88c2-1c3c-43bd-9d68-44fc6c4ce3b9", new[] { 5 }, "0f5db589-de67-4e73-84f3-9de3eec2bf84", "Pode deletar uma comissão de vendedor", "CanVendedorComissaoDelete", "CANVENDEDORCOMISSAODELETE", "ac-vendedorComissao-page" },
            //         { "01b8e389-9cf8-45d7-bea1-f545794702a6", new[] { 1, 2, 3, 4, 5 }, "e9920a8e-3d1b-4ebc-8bf6-c4549f8beaf8", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
            //         { "02225a2c-2c73-4a57-8e03-75425f103f70", new[] { 4 }, "d3e157ea-6772-415f-ab85-84922f58114c", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
            //         { "043bb06a-3238-4bcc-9d13-437a4f23e554", new[] { 1, 2, 3, 4, 5 }, "748bfd42-16c5-4431-a233-9da39cad30b8", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
            //         { "04c3b6a4-185e-40f6-aa02-ae7bd9f22602", new[] { 1 }, "c9b4722d-c3fa-4020-b3b0-8a9ef28cf741", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
            //         { "0ab971dd-72a9-4a25-96ff-6fa2779807e2", new[] { 4 }, "c8742458-ddcb-416c-a8b2-d7d9105c0e9d", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
            //         { "0fae21d9-bb3f-4135-b235-d2e1928d8332", new[] { 3 }, "fb08b519-bdd1-4722-8a3d-c28c55395847", "Pode visualizar um vendedor", "CanVendedorCreate", "CANVENDEDORCREATE", "ac-vendedor-page" },
            //         { "152da1d6-10de-446d-9478-f7f0ae983e95", new[] { 5 }, "17615f0e-6ea7-4273-ac3a-1c1a41a0505e", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
            //         { "15b23a65-bb25-411f-ac81-c302f117afac", new[] { 1 }, "5d194722-ebc9-4323-bb8f-b249c6861e55", "Pode listar o título dos negócios", "CanTitleBussinesList", "CANTITLEBUSSINESLIST", "ac-titleBussines-page" },
            //         { "173c622e-08ac-4133-aaca-998c0d549d0c", new[] { 5 }, "bd4085bd-866d-4c1e-be5c-065f4c0a631d", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
            //         { "183e964c-aa88-4f52-acce-87f77f7bb362", new[] { 5 }, "f4d74829-bdb3-4bfd-94a5-37430e5ef685", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
            //         { "18f2a597-ab5b-4ec9-a22a-23ba88da760d", new[] { 3 }, "e91dc247-239e-4548-9371-a66828484ed5", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
            //         { "1ac134b0-ba45-4dc1-8f2b-62b9ecb64fca", new[] { 3 }, "efce0d7b-534e-4ec4-b183-508ea7af8572", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
            //         { "1ddbc919-3a6d-49ba-9a93-01739bbecdc1", new[] { 4 }, "5c5d9634-db59-4688-b88a-82009945d4f6", "Pode atualizar os dados de rotinas", "CanRotinaUpdate", "CANROTINAUPDATE", "ac-rotina-page" },
            //         { "1de5a91e-84f4-4cb3-9750-0fa094c862d3", new[] { 3 }, "71ef4a3f-ce0c-43ea-858b-e263e59470c4", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
            //         { "1ef17409-ea04-4947-a01e-8707f13fc286", new[] { 1 }, "96646554-e650-4ca5-8112-692ef83944cf", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
            //         { "1fff078f-2c84-4254-857c-35b18b9f4d1e", new[] { 2 }, "1ded5dc7-60c0-4405-bd00-45e92cb14de2", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
            //         { "21612f29-c23e-42c0-88b9-b2004f656d1d", new[] { 3 }, "d3b123eb-5344-4443-bd61-7085bf61c21b", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
            //         { "21e66e31-b8e9-46ef-aed7-dd55efc873f3", new[] { 5 }, "02f75208-cba3-4abb-a896-ceb7f517c5f6", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
            //         { "22d8534e-6db4-4755-b6c3-eee0d4680359", new[] { 1 }, "27df55dc-a490-4fe8-9ee2-4eb6c06a4dc3", "Pode listar os dados de todos os contratos vinculados a vendedores", "CanVendedorContratoList", "CANVENDEDORCONTRATOLIST", "ac-vendedorContrato-page" },
            //         { "23e7bc2d-c01f-4fca-ab65-a1cfbfe3494b", new[] { 2 }, "13f1a476-7eb8-4e11-89a6-da6ba646e781", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
            //         { "2786d48c-183e-47f6-9b80-72050bf57a7e", new[] { 1, 2, 3, 4, 5 }, "4291e44d-f8e1-4cd7-bbfb-1be5c86f36ba", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
            //         { "27906c3c-640a-4283-bf07-c1bf06ec2cc3", new[] { 1, 2, 3, 4, 5 }, "f98cc582-fd3d-45ac-8375-405e8358fd8d", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
            //         { "28c83627-aaf3-4a9b-982f-15635ea61f5e", new[] { 4 }, "06ec8f86-280d-4f05-a0c7-055d42cd55c5", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
            //         { "2ac74703-6cad-4bb6-953f-397c5c85451f", new[] { 1 }, "02598490-cd3d-4d79-ab19-69ebdede87de", "CanDashboardPublicaClienteContratoList", "CanDashboardPublicaClienteContratoList", "CANDASHBOARDPUBLICACLIENTECONTRATOLIST", "ac-dashboardPublicaClienteContrato-page" },
            //         { "2b476346-9db8-44c7-ac65-1ff1ab5f3876", new[] { 5 }, "2426fd45-60fb-47af-a947-8759edd5f05b", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
            //         { "31b05c2f-515a-42b8-80d6-11a286d1b433", new[] { 1 }, "5c03b032-573f-4a68-8f96-219d25783f30", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
            //         { "39d039a1-b129-439b-a5b6-d35cebfa0f1f", new[] { 1 }, "781ad781-3f2e-4e96-91a4-533daa16a283", "Pode listar todas as rotinas de sistema", "CanRotinaList", "CANROTINALIST", "ac-rotina-page" },
            //         { "3ae13c1e-4d7a-4f55-ab5e-a4d77ec1e852", new[] { 2 }, "5b19d90a-425a-4bc0-8870-13f21eff60c9", "Pode listar os dados de um vendedor", "CanVendedorRead", "CANVENDEDORREAD", "ac-vendedor-page" },
            //         { "3e49b1fd-eb10-4a65-92fc-9a5b7edaee76", new[] { 5 }, "5eaf3478-97a8-41cc-906b-1165d2f97265", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
            //         { "409e55a7-ede5-4b73-aca9-de4ffff4f012", new[] { 1, 2, 3, 4, 5 }, "a0126836-a7b7-412f-8ae0-d7341b31a897", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
            //         { "41a6a347-4597-491d-bfa2-82e7c2eb84af", new[] { 5 }, "c935b7a1-7bf6-4c4b-899b-eabf6f85fc24", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
            //         { "41b4a59f-62e6-46e6-a812-0e656fde1d91", new[] { 2 }, "eb212e92-da53-45cb-9df6-543275e3b573", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
            //         { "4822123b-6332-420c-9d4b-88f5d020f5c6", new[] { 3 }, "38ab5f42-3726-4753-b6b1-eee0db9c88a5", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
            //         { "4c9972c2-5a42-4f10-ad2a-cfcbe147a06a", new[] { 2 }, "05f3b507-3ae4-42a7-a80d-cf3f143a18b5", "Pode listar os dados de um contrato vinculado a um vendedor", "CanVendedorContratoRead", "CANVENDEDORCONTRATOREAD", "ac-vendedorContrato-page" },
            //         { "4e9a49a2-580e-4c4a-9b6b-3f99f6e30c33", new[] { 2 }, "76f20286-5487-45f0-8f6f-81439f1aa0d4", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
            //         { "4ea9a8ec-b6ec-49b2-9f1b-47041c6109e7", new[] { 3 }, "8db30146-3db3-4c4a-9680-c183e11874d3", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
            //         { "53167d05-7ad7-4d14-896b-c189817ac80f", new[] { 5 }, "5a63e384-4b7b-44f6-b67b-543cb9994553", "Pode deletar uma fatura de contrato de cliente", "CanClienteContratoFaturaDelete", "CANCLIENTECONTRATOFATURADELETE", "ac-clienteContratoFatura-page" },
            //         { "572a2a04-3727-4412-914b-0a7a2f772b2b", new[] { 2 }, "1c373c55-65b5-4e47-9329-b9ed1002859c", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
            //         { "58bd775b-4f28-4213-993d-5c50cb9087d2", new[] { 5 }, "fff67a3d-54b3-4c49-90b3-88493506526a", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
            //         { "5add918c-35d4-4dc8-b0ab-e3f95228a65f", new[] { 3 }, "3682a117-4789-42d4-9a78-d502f38594cc", "Pode visualizar uma comissão de vendedor", "CanVendedorComissaoCreate", "CANVENDEDORCOMISSAOCREATE", "ac-vendedorComissao-page" },
            //         { "60c536d5-e5e7-4a8a-9707-67931181a144", new[] { 4 }, "90fb8b7a-379c-46f2-836b-6eda54b0bfd6", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
            //         { "67d3a714-8d20-43b7-b6a8-b61747c6e44e", new[] { 4 }, "2386f7b6-85c2-4133-918b-6cefdd35da76", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
            //         { "695c661f-64b3-4b0a-90c6-0186581711ed", new[] { 4 }, "ea49db02-5083-49da-bfd7-33c45b39eb31", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
            //         { "6e36f8d7-83f4-43fc-b995-1f19d2503151", new[] { 1, 2, 3, 4, 5 }, "00941a7b-f275-4c31-aa0c-3ace6a5581a7", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
            //         { "6f20e719-d56e-4b29-90c3-fad735274de3", new[] { 1, 2, 3, 4, 5 }, "59067293-6bd6-4272-b051-0fb60017aa18", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
            //         { "71932d72-c275-456e-b7aa-24a55e6b4c6e", new[] { 1 }, "53c93501-1331-458d-824e-07d3c6e54e05", "Pode listar os dados de comissão de vendedores", "CanVendedorComissaoList", "CANVENDEDORCOMISSAOLIST", "ac-vendedorComissao-page" },
            //         { "745dfafa-f7b2-415c-b8f0-ba7cb2f41805", new[] { 1, 2, 3, 4, 5 }, "d9c2c163-b6f7-4ae1-91e0-ccfeb285fe1a", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
            //         { "754a0444-6d81-4661-b6a0-54858f751941", new[] { 1 }, "066058d1-5fb7-4c3f-81e6-11cb901fe8c0", "Pode listar o título do sistema", "CanTitleSystemList", "CANTITLESYSTEMLIST", "ac-titleSystem-page" },
            //         { "75beb8ed-d1e8-4074-9273-8acd5ea378ef", new[] { 1 }, "9ba6a93b-0e01-4564-95c4-10899ec91d91", "Pode listar os dados de todas as faturas de contratos de clientes", "CanClienteContratoFaturaList", "CANCLIENTECONTRATOFATURALIST", "ac-clienteContratoFatura-page" },
            //         { "76389d03-89fb-401c-91e0-86461c56854a", new[] { 1, 2, 3, 4, 5 }, "7d44e2f4-21d9-4d79-b963-a255d16c296a", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
            //         { "76fe43a5-dfa9-40b8-9097-d85f2445697f", new[] { 1 }, "30cf7bc9-d46d-4f63-90b2-bb3f93d730e5", "Pode realizar todas as ações/operações relacionadas a relatórios de vendedores", "CanVendedorRelatorioComissaoList", "CANVENDEDORRELATORIOCOMISSAOLIST", "ac-vendedorRelatorioComissao-page" },
            //         { "7863d7d3-9b18-44fc-9fe5-bd49dadad71f", new[] { 1, 2, 3, 4, 5 }, "00244c9b-b3d5-467c-bdb5-ae288670cef0", "Pode realizar todas as ações/operações em dashboard publica", "CanDashboardPublicaAll", "CANDASHBOARDPUBLICAALL", "ac-dashboardPublica-page" },
            //         { "7fda4629-1373-41cc-8723-e418d6181b76", new[] { 1, 2, 3, 4, 5 }, "cd91f112-f853-4a14-a599-4c338a882081", "Pode listar todas as rotinas events histories", "CanVendedorRelatorioAll", "CANVENDEDORRELATORIOALL", "ac-vendedorRelatorio-page" },
            //         { "8c53566d-9e38-4532-9a06-20028bcc195c", new[] { 1 }, "10579ea1-8266-4366-8c01-f6a2c9d38333", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
            //         { "8cedba76-dca3-4708-8cdc-d1946593a2c4", new[] { 4 }, "c363cc86-dbf4-4e8b-8a11-3523cec9e897", "Pode criar um vendedor", "CanVendedorUpdate", "CANVENDEDORUPDATE", "ac-vendedor-page" },
            //         { "8da80b14-e29a-414c-8592-45ff68b94846", new[] { 3 }, "a8b32ed6-f760-4d88-93b3-581adcf45963", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
            //         { "8f05a09a-8ed1-49e5-a54e-5a606fe3a14d", new[] { 1 }, "7fc19424-ba61-46d4-99bc-be17e5b3992f", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
            //         { "9085129d-c364-4e31-9ca2-e5dc4d0a0753", new[] { 1 }, "527e0245-5864-4002-b335-9118451937a6", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
            //         { "943b2365-b5c9-4fda-a442-0f22b513b998", new[] { 5 }, "1197092d-ecce-4be2-8da4-c43ff7cd6f23", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
            //         { "957e61fd-7f4d-4568-b9d1-1221c0eed23d", new[] { 4 }, "271e7d43-2dbf-46b1-975e-6a085ed82f04", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
            //         { "975b2fc8-7fc3-4260-b2bf-cef28d985f14", new[] { 1 }, "e0bb45fe-b8e3-44b4-a5a1-d3696bcd57a6", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
            //         { "984d63be-8187-4769-a48d-18927ab14852", new[] { 2 }, "47cd528f-847a-4378-80f7-34f05c953a16", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
            //         { "9923cc10-6d73-4375-a551-a6767d67bbf2", new[] { 4 }, "652afc22-a8ac-4d29-a0b3-b7421180babb", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
            //         { "9a27bfa2-ebe3-411c-9a99-eac681b451eb", new[] { 1, 2, 3, 4, 5 }, "5f445f25-300a-4951-8307-570be0555ad5", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
            //         { "9de3482f-27a6-4353-b41b-fb0732084fd5", new[] { 2 }, "d086c4c9-f218-4d75-b6b8-e9389a44a909", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
            //         { "9e0978d1-c3ef-4895-bc8b-b7befd6467c9", new[] { 1 }, "11b61624-8453-487d-9a77-085c23bb8c54", "Pode listar os dados de todos os vendedores", "CanVendedorList", "CANVENDEDORLIST", "ac-vendedor-page" },
            //         { "9e5bba0a-a23f-4e5a-af8a-06874cca9c76", new[] { 1, 2, 3, 4, 5 }, "f3302af8-7f15-4aa6-bf4c-71c398fb5f41", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
            //         { "9ed8895a-7da7-454a-ad84-1e558aecef03", new[] { 4 }, "eb515233-19c9-471c-8683-6fc91d67f6a5", "Pode criar uma comissão de vendedor", "CanVendedorComissaoUpdate", "CANVENDEDORCOMISSAOUPDATE", "ac-vendedorComissao-page" },
            //         { "a22e43c8-150f-4c21-ba5d-e2bef3bdd389", new[] { 4 }, "b75cf8dd-5ac6-477e-99ed-eb6ec73c0208", "Pode criar um vínculo de contrato a um vendedor", "CanVendedorContratoUpdate", "CANVENDEDORCONTRATOUPDATE", "ac-vendedorContrato-page" },
            //         { "a2cd6864-650d-4ade-85cd-08ae7a5836dd", new[] { 1 }, "36dd0e1d-bf85-42b1-8275-7b0384a1cd02", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
            //         { "a879a476-4433-4594-bee2-ddd835b1c972", new[] { 1, 2, 3, 4, 5 }, "25b1333b-e3a5-4b13-8864-fa176601a318", "Pode realizar todas as ações/operações em todos os vendedores", "CanVendedorAll", "CANVENDEDORALL", "ac-vendedor-page" },
            //         { "aa567199-2285-4354-bc03-09e55e83b549", new[] { 4 }, "09fd160f-a1df-4554-ab02-757f4ab7fde2", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
            //         { "aaee8960-8d14-487e-a5af-166d51d4f28e", new[] { 3 }, "0a8bc992-2005-4616-9bab-1136e3c1fd8f", "Pode visualizar uma fatura de contrato de cliente", "CanClienteContratoFaturaCreate", "CANCLIENTECONTRATOFATURACREATE", "ac-clienteContratoFatura-page" },
            //         { "ab36a405-1e92-4e16-839d-315c707a0647", new[] { 1, 2, 3, 4, 5 }, "0747a6dd-9cac-4947-8379-b7711ce8bcf5", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
            //         { "ab8b265b-efba-4c71-8f71-bce2ed41f969", new[] { 5 }, "030cfaba-a175-4bb1-b8c9-af1fea874f4a", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" },
            //         { "ada32923-d1b9-4c49-a4f0-2f4ebf09d1ce", new[] { 5 }, "95a57db7-382a-41e3-99d8-4c03ddf6bb63", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" },
            //         { "ada5db28-57e5-491f-a21c-cf34679e186f", new[] { 4 }, "324d01ca-e1c4-4047-bf9f-4f554ca7bacf", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
            //         { "b0a896ad-8c8a-4f82-8888-f44f0870df93", new[] { 2 }, "b2c7c6ea-e390-4916-b676-6e1895c7b64f", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
            //         { "b31eb583-1838-49ab-ad76-4dd9d5ef2d9b", new[] { 3 }, "e285e53b-1a5a-4d41-9b1c-5975ca29f5fa", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
            //         { "b6264e92-53f8-4248-8e2f-b8982234964c", new[] { 1, 2, 3, 4, 5 }, "e07db7c4-151e-4c84-af1b-ac15a22533cf", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
            //         { "b7fb0b25-206b-4200-82d5-7ecabdbec0d3", new[] { 1 }, "6157a78e-7d7b-4484-80ba-3dfe4d6b4e36", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
            //         { "b8d014ef-edfe-4f08-ba24-ce97cb236f77", new[] { 2 }, "ec710562-9fd7-4e8d-a057-9f16bb4d3fe4", "Pode listar os dados de uma rotina event history", "CanRotinaEventHistoryRead", "CANROTINAEVENTHISTORYREAD", "ac-rotinaEventHistory-page" },
            //         { "ba7014f6-bd83-4c9e-a798-b8988c886b98", new[] { 3 }, "3ae184d3-ad6e-4f9a-bb93-38fe7bf970cf", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
            //         { "bc3791dd-d18b-4287-b1d6-eb76355767ca", new[] { 2 }, "aa9d4088-dfd9-44b5-88f1-1293ee91af82", "Pode listar os dados de uma comissão de vendedor", "CanVendedorComissaoRead", "CANVENDEDORCOMISSAOREAD", "ac-vendedorComissao-page" },
            //         { "bc43366c-60f7-45d9-a871-d3dd26833cdc", new[] { 1 }, "e8410e9f-4e11-44f6-ab5e-0a12d6408663", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
            //         { "bc978d88-5463-409d-8e81-213054185da6", new[] { 5 }, "3fac447b-52e9-4ebc-a831-0e24cffea7d3", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
            //         { "bf0a2e56-6de3-4498-9fb9-5728b4a77eea", new[] { 2 }, "8b140073-33cf-4efe-8fe7-0b0cdc44d1f1", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
            //         { "c2f0c08c-ab59-4afb-aa48-f300cb191ebe", new[] { 1, 2, 3, 4, 5 }, "c686cdfd-abf5-4b77-b616-d5582b88ceeb", "Pode realizar todas as ações/operações relacionadas a entidade de sistema rotina", "CanRotinaAll", "CANROTINAALL", "ac-rotina-page" },
            //         { "c4ecb7a7-28f4-4aa9-8c9a-ac6eab1ba7e6", new[] { 1, 2, 3, 4, 5 }, "9c15a98c-cc58-49d6-96cb-0a0005cd72ef", "Pode realizar todas as ações/operações em dashboard comercial", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
            //         { "c540014b-c766-4714-8a9f-bc87b7507336", new[] { 4 }, "5343eeb3-96cb-46f2-beeb-3340458c5025", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
            //         { "c5bf6bf9-71f9-4ee3-8ba8-10f3e29dd025", new[] { 5 }, "3b6e06f6-cac1-44a4-bc08-4bd4c0508e21", "Pode deletar um vendedor", "CanVendedorDelete", "CANVENDEDORDELETE", "ac-vendedor-page" },
            //         { "c8899618-16fb-4c9c-a1d5-9038ad7c89aa", new[] { 1 }, "dde92baf-8471-4096-9e65-0e6e935ca5e3", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
            //         { "cb6aa67c-e697-44e0-9847-0dcb3d8ef3aa", new[] { 2 }, "44249557-5231-481d-b584-6bb2fa86fcd2", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
            //         { "cf28cf15-e6c0-4ceb-807a-aa55407f0aa7", new[] { 1 }, "6e739807-a82f-4d38-8b5f-51b970ee3480", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" },
            //         { "d2924f4b-40fe-46ff-b863-63a80c613777", new[] { 3 }, "4557518b-6fe1-4cb2-beaf-e535269169c4", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
            //         { "d54340a4-2242-4e0b-be0e-f0bab193b8ee", new[] { 1, 2, 3, 4, 5 }, "20fcaac8-1401-42a3-8a40-57d7f917f496", "Pode realizar todas as ações/operações em todos os contratos vinculados a vendedores", "CanVendedorContratoAll", "CANVENDEDORCONTRATOALL", "ac-vendedorContrato-page" },
            //         { "d7d70372-04a9-4e74-a79f-79f980534455", new[] { 1, 2, 3, 4, 5 }, "7d088b32-c512-470a-9cf7-bc07d5d3bfa1", "Pode realizar todas as ações/operações relacionadas a entidade rotina event history", "CanRotinaEventHistoryAll", "CANROTINAEVENTHISTORYALL", "ac-rotinaEventHistory-page" },
            //         { "d910303c-3585-420e-b4bb-6b72c55b77a0", new[] { 1 }, "8d1b95a0-575b-4b88-8759-b5999811ac09", "Pode listar todas as rotinas events histories", "CanRotinaEventHistoryList", "CANROTINAEVENTHISTORYLIST", "ac-rotinaEventHistory-page" },
            //         { "d9a12c1b-fdfd-49f3-84c0-a26545ed97c0", new[] { 2 }, "2b6cde73-c65e-49a5-a570-b32b1025a266", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
            //         { "db1d4e9e-ac3e-462b-a934-292c96afce66", new[] { 2 }, "06ce8d01-5fb5-4d9f-b4f1-e426ab1145cf", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
            //         { "dc401bc3-8d4c-4137-a59d-42a406b4330a", new[] { 2 }, "98c376c4-e651-4487-a39e-6239b089189f", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
            //         { "dcc5005e-303e-49ba-b013-b078afade695", new[] { 1, 2, 3, 4, 5 }, "6b256a83-590f-4b53-97f0-b4527dba9461", "Pode realizar todas as ações/operações em todas as comissões de vendedores", "CanVendedorComissaoAll", "CANVENDEDORCOMISSAOALL", "ac-vendedorComissao-page" },
            //         { "ddd727cb-8413-41fd-974b-25d22b445750", new[] { 2 }, "027a851d-6c44-4fc2-b78f-53ef0237bccf", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
            //         { "e0091078-46e5-4035-b823-04b478c8dbc3", new[] { 1, 2, 3, 4, 5 }, "d2c39b4b-42d4-45ba-bf14-c5403e1b4458", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
            //         { "e2aeb8c9-88cc-46f1-b4e5-45470d2aee99", new[] { 5 }, "85904d37-bc03-48bc-aeed-7f935d68c95c", "Pode deletar um vínculo de contrato com um vendedor", "CanVendedorContratoDelete", "CANVENDEDORCONTRATODELETE", "ac-vendedorContrato-page" },
            //         { "e43696d3-7a33-4472-aed6-6c8b6d547ecb", new[] { 1, 2, 3, 4, 5 }, "23abe25c-5b3f-49ff-bc8c-582935c88909", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
            //         { "e454c02e-dc1a-4d75-9430-32f8165527f3", new[] { 1 }, "65e5c986-f0a5-4e8c-8872-2e82137144b5", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
            //         { "e7266a8d-dba8-4fd9-b282-73a40714ad96", new[] { 5 }, "e3c5faa2-8884-4fb4-9a17-4a0864b204ee", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
            //         { "e7f8ce0e-3a63-42bc-ada3-05f7a9daefd6", new[] { 4 }, "d7f12f2a-462c-4fcd-9f3d-d6fa94db93b6", "Pode criar uma fatura de contrato de cliente", "CanClienteContratoFaturaUpdate", "CANCLIENTECONTRATOFATURAUPDATE", "ac-clienteContratoFatura-page" },
            //         { "e92f15a8-9323-4fd4-b509-7963c10f8d1f", new[] { 1 }, "a241a569-9b45-4c5d-a898-be3d1a91de12", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
            //         { "e9b0b030-2217-4e0c-9784-012751eb1895", new[] { 4 }, "a4073ac4-afbb-49fa-b8a0-bc6c35272c3c", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
            //         { "eec0ac7e-ca17-4ad3-8856-ef4abff1b5b9", new[] { 3 }, "e5358f3c-8b6d-4969-bf9c-c922af717933", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
            //         { "efafc1bb-d828-45a1-888e-7c01cc36e781", new[] { 4 }, "93aa5a0f-698a-45b7-a01c-1d25efe6dc8f", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
            //         { "f00c274f-60bd-4d08-a4b3-44fe714e71eb", new[] { 3 }, "31d59c0b-8aa6-4cd5-aabc-c3b74d8d3c5a", "Pode visualizar um contrato vinculado a um ou vários vendedores", "CanVendedorContratoCreate", "CANVENDEDORCONTRATOCREATE", "ac-vendedorContrato-page" },
            //         { "f0a236f1-d1a8-4dbf-b5e7-36a9c2c23299", new[] { 3 }, "abb0ace1-6fe9-415d-80ee-a7bf9b0d05c1", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
            //         { "f23b7259-f94c-4fd5-8305-b18c41bb14f0", new[] { 1, 2, 3, 4, 5 }, "d17f5e94-f3bb-4783-9f24-fea91926c1cf", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
            //         { "f429ff3d-14fe-42c3-90dc-cfbe49859a0b", new[] { 2 }, "26a85ec1-5629-43ea-a036-56ab1e587632", "Pode listar os dados de uma fatura de contrato de cliente", "CanClienteContratoFaturaRead", "CANCLIENTECONTRATOFATURAREAD", "ac-clienteContratoFatura-page" },
            //         { "f4bc751f-36ea-4436-a04b-d36386b4532a", new[] { 1, 2, 3, 4, 5 }, "1b4f08c4-60d9-40ed-b154-896e1b51204c", "Pode realizar todas as ações/operações em todas as faturas de contratos de clientes", "CanClienteContratoFaturaAll", "CANCLIENTECONTRATOFATURAALL", "ac-clienteContratoFatura-page" },
            //         { "f7a053fb-cc9f-47c6-a92e-87972c921987", new[] { 5 }, "95d25c31-4be2-40d9-aa0f-890695a061f4", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
            //         { "f8119496-e412-47fb-a9ee-ee79584a4727", new[] { 3 }, "763a6808-43e7-4baa-87e9-d003bb2d36db", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
            //         { "f8dcec83-139e-4e21-b3ff-2bc3cb480609", new[] { 2 }, "9f3068ba-2a7f-4d72-aaa5-2b2f9ccae8ed", "Pode listar os dados de uma rotina", "CanRotinaRead", "CANROTINAREAD", "ac-rotina-page" },
            //         { "fcc83428-f4b6-4ab7-850c-7e9bde03c2b5", new[] { 3 }, "037f81a6-e06a-463d-8c50-40da84a740b6", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
            //         { "fe9691bb-4ef5-4222-aa63-1871bac4fdca", new[] { 4 }, "bf9f7059-69f3-443e-9650-e6551d5b90a7", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" }
            //     });

            // migrationBuilder.InsertData(
            //     table: "ChavesApiTerceiro",
            //     columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
            //     values: new object[] { new Guid("9abfe3a5-cedd-4252-90fc-31c4cb596f72"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.InsertData(
                table: "Rotinas",
                columns: new[] { "Id", "ChaveSequencial", "CreatedAt", "CreatedBy", "DataCompetenciaFim", "DataCompetenciaInicio", "Descricao", "DispatcherRoute", "IsDeleted", "Nome", "Observacao", "TenantId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    // { new Guid("0ce490c7-4f00-42f3-a6e6-b88815480511"), 5, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp todas as faturas não quitadas de contratos de clientes do bom controle", "dispatch-faturas-nao-quitadas-sync", false, "Sincronização de faturas não quitadas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2248), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    // { new Guid("0d532b53-8f82-42f8-bb20-6f9c8043b620"), 4, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp todas as faturas quitadas de contratos de clientes do bom controle", "dispatch-faturas-quitadas-sync", false, "Sincronização de faturas quitadas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    // { new Guid("1624fef2-1ec5-4541-b492-601e732bd4bc"), 2, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp os contratos de clientes ainda não existente, a partir do sistema Bom Controle.", "dispatch-contratos-sync", false, "Sincronização de contratos de clientes com o sistema Bom Controle", "", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    // { new Guid("3a3ed67a-08fd-4ae0-b941-0700b46da892"), 3, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina atualiza a periodicidade dos novos contratos sincronizados a partir da rotina 2.", "dispatch-contratos-update", false, "Atualização de contratos de clientes com o sistema Bom Controle", "A atualização de periodicidade que ocorre logo após a importação dos contratos só se faz necessária uma vez que, o método da api do sistema Bom Controle que retorna os contratos não traz este dado. Portanto, se faz necessário buscá-lo em um outro método da api do Bom Controle.", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { new Guid("879f9802-79fe-42be-a05a-afc8af5e683d"), 8, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina interna gera as comissões de um vendedor apenas. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).", "dispatch-vendedores-comissoes-create-by-vendedorId", false, "Gerar comissões para um vendedor ativo no Boxapp", "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                    // { new Guid("8a76c3d5-7c06-4757-9952-763952f223be"), 1, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2179), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp os clientes ativos do sistema Bom Controle", "dispatch-clientes-sync", false, "Sincronização de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2198), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    // { new Guid("af045f3d-7e2a-45f4-9c59-92db242dca35"), 7, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina interna gera as comissões de vendedores. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).", "dispatch-vendedores-comissoes-create", false, "Gerar comissão de vendedores ativos no Boxapp", "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    // { new Guid("fbbbcdb4-19ef-436e-93f9-2cd7cef7f203"), 6, new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2256), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina atualiza automaticamente no boxapp os dados de faturas a partir de informações do sistema Bom Controle.", "dispatch-faturas-update", false, "Atualização dos dados de faturas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 491, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 476, DateTimeKind.Unspecified).AddTicks(3500), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 24, 8, 53, 29, 476, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes",
                column: "VendedorId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "010ca467-0bde-450f-8126-fc00c9fbb841");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "012c67b8-23e9-4925-8616-2aaae38019ec");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "012c88c2-1c3c-43bd-9d68-44fc6c4ce3b9");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "01b8e389-9cf8-45d7-bea1-f545794702a6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "02225a2c-2c73-4a57-8e03-75425f103f70");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "043bb06a-3238-4bcc-9d13-437a4f23e554");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "04c3b6a4-185e-40f6-aa02-ae7bd9f22602");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0ab971dd-72a9-4a25-96ff-6fa2779807e2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "0fae21d9-bb3f-4135-b235-d2e1928d8332");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "152da1d6-10de-446d-9478-f7f0ae983e95");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "15b23a65-bb25-411f-ac81-c302f117afac");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "173c622e-08ac-4133-aaca-998c0d549d0c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "183e964c-aa88-4f52-acce-87f77f7bb362");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "18f2a597-ab5b-4ec9-a22a-23ba88da760d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1ac134b0-ba45-4dc1-8f2b-62b9ecb64fca");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1ddbc919-3a6d-49ba-9a93-01739bbecdc1");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1de5a91e-84f4-4cb3-9750-0fa094c862d3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1ef17409-ea04-4947-a01e-8707f13fc286");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1fff078f-2c84-4254-857c-35b18b9f4d1e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "21612f29-c23e-42c0-88b9-b2004f656d1d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "21e66e31-b8e9-46ef-aed7-dd55efc873f3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "22d8534e-6db4-4755-b6c3-eee0d4680359");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "23e7bc2d-c01f-4fca-ab65-a1cfbfe3494b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2786d48c-183e-47f6-9b80-72050bf57a7e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "27906c3c-640a-4283-bf07-c1bf06ec2cc3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "28c83627-aaf3-4a9b-982f-15635ea61f5e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2ac74703-6cad-4bb6-953f-397c5c85451f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "2b476346-9db8-44c7-ac65-1ff1ab5f3876");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "31b05c2f-515a-42b8-80d6-11a286d1b433");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "39d039a1-b129-439b-a5b6-d35cebfa0f1f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "3ae13c1e-4d7a-4f55-ab5e-a4d77ec1e852");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "3e49b1fd-eb10-4a65-92fc-9a5b7edaee76");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "409e55a7-ede5-4b73-aca9-de4ffff4f012");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "41a6a347-4597-491d-bfa2-82e7c2eb84af");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "41b4a59f-62e6-46e6-a812-0e656fde1d91");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4822123b-6332-420c-9d4b-88f5d020f5c6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4c9972c2-5a42-4f10-ad2a-cfcbe147a06a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4e9a49a2-580e-4c4a-9b6b-3f99f6e30c33");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "4ea9a8ec-b6ec-49b2-9f1b-47041c6109e7");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "53167d05-7ad7-4d14-896b-c189817ac80f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "572a2a04-3727-4412-914b-0a7a2f772b2b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "58bd775b-4f28-4213-993d-5c50cb9087d2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5add918c-35d4-4dc8-b0ab-e3f95228a65f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "60c536d5-e5e7-4a8a-9707-67931181a144");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "67d3a714-8d20-43b7-b6a8-b61747c6e44e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "695c661f-64b3-4b0a-90c6-0186581711ed");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6e36f8d7-83f4-43fc-b995-1f19d2503151");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "6f20e719-d56e-4b29-90c3-fad735274de3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "71932d72-c275-456e-b7aa-24a55e6b4c6e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "745dfafa-f7b2-415c-b8f0-ba7cb2f41805");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "754a0444-6d81-4661-b6a0-54858f751941");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "75beb8ed-d1e8-4074-9273-8acd5ea378ef");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "76389d03-89fb-401c-91e0-86461c56854a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "76fe43a5-dfa9-40b8-9097-d85f2445697f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "7863d7d3-9b18-44fc-9fe5-bd49dadad71f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "7fda4629-1373-41cc-8723-e418d6181b76");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8c53566d-9e38-4532-9a06-20028bcc195c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8cedba76-dca3-4708-8cdc-d1946593a2c4");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8da80b14-e29a-414c-8592-45ff68b94846");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8f05a09a-8ed1-49e5-a54e-5a606fe3a14d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9085129d-c364-4e31-9ca2-e5dc4d0a0753");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "943b2365-b5c9-4fda-a442-0f22b513b998");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "957e61fd-7f4d-4568-b9d1-1221c0eed23d");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "975b2fc8-7fc3-4260-b2bf-cef28d985f14");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "984d63be-8187-4769-a48d-18927ab14852");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9923cc10-6d73-4375-a551-a6767d67bbf2");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9a27bfa2-ebe3-411c-9a99-eac681b451eb");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9de3482f-27a6-4353-b41b-fb0732084fd5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9e0978d1-c3ef-4895-bc8b-b7befd6467c9");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9e5bba0a-a23f-4e5a-af8a-06874cca9c76");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "9ed8895a-7da7-454a-ad84-1e558aecef03");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a22e43c8-150f-4c21-ba5d-e2bef3bdd389");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a2cd6864-650d-4ade-85cd-08ae7a5836dd");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "a879a476-4433-4594-bee2-ddd835b1c972");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "aa567199-2285-4354-bc03-09e55e83b549");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "aaee8960-8d14-487e-a5af-166d51d4f28e");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ab36a405-1e92-4e16-839d-315c707a0647");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ab8b265b-efba-4c71-8f71-bce2ed41f969");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ada32923-d1b9-4c49-a4f0-2f4ebf09d1ce");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ada5db28-57e5-491f-a21c-cf34679e186f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b0a896ad-8c8a-4f82-8888-f44f0870df93");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b31eb583-1838-49ab-ad76-4dd9d5ef2d9b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b6264e92-53f8-4248-8e2f-b8982234964c");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b7fb0b25-206b-4200-82d5-7ecabdbec0d3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b8d014ef-edfe-4f08-ba24-ce97cb236f77");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ba7014f6-bd83-4c9e-a798-b8988c886b98");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "bc3791dd-d18b-4287-b1d6-eb76355767ca");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "bc43366c-60f7-45d9-a871-d3dd26833cdc");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "bc978d88-5463-409d-8e81-213054185da6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "bf0a2e56-6de3-4498-9fb9-5728b4a77eea");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c2f0c08c-ab59-4afb-aa48-f300cb191ebe");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c4ecb7a7-28f4-4aa9-8c9a-ac6eab1ba7e6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c540014b-c766-4714-8a9f-bc87b7507336");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c5bf6bf9-71f9-4ee3-8ba8-10f3e29dd025");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "c8899618-16fb-4c9c-a1d5-9038ad7c89aa");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "cb6aa67c-e697-44e0-9847-0dcb3d8ef3aa");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "cf28cf15-e6c0-4ceb-807a-aa55407f0aa7");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d2924f4b-40fe-46ff-b863-63a80c613777");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d54340a4-2242-4e0b-be0e-f0bab193b8ee");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d7d70372-04a9-4e74-a79f-79f980534455");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d910303c-3585-420e-b4bb-6b72c55b77a0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "d9a12c1b-fdfd-49f3-84c0-a26545ed97c0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "db1d4e9e-ac3e-462b-a934-292c96afce66");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dc401bc3-8d4c-4137-a59d-42a406b4330a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "dcc5005e-303e-49ba-b013-b078afade695");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "ddd727cb-8413-41fd-974b-25d22b445750");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e0091078-46e5-4035-b823-04b478c8dbc3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e2aeb8c9-88cc-46f1-b4e5-45470d2aee99");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e43696d3-7a33-4472-aed6-6c8b6d547ecb");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e454c02e-dc1a-4d75-9430-32f8165527f3");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e7266a8d-dba8-4fd9-b282-73a40714ad96");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e7f8ce0e-3a63-42bc-ada3-05f7a9daefd6");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e92f15a8-9323-4fd4-b509-7963c10f8d1f");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e9b0b030-2217-4e0c-9784-012751eb1895");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "eec0ac7e-ca17-4ad3-8856-ef4abff1b5b9");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "efafc1bb-d828-45a1-888e-7c01cc36e781");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f00c274f-60bd-4d08-a4b3-44fe714e71eb");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f0a236f1-d1a8-4dbf-b5e7-36a9c2c23299");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f23b7259-f94c-4fd5-8305-b18c41bb14f0");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f429ff3d-14fe-42c3-90dc-cfbe49859a0b");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f4bc751f-36ea-4436-a04b-d36386b4532a");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f7a053fb-cc9f-47c6-a92e-87972c921987");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f8119496-e412-47fb-a9ee-ee79584a4727");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "f8dcec83-139e-4e21-b3ff-2bc3cb480609");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "fcc83428-f4b6-4ab7-850c-7e9bde03c2b5");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "fe9691bb-4ef5-4222-aa63-1871bac4fdca");

            // migrationBuilder.DeleteData(
            //     table: "ChavesApiTerceiro",
            //     keyColumn: "Id",
            //     keyValue: new Guid("9abfe3a5-cedd-4252-90fc-31c4cb596f72"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("0ce490c7-4f00-42f3-a6e6-b88815480511"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("0d532b53-8f82-42f8-bb20-6f9c8043b620"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("1624fef2-1ec5-4541-b492-601e732bd4bc"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("3a3ed67a-08fd-4ae0-b941-0700b46da892"));

            migrationBuilder.DeleteData(
                table: "Rotinas",
                keyColumn: "Id",
                keyValue: new Guid("879f9802-79fe-42be-a05a-afc8af5e683d"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("8a76c3d5-7c06-4757-9952-763952f223be"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("af045f3d-7e2a-45f4-9c59-92db242dca35"));

            // migrationBuilder.DeleteData(
            //     table: "Rotinas",
            //     keyColumn: "Id",
            //     keyValue: new Guid("fbbbcdb4-19ef-436e-93f9-2cd7cef7f203"));

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 519, DateTimeKind.Unspecified).AddTicks(439), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 519, DateTimeKind.Unspecified).AddTicks(454), new TimeSpan(0, -3, 0, 0, 0)) });

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "Actions", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Subject" },
            //     values: new object[,]
            //     {
            //         { "01cb5b35-ac32-49f4-a53b-474290066341", new[] { 1, 2, 3, 4, 5 }, "f580194f-3ca0-4263-8bda-2864cafb985f", "Pode realizar todas as ações/operações em todos os serviços de fornecedores", "CanFornecedorServicoAll", "CANFORNECEDORSERVICOALL", "ac-fornecedorServico-page" },
            //         { "020aac79-58f1-4098-9953-8b51ef499c15", new[] { 2 }, "473f5c90-2622-4605-b422-a28354d7116b", "Pode listar os dado de um grupo", "CanGroupRead", "CANGROUPREAD", "ac-group-page" },
            //         { "032b0f41-9fb7-4c08-a2a2-2462216abe63", new[] { 3 }, "ffb28d7d-c44e-4032-b96c-451f0b42600f", "Pode criar um pipeline", "CanPipelineCreate", "CANPIPELINECREATE", "ac-pipeline-page" },
            //         { "0504e7bd-7781-4613-9a96-196530c36287", new[] { 4 }, "ee1fba5b-6db2-4029-b13c-6d26f199e106", "Pode criar um produto de fornecedor", "CanFornecedorProdutoUpdate", "CANFORNECEDORPRODUTOUPDATE", "ac-fornecedorProduto-page" },
            //         { "08e51725-3c71-4de4-b6fd-4b9b40815ff5", new[] { 3 }, "7a22e29a-e715-4cd0-beb8-3e154eb8e30e", "Pode criar um serviço para um cliente", "CanClienteServicoCreate", "CANCLIENTESERVICOCREATE", "ac-clienteServico-page" },
            //         { "0b44358b-b206-42a8-9d45-9256825d13a0", new[] { 2 }, "608f698f-ef23-49ec-a71b-5a57728f5898", "Pode listar os dados de um pipeline", "CanPipelineRead", "CANPIPELINEREAD", "ac-pipeline-page" },
            //         { "0d5b8ded-8481-445c-9d30-c37d9d3a0b28", new[] { 1, 2, 3, 4, 5 }, "16aea96a-ce95-4db0-9a4c-4a2b2547fb34", "Pode realizar todas as ações/operações em todos os pipelines", "CanPipelineAll", "CANPIPELINEALL", "ac-pipeline-page" },
            //         { "0e4ddc3f-e334-4492-aeb3-8e9f53dd55f1", new[] { 4 }, "41e9d78e-81c6-4c20-8dd7-209eed1353e3", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroUpdate", "CANCHAVEAPITERCEIROUPDATE", "ac-chaveApiTerceiro-page" },
            //         { "1155f307-eaba-45bb-8269-017870d4b35b", new[] { 3 }, "058a32e4-2794-451d-9955-63b1f354ebb1", "Pode visualizar uma comissão de vendedor", "CanVendedorComissaoCreate", "CANVENDEDORCOMISSAOCREATE", "ac-vendedorComissao-page" },
            //         { "15732b5b-69a1-4377-ac00-04fc85b51bbf", new[] { 5 }, "7c57458b-f29e-4ae8-9ed9-a6cbdfa2a87c", "Pode deletar um produtos", "CanProdutoDelete", "CANPRODUTODELETE", "ac-produto-page" },
            //         { "175a5db6-725d-4a65-9a6e-e1524926ab2e", new[] { 3 }, "ce2ab1c0-a310-4137-949a-0e9e8c9b3d35", "Pode criar um usuário", "CanUserCreate", "CANUSERCREATE", "ac-user-page" },
            //         { "19f4cb22-74e9-4eee-9b59-cb4c02ece493", new[] { 4 }, "bc160597-2ea5-456f-84e1-01750931e877", "Pode criar um vendedor", "CanVendedorUpdate", "CANVENDEDORUPDATE", "ac-vendedor-page" },
            //         { "1b07d539-c496-413e-ab4a-0367d64f0aba", new[] { 1 }, "4a07850e-85b7-4972-ad58-c61cc97b6b0a", "Pode listar os dados de todos os serviços de clientes", "CanClienteServicoList", "CANCLIENTESERVICOLIST", "ac-clienteServico-page" },
            //         { "1c1006bf-2e42-4ca7-b341-28bbdd0ddd83", new[] { 1, 2, 3, 4, 5 }, "7716e15d-57d6-4664-b0ce-7fb718edb9a9", "Pode realizar todas as ações/operações em todos os serviços", "CanServicoAll", "CANSERVICOALL", "ac-servico-page" },
            //         { "1c9719b0-3e86-4854-97b3-cc537b673c7c", new[] { 5 }, "fdf35eac-30f2-4404-8c01-fc4fd1e51b69", "Pode deletar um contrato de cliente", "CanClienteContratoDelete", "CANCLIENTECONTRATODELETE", "ac-clienteContrato-page" },
            //         { "1cfa5695-571a-4f86-95f9-019157a438d6", new[] { 2 }, "58deceab-46bb-4956-8360-6af724407052", "Pode listar os dado de um serviço de cliente", "CanClienteServicoRead", "CANCLIENTESERVICOREAD", "ac-clienteServico-page" },
            //         { "1fceeb52-d49b-4435-83c5-0df368cf9e02", new[] { 4 }, "8501f487-8663-4cc6-9953-7d87cc5e31f9", "Pode atualizar um serviço de um cliente", "CanClienteServicoUpdate", "CANCLIENTESERVICOUPDATE", "ac-clienteServico-page" },
            //         { "2276e451-0526-4585-9a72-fd4bf035ccf3", new[] { 2 }, "4e03553a-ea7d-4006-91f5-d4dc7b0ea46a", "Pode listar os dados de um produto de cliente", "CanClienteProdutoRead", "CANCLIENTEPRODUTOREAD", "ac-clienteProduto-page" },
            //         { "2312500c-14bf-46cc-9ef5-82197cec6802", new[] { 4 }, "ffff9fd8-1bf4-478e-abd4-a1c868a38c75", "Pode criar um vínculo de contrato a um vendedor", "CanVendedorContratoUpdate", "CANVENDEDORCONTRATOUPDATE", "ac-vendedorContrato-page" },
            //         { "23c5a47d-f6b0-4a2c-8e0a-3ba3e50a597d", new[] { 1, 2, 3, 4, 5 }, "01dae106-331d-4baf-a42f-36655d675d84", "Pode realizar todas as ações/operações em todos os contratos vinculados a vendedores", "CanVendedorContratoAll", "CANVENDEDORCONTRATOALL", "ac-vendedorContrato-page" },
            //         { "23d6b762-8461-4c3f-b9f7-fbef9b94c57f", new[] { 5 }, "54a8979b-b450-4627-b8f0-7fcf2ecce423", "Pode deletar um vendedor", "CanVendedorDelete", "CANVENDEDORDELETE", "ac-vendedor-page" },
            //         { "2552dcb4-da38-4668-bf88-e7df25688317", new[] { 1, 2, 3, 4, 5 }, "6ddb2ef9-f5f8-4b89-b3c4-0e38235ce2ab", "Pode visualizar todos os indicadores da dashboard comercial", "CanClienteAll", "CANCLIENTEALL", "ac-cliente-page" },
            //         { "268fda58-2a65-4d53-840a-9fa1843d1f28", new[] { 1 }, "7f5ed0a2-76b7-4f45-9d23-830260ab89f5", "CanDashboardPublicaClienteContratoList", "CanDashboardPublicaClienteContratoList", "CANDASHBOARDPUBLICACLIENTECONTRATOLIST", "ac-dashboardPublicaClienteContrato-page" },
            //         { "26c4b410-8922-4f8d-b68c-7239ca180876", new[] { 1, 2, 3, 4, 5 }, "5ab9164e-c4b0-4657-9a04-5986f44cb576", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroAll", "CANCHAVEAPITERCEIROALL", "ac-chaveApiTerceiro-page" },
            //         { "28b1f836-f7ef-4651-b97d-06fd33107abd", new[] { 2 }, "65c50535-70a8-40b3-b2a0-3b27ed9ca44b", "Pode listar os dados de um vendedor", "CanVendedorRead", "CANVENDEDORREAD", "ac-vendedor-page" },
            //         { "295afcc5-1691-48f9-bcf4-38eb472a3bc5", new[] { 1, 2, 3, 4, 5 }, "014423c3-880a-41b2-a7ab-0a178bff8fe0", "Pode visualizar todas as dashboards do cliente", "CanDashboardClienteAll", "CANDASHBOARDCLIENTEALL", "ac-dashboardCliente-page" },
            //         { "29dd8437-c26d-40e3-ac26-de4923d55326", new[] { 1, 2, 3, 4, 5 }, "d954c7e7-2954-4bfe-a3e7-6e48bab87cca", "Pode realizar todas as ações/operações em todos os grupos", "CanGroupAll", "CANGROUPALL", "ac-group-page" },
            //         { "29fcb479-301c-457e-b9b7-1d870b170884", new[] { 5 }, "fbf42185-d484-4864-a177-8a6901513ba2", "Pode deletar um cliente", "CanClienteDelete", "CANCLIENTEDELETE", "ac-cliente-page" },
            //         { "33721ce6-e228-48ac-850a-ff7588319315", new[] { 1, 2, 3, 4, 5 }, "a7d4897d-1a2a-4832-848d-b82917656f7e", "Pode realizar todas as ações/operações relacionadas a entidade de sistema rotina", "CanRotinaAll", "CANROTINAALL", "ac-rotina-page" },
            //         { "33e48694-c90c-451c-b69b-4723eb88a1b2", new[] { 3 }, "698e9766-d464-4f35-b9c6-49d20e778a46", "Pode criar um fornecedor", "CanFornecedorCreate", "CANFORNECEDORCREATE", "ac-fornecedor-page" },
            //         { "35a55e98-6ecd-4293-9168-9ec783a12c85", new[] { 3 }, "39863957-574d-406d-853c-68c3107a9afc", "Pode criar uma role/permissão", "CanRoleCreate", "CANROLECREATE", "ac-role-page" },
            //         { "38c7c998-d564-4533-b648-cb6cda2a3c2b", new[] { 5 }, "2e9854eb-59f1-414e-a038-dff90e73182b", "Pode deletar uma comissão de vendedor", "CanVendedorComissaoDelete", "CANVENDEDORCOMISSAODELETE", "ac-vendedorComissao-page" },
            //         { "38efb290-228d-4292-92b9-38be763a10a7", new[] { 4 }, "2e765303-b8ee-47d2-ac6c-cac4fb8333fa", "Pode atualizar um serviço", "CanServicoUpdate", "CANSERVICOUPDATE", "ac-servico-page" },
            //         { "3e4bbb05-42d4-4706-9cd8-63cf737b5c76", new[] { 1 }, "8c3eaeb9-ce34-44a2-9b8a-9dd49eb91334", "Pode listar os dados de comissão de vendedores", "CanVendedorComissaoList", "CANVENDEDORCOMISSAOLIST", "ac-vendedorComissao-page" },
            //         { "3e5a5862-c63b-4dd2-8766-6309996b5638", new[] { 1 }, "68a341d1-8bbb-4e4d-9b6f-5276082f38f1", "Pode listar os dados de todos os vendedores", "CanVendedorList", "CANVENDEDORLIST", "ac-vendedor-page" },
            //         { "42260cbe-4ebe-4018-ad51-e9700281029f", new[] { 1 }, "91282840-ff71-48f2-9a3c-1024108295e0", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroList", "CANCHAVEAPITERCEIROLIST", "ac-chaveApiTerceiro-page" },
            //         { "43366c38-2876-41c3-b9c5-18f2c0311f66", new[] { 2 }, "d26ba27c-d3a8-46ec-982d-363c1d08bd64", "Pode listar os dados de uma rotina", "CanRotinaRead", "CANROTINAREAD", "ac-rotina-page" },
            //         { "47c7e3af-2291-4309-84b0-7d0fd24059fc", new[] { 4 }, "6594d6ac-0989-472b-b7b8-1d6e47fd1b83", "Pode atualizar os dados de rotinas", "CanRotinaUpdate", "CANROTINAUPDATE", "ac-rotina-page" },
            //         { "4981c700-9fcc-4d4a-b7cb-272c9048fb8a", new[] { 1, 2, 3, 4, 5 }, "4bcc380e-c716-4fd3-bca9-3a7becf5bb98", "Pode realizar todas as ações/operações em todas as comissões de vendedores", "CanVendedorComissaoAll", "CANVENDEDORCOMISSAOALL", "ac-vendedorComissao-page" },
            //         { "49a44459-7b88-4d4b-8cb6-a09e8a03b420", new[] { 4 }, "fe32edb1-b7ae-47da-94ee-bd8b017b3e59", "Pode atualizar um contrato de cliente", "CanClienteContratoUpdate", "CANCLIENTECONTRATOUPDATE", "ac-clienteContrato-page" },
            //         { "4a739549-7512-4329-b2b4-ff6f638ee5a2", new[] { 1, 2, 3, 4, 5 }, "60045624-6af5-42ff-8aa8-fd32a9c07fb8", "Pode realizar todas as ações/operações relacionadas a entidade rotina event history", "CanRotinaEventHistoryAll", "CANROTINAEVENTHISTORYALL", "ac-rotinaEventHistory-page" },
            //         { "511fe119-f53a-47c1-8745-643f8e349c37", new[] { 1 }, "8827c802-ccb9-43ca-a420-d3c213500117", "Pode listar os dados de todos os fornecedores", "CanFornecedorList", "CANFORNECEDORLIST", "ac-fornecedor-page" },
            //         { "5179f2e9-d838-48ba-9ca3-716076d66dca", new[] { 3 }, "5a241cc1-6330-480e-88c0-dad23e955530", "Pode criar um serviço", "CanServicoCreate", "CANSERVICOCREATE", "ac-servico-page" },
            //         { "52c0f0ec-4476-45fe-b114-a8975ee2bc7f", new[] { 4 }, "0c5da865-7b8b-42ce-8974-5a448a18bfdc", "Pode atualizar um pipeline", "CanPipelineUpdate", "CANPIPELINEUPDATE", "ac-pipeline-page" },
            //         { "5324fd04-1bd1-4794-8ab8-efbc5a821c55", new[] { 2 }, "f15b333f-804b-4ed8-ac90-18a33d47b912", "Pode listar os dados de um usuários", "CanUserRead", "CANUSERREAD", "ac-user-page" },
            //         { "569e5883-a0b9-430b-8b63-e68e2602d706", new[] { 3 }, "2c091a25-9544-4b9c-9ed5-d7786c92f694", "Pode criar um serviço para um fornecedor", "CanFornecedorServicoCreate", "CANFORNECEDORSERVICOCREATE", "ac-fornecedorServico-page" },
            //         { "5805bc43-ac33-45b4-a27d-df8386e76d7d", new[] { 4 }, "255fbc19-774f-4beb-ae28-aa841ad3f038", "Pode atualizar um fornecedor", "CanFornecedorUpdate", "CANFORNECEDORUPDATE", "ac-fornecedor-page" },
            //         { "583073cc-a5cb-4a44-a069-ad310547e706", new[] { 2 }, "58ba5e00-c643-4114-ae49-5038b15c8bc1", "Pode listar os dados de uma roles/permissão", "CanRoleRead", "CANROLEREAD", "ac-role-page" },
            //         { "5a9e5e40-e115-461b-9be7-d311b0034dac", new[] { 4 }, "ac227876-01ea-46fe-9022-fe77fa268332", "Pode atualizar os dados de um grupo", "CanGroupUpdate", "CANGROUPUPDATE", "ac-group-page" },
            //         { "5bef938a-f4ba-4b16-b4f4-2378cf552a8e", new[] { 3 }, "7de3d5fb-cfbb-4d01-877a-b1ee85147153", "Pode visualizar uma fatura de contrato de cliente", "CanClienteContratoFaturaCreate", "CANCLIENTECONTRATOFATURACREATE", "ac-clienteContratoFatura-page" },
            //         { "5ebf202c-80ed-4a4b-a4d5-b90a96a7bb41", new[] { 1, 2, 3, 4, 5 }, "2b0e2e2d-d00e-49d9-be1c-df7485c7765e", "Pode listar todas as rotinas events histories", "CanVendedorRelatorioAll", "CANVENDEDORRELATORIOALL", "ac-vendedorRelatorio-page" },
            //         { "62e62a0d-554e-41b3-8ca3-3741b635a110", new[] { 4 }, "42bfd2d4-e9cb-4bbb-bbdb-d67c26eecf4c", "Pode atualizar os dados de uma roles/permissão", "CanRoleUpdate", "CANROLEUPDATE", "ac-role-page" },
            //         { "67c32341-8bb4-46d8-b32a-7fc7936ae3cf", new[] { 4 }, "92481cff-11d2-4ca8-b862-f1619ecb9cf3", "Pode criar uma fatura de contrato de cliente", "CanClienteContratoFaturaUpdate", "CANCLIENTECONTRATOFATURAUPDATE", "ac-clienteContratoFatura-page" },
            //         { "6a6c7633-a368-47d5-8e50-0fbd98d69ca6", new[] { 2 }, "0f7d7152-fc97-4f26-9944-0220c2900e42", "Pode listar os dados de um fornecedor", "CanFornecedorRead", "CANFORNECEDORREAD", "ac-fornecedor-page" },
            //         { "6b2cde43-d01c-4515-a27d-038fedac9d0b", new[] { 5 }, "5dacc7ab-1de6-487b-8cd4-77ec3b8575b8", "Pode deletar um serviço", "CanServicoDelete", "CANSERVICODELETE", "ac-servico-page" },
            //         { "6bf47b91-c240-48b4-831d-73a3d4aa8f8c", new[] { 4 }, "23e19938-518a-49c5-b1a5-7be5c56b7e17", "Pode atualizar os dados de um cliente", "CanClienteUpdate", "CANCLIENTEUPDATE", "ac-cliente-page" },
            //         { "6e2aadd0-f602-4994-8be1-7335841e2833", new[] { 1, 2, 3, 4, 5 }, "45a200f4-dc22-4b44-a3ee-16255f9e32bf", "Pode realizar todas as ações/operações em todas as dashboards", "CanDashboardAll", "CANDASHBOARDALL", "ac-dashboard-page" },
            //         { "6ec1a617-e64f-474d-9919-5ff12fcd3db3", new[] { 2 }, "1eeff1b3-250b-4848-a3da-530d50edf656", "Pode listar os dados de um contrato vinculado a um vendedor", "CanVendedorContratoRead", "CANVENDEDORCONTRATOREAD", "ac-vendedorContrato-page" },
            //         { "7762c29c-54cd-4aee-99c3-ff137477a62f", new[] { 1 }, "6da5b55c-f4e8-4902-8e87-4cc46c4c36f6", "Pode listar os dados de todas as faturas de contratos de clientes", "CanClienteContratoFaturaList", "CANCLIENTECONTRATOFATURALIST", "ac-clienteContratoFatura-page" },
            //         { "77f38da9-6ec3-45b4-8aa0-e5304643bbc5", new[] { 1 }, "2c5df79f-1def-4f0e-b138-94b44e5f3b2a", "Pode listar todas as rotinas de sistema", "CanRotinaList", "CANROTINALIST", "ac-rotina-page" },
            //         { "7dcdf7d4-5893-4852-988f-bdaf2050b72f", new[] { 4 }, "13ca9418-3e4e-45b3-b849-08aa75f5dad1", "Pode atualizar um produto de cliente", "CanClienteProdutoUpdate", "CANCLIENTEPRODUTOUPDATE", "ac-clienteProduto-page" },
            //         { "800e5440-7418-4e7a-a9f9-be1d6b3839ad", new[] { 1, 2, 3, 4, 5 }, "790c421d-07a4-4642-8026-2030aee6825a", "Pode realizar todas as ações/operações em todos os contratos de clientes", "CanClienteContratoAll", "CANCLIENTECONTRATOALL", "ac-clienteContrato-page" },
            //         { "80577342-1614-4f59-950b-c11be1154b68", new[] { 3 }, "54b328c2-0d04-41b0-91ae-9f8c538b5372", "Pode visualizar um contrato vinculado a um ou vários vendedores", "CanVendedorContratoCreate", "CANVENDEDORCONTRATOCREATE", "ac-vendedorContrato-page" },
            //         { "806a3871-9d97-4e61-a256-c4be7f5fd5d7", new[] { 5 }, "09ccb295-81cd-416a-9ff6-d14bc165cd79", "Pode deletar um serviço de um cliente", "CanClienteServicoDelete", "CANCLIENTESERVICODELETE", "ac-clienteServico-page" },
            //         { "80cc9503-68bd-4c00-8b49-79dbee4d5865", new[] { 3 }, "53fe0c43-b7df-477c-b895-cf93fcf1273c", "Pode criar um grupo", "CanGroupCreate", "CANGROUPCREATE", "ac-group-page" },
            //         { "83872a28-bc5d-4cb5-be96-62a383f7591d", new[] { 4 }, "0b7d1a12-fb75-465d-9e9a-82a476f9c92e", "Pode atualizar os dados de um usuário", "CanUserUpdate", "CANUSERUPDATE", "ac-user-page" },
            //         { "8b670ed0-2309-489d-a2d3-303b426ce48a", new[] { 1, 2, 3, 4, 5 }, "22a3b523-0a8c-4480-a57d-906011c5f732", "Pode visualizar todas as dashboards de controle de acesso", "CanDashboardControleAcessoAll", "CANDASHBOARDCONTROLEACESSOALL", "ac-dashboardControleAcesso-page" },
            //         { "8ce77d59-d2ae-42be-95ea-59cf4367c208", new[] { 1, 2, 3, 4, 5 }, "793736e6-c41d-466b-b441-0fccda49c6fb", "Pode realizar todas as ações/operações em todos os vendedores", "CanVendedorAll", "CANVENDEDORALL", "ac-vendedor-page" },
            //         { "8e6dcf1d-2811-450a-9dbc-239bcb5b1206", new[] { 3 }, "de65b5f2-3684-4e5e-a96b-7cab747caa45", "Pode criar um produto de cliente", "CanClienteProdutoCreate", "CANCLIENTEPRODUTOCREATE", "ac-clienteProduto-page" },
            //         { "90e0f385-d4dc-4333-b0d5-db253975fe53", new[] { 5 }, "d33e1b11-c7ca-4edf-8f0b-b3997e3cdef5", "Pode deletar um serviço de um fornecedor", "CanFornecedorServicoDelete", "CANFORNECEDORSERVICODELETE", "ac-fornecedorServico-page" },
            //         { "9232ceeb-750c-4541-b08e-96b4e7098349", new[] { 5 }, "e2d9767d-f42c-41a6-aff3-700bf2f669bd", "Pode deletar um pipeline", "CanPipelineDelete", "CANPIPELINEDELETE", "ac-pipeline-page" },
            //         { "97fab8af-928c-407b-8b22-21621a14f966", new[] { 1, 2, 3, 4, 5 }, "8fa3eeb1-a117-4029-8c07-6dfd61cbbfc1", "Pode realizar todas as ações/operações em todos os produtos", "CanProdutoAll", "CANPRODUTOALL", "ac-produto-page" },
            //         { "98107257-6d0a-476a-a168-b381f35495b0", new[] { 5 }, "1ec38d69-14a1-4e53-bfa5-1f7fcd4930f6", "Pode deletar uma fatura de contrato de cliente", "CanClienteContratoFaturaDelete", "CANCLIENTECONTRATOFATURADELETE", "ac-clienteContratoFatura-page" },
            //         { "9cd9443f-b2ea-4687-825c-8f052a35741a", new[] { 5 }, "9c44cc64-d76f-429a-9078-6b2acdb0b95d", "Pode deletar um grupo", "CanGroupDelete", "CANGROUPDELETE", "ac-group-page" },
            //         { "9d3bbf52-658c-4394-9a0f-58cd89ac5aee", new[] { 2 }, "002e83d1-3107-4cf8-afc5-0116dc4006a6", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroRead", "CANCHAVEAPITERCEIROREAD", "ac-chaveApiTerceiro-page" },
            //         { "9f1760d1-01bb-4120-a18c-965d4f5012c8", new[] { 1 }, "45daace2-e691-43d9-a20e-0959f2d0e680", "Pode listar os dados de todos os contratos vinculados a vendedores", "CanVendedorContratoList", "CANVENDEDORCONTRATOLIST", "ac-vendedorContrato-page" },
            //         { "a2bbd3be-b8ce-4321-9741-81c03efc610a", new[] { 2 }, "d892219b-afd7-4ca4-989a-5d653c4171f4", "Pode listar os dados de um produto de fornecedor", "CanFornecedorProdutoRead", "CANFORNECEDORPRODUTOREAD", "ac-fornecedorProduto-page" },
            //         { "a2ce58be-a29f-47c9-bab0-e8a6c06476c2", new[] { 1 }, "587f88de-5b5e-4154-8ba0-7e26867e7c88", "Pode listar todas as rotinas events histories", "CanRotinaEventHistoryList", "CANROTINAEVENTHISTORYLIST", "ac-rotinaEventHistory-page" },
            //         { "a6b939c2-5608-4c79-b4c3-08fa0b429bcf", new[] { 5 }, "b030a681-24b4-46a2-97f9-7c33d25bd24b", "Pode deletar um produto de cliente", "CanClienteProdutoDelete", "CANCLIENTEPRODUTODELETE", "ac-clienteProduto-page" },
            //         { "a71163a1-dc83-4e94-b217-7a97efc0e581", new[] { 1 }, "68165e0e-0f2d-41cb-a0c6-53bf221eeef9", "Pode listar os dados de todos os produtos de fornecedores", "CanFornecedorProdutoList", "CANFORNECEDORPRODUTOLIST", "ac-fornecedorProduto-page" },
            //         { "a77c203d-ac9f-4fca-8ccf-973b4da1b380", new[] { 1 }, "2a30ac8c-ae45-43ee-a02f-59b3062c31cf", "Pode listar os dados de todos os pipelines", "CanPipelineList", "CANPIPELINELIST", "ac-pipeline-page" },
            //         { "a7ea47d8-ddc1-4dfe-9947-9405c908dcdd", new[] { 2 }, "6b4384b2-b508-4331-880e-ce54c2469941", "Pode listar os dados de um contrato de cliente", "CanClienteContratoRead", "CANCLIENTECONTRATOREAD", "ac-clienteContrato-page" },
            //         { "a920cd4f-0348-47b4-a092-3dcee3302321", new[] { 1, 2, 3, 4, 5 }, "0f65d5ba-8f82-4891-9976-d5b2bef3d26c", "Pode realizar todas as ações/operações em dashboard comercial", "CanDashboardComercialAll", "CANDASHBOARDCOMERCIALALL", "ac-dashboardComercial-page" },
            //         { "a9b49c93-b0f3-4f02-b4c6-00eebac46768", new[] { 1 }, "710281b6-7afb-4cce-845c-990c2983a882", "Pode listar os dados de todos os produtos de clientes", "CanClienteProdutoList", "CANCLIENTEPRODUTOLIST", "ac-clienteProduto-page" },
            //         { "aa6b5b30-fb88-4f5d-8d1e-655e8d037a36", new[] { 2 }, "6fa66e30-aab7-487b-a811-91b3a14a805f", "Pode listar os dado de um serviço de fornecedor", "CanFornecedorServicoRead", "CANFORNECEDORSERVICOREAD", "ac-fornecedorServico-page" },
            //         { "ac66de24-7be5-4562-a810-876ef9d51c9d", new[] { 1 }, "648d2a8c-b93e-4794-8b73-a66c922620a1", "Pode listar os dados de todos os contratos de clientes", "CanClienteContratoList", "CANCLIENTECONTRATOLIST", "ac-clienteContrato-page" },
            //         { "b20c4735-935d-4eb6-b52f-5707737feeb5", new[] { 5 }, "e55481be-3be6-4da9-8ec4-6ea0c34ee1e8", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroDelete", "CANCHAVEAPITERCEIRODELETE", "ac-chaveApiTerceiro-page" },
            //         { "b359df5a-a976-4968-9c84-f75e9d589748", new[] { 1 }, "4032ebed-8f7c-44b2-bb9d-e8e24da68636", "Pode listar os dados de todos os grupos", "CanGroupList", "CANGROUPLIST", "ac-group-page" },
            //         { "b60fcbca-1396-48d8-bfc6-2ade7d83a0e8", new[] { 5 }, "abadee86-a8b1-4c04-a7da-3ee39bdf7d5f", "Pode deletar um fornecedor", "CanForncedorDelete", "CANFORNCEDORDELETE", "ac-forncedor-page" },
            //         { "b8c257ea-d285-4e2c-b78f-57ca3e94914f", new[] { 1 }, "d71be324-8a91-40c4-868a-e65a54bc9640", "Pode listar os dados de todos os serviços de fornecedores", "CanFornecedorServicoList", "CANFORNECEDORSERVICOLIST", "ac-fornecedorServico-page" },
            //         { "b9e8caea-1efc-43ad-a192-38424750a8be", new[] { 1 }, "e4beb8d5-725b-4bab-a0b9-35b15d0ae74d", "Pode listar os dados de todos os serviços", "CanServicoList", "CANSERVICOLIST", "ac-servico-page" },
            //         { "bdfd8af9-cbaa-45ee-848f-655d0fef94a1", new[] { 1 }, "f5d9ff31-db8a-47dd-ba28-90c9800e5385", "Pode realizar todas as ações/operações relacionadas a relatórios de vendedores", "CanVendedorRelatorioComissaoList", "CANVENDEDORRELATORIOCOMISSAOLIST", "ac-vendedorRelatorioComissao-page" },
            //         { "c0e784a2-0da9-438a-9ab4-03442d1aa406", new[] { 1 }, "d12dc71f-3608-4ce5-84f3-490708e01353", "Pode listar o título do sistema", "CanTitleSystemList", "CANTITLESYSTEMLIST", "ac-titleSystem-page" },
            //         { "c5d14df8-7d4b-44ce-b3cf-c11191c5cef1", new[] { 2 }, "6e0a4c53-93ae-4c37-9cbc-719489144d31", "Pode listar os dados de uma fatura de contrato de cliente", "CanClienteContratoFaturaRead", "CANCLIENTECONTRATOFATURAREAD", "ac-clienteContratoFatura-page" },
            //         { "cf0d1a3f-572b-49fb-b4c7-43fb3a67ecb0", new[] { 1, 2, 3, 4, 5 }, "f5a2d1e7-9da6-4298-83ef-348730dd8f5a", "Pode realizar todas as ações/operações em todos os produtos de fornecedores", "CanFornecedorProdutoAll", "CANFORNECEDORPRODUTOALL", "ac-fornecedorProduto-page" },
            //         { "d0437f3a-01af-4b90-84c1-76ef30302ba0", new[] { 2 }, "2bfbe311-f8d0-45c7-ab03-1cfd85ea8996", "Pode listar os dados de uma comissão de vendedor", "CanVendedorComissaoRead", "CANVENDEDORCOMISSAOREAD", "ac-vendedorComissao-page" },
            //         { "d1caad0b-6144-47c8-990f-440ad8e0d9e6", new[] { 1 }, "140ceab2-fe08-4d91-aa00-90a559dc2cdc", "Pode listar os dados de todos os clientes", "CanClienteList", "CANCLIENTELIST", "ac-cliente-page" },
            //         { "d48df6b3-8980-4307-a18e-e9e62d39220f", new[] { 1, 2, 3, 4, 5 }, "5d85af76-9014-4fc5-8465-213dfc79bbdd", "Pode realizar todas as ações/operações em todos os serviços de clientes", "CanClienteServicoAll", "CANCLIENTESERVICOALL", "ac-clienteServico-page" },
            //         { "d4a88bb1-41ce-4c2b-adf5-981bce86d31c", new[] { 2 }, "c1d67286-b22c-4a7e-9808-fe2487490480", "Pode listar os dados de um produtos", "CanProdutoRead", "CANPRODUTOREAD", "ac-produto-page" },
            //         { "d630b732-d1b5-4eea-a522-24c9b70f646a", new[] { 4 }, "38f9b8d2-ec8f-47c8-ae86-993ba1e3022a", "Pode criar uma comissão de vendedor", "CanVendedorComissaoUpdate", "CANVENDEDORCOMISSAOUPDATE", "ac-vendedorComissao-page" },
            //         { "d641a5dc-9b77-4a5f-be1d-c5a9bc2feca8", new[] { 1, 2, 3, 4, 5 }, "5e0ca3a8-0740-4100-afcd-98c52b83df7f", "Pode realizar todas as ações/operações em dashboard publica", "CanDashboardPublicaAll", "CANDASHBOARDPUBLICAALL", "ac-dashboardPublica-page" },
            //         { "d6693bbb-cebb-447f-8e34-ff2406c6a663", new[] { 4 }, "a5ddb7fb-33c5-4209-a667-4ecac1366905", "Pode atualizar um produtos", "CanProdutoUpdate", "CANPRODUTOUPDATE", "ac-produto-page" },
            //         { "d66b1b10-45e0-42cf-979e-fa7331f188dd", new[] { 2 }, "ca23cadc-8d53-4354-8fb9-d7156b0b7af3", "Pode listar os dados de uma rotina event history", "CanRotinaEventHistoryRead", "CANROTINAEVENTHISTORYREAD", "ac-rotinaEventHistory-page" },
            //         { "d76420b9-679e-4228-9e90-b18f016c892a", new[] { 1, 2, 3, 4, 5 }, "2e615414-663d-450f-80df-1e0c96516f4b", "Pode realizar todas as ações/operações em todos os produtos de clientes", "CanClienteProdutoAll", "CANCLIENTEPRODUTOALL", "ac-clienteProduto-page" },
            //         { "d800fcd5-fa7f-4e74-8609-958252ad2768", new[] { 1 }, "3a12b50e-358b-4316-ad07-61c5179f5214", "Pode listar os dados de todas as roles/permissões", "CanRoleList", "CANROLELIST", "ac-role-page" },
            //         { "d8e6a17e-4a72-405e-8f59-203b7fbda34b", new[] { 3 }, "38cd7d6e-41d7-4d3a-9197-56f18cf24a1d", "Pode criar um contrato de cliente", "CanClienteContratoCreate", "CANCLIENTECONTRATOCREATE", "ac-clienteContrato-page" },
            //         { "dc2b83cf-1288-4f0a-843d-c0c36dd22911", new[] { 1, 2, 3, 4, 5 }, "2103bda1-16e5-4661-be24-6669e2759c02", "Pode realizar todas as ações/operações em todos os usuários", "CanUserAll", "CANUSERALL", "ac-user-page" },
            //         { "dc50cea3-c74c-497f-b1c7-4959950a823c", new[] { 5 }, "81a324ab-e5a4-4b25-bdf7-62b34c2fd074", "Pode deletar um usuário", "CanUserDelete", "CANUSERDELETE", "ac-user-page" },
            //         { "dc85707e-363f-47dc-9dff-be1cbd6b4ecf", new[] { 4 }, "80ae9a07-f23a-4cbe-9d75-537edc6bee96", "Pode atualizar um serviço de um fornecedor", "CanFornecedorServicoUpdate", "CANFORNECEDORSERVICOUPDATE", "ac-fornecedorServico-page" },
            //         { "dcea8d21-44c7-4d29-b175-d5096ebeee2e", new[] { 1, 2, 3, 4, 5 }, "8a1fa1de-8914-4fbb-8249-85569a1cce58", "Pode realizar todas as ações/operações em todas as faturas de contratos de clientes", "CanClienteContratoFaturaAll", "CANCLIENTECONTRATOFATURAALL", "ac-clienteContratoFatura-page" },
            //         { "dd1079f7-f351-4104-96bf-12bf9ded9d89", new[] { 3 }, "ceafbc1c-781a-437f-838f-3f380c2bfd6e", "Pode criar um cliente", "CanClienteCreate", "CANCLIENTECREATE", "ac-cliente-page" },
            //         { "deaa6e06-6135-48a7-b77e-882d62c2998d", new[] { 1, 2, 3, 4, 5 }, "91f3902d-6eb8-4141-bbbe-69e7c4dfbefa", "Pode realizar todas as ações/operações em todos as roles/permissões", "CanRoleAll", "CANROLEALL", "ac-role-page" },
            //         { "df65ac42-b0ab-4655-b53a-2843d74603f2", new[] { 1 }, "23f0619e-10a2-43b8-90ee-5ca5198d75fe", "Pode listar o título dos negócios", "CanTitleBussinesList", "CANTITLEBUSSINESLIST", "ac-titleBussines-page" },
            //         { "e166ac6b-f975-40ff-986f-db41a2228852", new[] { 3 }, "46009bde-3efe-4b95-a8d3-1fde55abebf6", "Pode visualizar um produto de fornecedor", "CanFornecedorProdutoCreate", "CANFORNECEDORPRODUTOCREATE", "ac-fornecedorProduto-page" },
            //         { "e2f9b919-c5ed-451c-8125-693aadb68a49", new[] { 5 }, "9a934f03-8667-4418-bc21-d6cda19cd22f", "Pode deletar um vínculo de contrato com um vendedor", "CanVendedorContratoDelete", "CANVENDEDORCONTRATODELETE", "ac-vendedorContrato-page" },
            //         { "e4ac0a28-d024-48f8-9929-209a058641e9", new[] { 3 }, "279bef26-a315-4805-abf6-b2620ca813eb", "Pode listar os dados de todas as chaves de api de terceiro", "CanChaveApiTerceiroCreate", "CANCHAVEAPITERCEIROCREATE", "ac-chaveApiTerceiro-page" },
            //         { "e6632632-425e-47d7-8dfb-f586c0521015", new[] { 2 }, "47b1f99d-b898-4dbb-a5df-35d6417d0e68", "Pode listar os dado de um cliente", "CanClienteRead", "CANCLIENTEREAD", "ac-cliente-page" },
            //         { "e961cc22-5414-48bb-9de0-b574df4591c3", new[] { 3 }, "ae454476-3602-49b2-b61a-a69302d62180", "Pode visualizar um vendedor", "CanVendedorCreate", "CANVENDEDORCREATE", "ac-vendedor-page" },
            //         { "eb44f73e-0410-4914-be7d-5871f3a2dd9e", new[] { 3 }, "9e5b30f4-70ee-4e94-a9bb-fa8a5132288d", "Pode criar um produtos", "CanProdutoCreate", "CANPRODUTOCREATE", "ac-produto-page" },
            //         { "ed070297-7fff-4ae1-8c75-25168daa85bb", new[] { 5 }, "15c29fa0-d8d9-421c-8e77-46a579f910df", "Pode deletar uma role/permissão", "CanRoleDelete", "CANROLEDELETE", "ac-role-page" },
            //         { "f04e4519-724d-48f7-bbfd-46014478e9b6", new[] { 1 }, "01687413-4997-41f3-b35f-d1f753432b84", "Pode listar os dados de todos os usuários", "CanUserList", "CANUSERLIST", "ac-user-page" },
            //         { "f0f62193-bed7-4040-b438-f9fa025da083", new[] { 1, 2, 3, 4, 5 }, "d5435d7f-7cf2-4f83-b7de-236635838a19", "Pode realizar todas as ações/operações em todos os fornecedores", "CanFornecedorAll", "CANFORNECEDORALL", "ac-fornecedor-page" },
            //         { "f5b28a98-524a-43fa-b650-71e69e2ef7d1", new[] { 1 }, "b528d380-503d-454f-8b66-443a9628d378", "Pode listar os dados de todos os produtos", "CanProdutoList", "CANPRODUTOLIST", "ac-produto-page" },
            //         { "f8384892-39f2-442a-b948-a0f647898e90", new[] { 1 }, "44fdfa29-d89b-444e-abfb-ec92f505d97e", "CanDashboardComercialClienteContratoList", "CanDashboardComercialClienteContratoList", "CANDASHBOARDCOMERCIALCLIENTECONTRATOLIST", "ac-dashboardComercialClienteContrato-page" },
            //         { "f8c89084-01de-4cf7-a297-2f3c1fac8c72", new[] { 2 }, "32b2b9fc-51e2-4f9e-8775-93f45d05f8f5", "Pode listar os dados de um serviço", "CanServicoRead", "CANSERVICOREAD", "ac-servico-page" },
            //         { "f964bc3f-de68-46a9-b1c6-21fd3945fed5", new[] { 5 }, "5e9a4292-a6ff-4e77-9122-29dc229c4680", "Pode deletar um produto de fornecedor", "CanFornecedorProdutoDelete", "CANFORNECEDORPRODUTODELETE", "ac-fornecedorProduto-page" }
            //     });

            // migrationBuilder.InsertData(
            //     table: "ChavesApiTerceiro",
            //     columns: new[] { "Id", "ApiTerceiro", "CreatedAt", "CreatedBy", "DataValidade", "Descricao", "IsDeleted", "Key", "UpdatedAt", "UpdatedBy" },
            //     values: new object[] { new Guid("eeeb471a-2d8c-4bd3-b772-974a3d8612e5"), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            // migrationBuilder.InsertData(
            //     table: "Rotinas",
            //     columns: new[] { "Id", "ChaveSequencial", "CreatedAt", "CreatedBy", "DataCompetenciaFim", "DataCompetenciaInicio", "Descricao", "DispatcherRoute", "IsDeleted", "Nome", "Observacao", "TenantId", "UpdatedAt", "UpdatedBy" },
            //     values: new object[,]
            //     {
            //         { new Guid("06cbc6d5-216a-45f9-8496-d0d2fe93bcf3"), 7, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina interna gera as comissões de vendedores. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).", "dispatch-vendedores-comissoes-create", false, "Gerar comissão de vendedores ativos no Boxapp", "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("2556044d-dcdc-4355-9e57-d1fa336a5363"), 5, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp todas as faturas não quitadas de contratos de clientes do bom controle", "dispatch-faturas-nao-quitadas-sync", false, "Sincronização de faturas não quitadas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("52538e24-79c2-4eca-823c-e124a8b4a213"), 2, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp os contratos de clientes ainda não existente, a partir do sistema Bom Controle.", "dispatch-contratos-sync", false, "Sincronização de contratos de clientes com o sistema Bom Controle", "", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("587a5f91-37ec-42ce-a79f-229d6a4d43a8"), 4, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2472), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp todas as faturas quitadas de contratos de clientes do bom controle", "dispatch-faturas-quitadas-sync", false, "Sincronização de faturas quitadas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("6c0ff275-2dd5-42a0-b488-e0665616fd24"), 3, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina atualiza a periodicidade dos novos contratos sincronizados a partir da rotina 2.", "dispatch-contratos-update", false, "Atualização de contratos de clientes com o sistema Bom Controle", "A atualização de periodicidade que ocorre logo após a importação dos contratos só se faz necessária uma vez que, o método da api do sistema Bom Controle que retorna os contratos não traz este dado. Portanto, se faz necessário buscá-lo em um outro método da api do Bom Controle.", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("85611459-4fa5-422a-b6ac-1a5bd5a83d9a"), 6, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina atualiza automaticamente no boxapp os dados de faturas a partir de informações do sistema Bom Controle.", "dispatch-faturas-update", false, "Atualização dos dados de faturas de contratos de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2487), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            //         { new Guid("ac9faa63-bdff-4c0a-8469-b188f710cae7"), 1, new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina insere automaticamente no boxapp os clientes ativos do sistema Bom Controle", "dispatch-clientes-sync", false, "Sincronização de clientes com o sistema Bom Controle", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 528, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" }
            //     });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 513, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 16, 11, 9, 33, 513, DateTimeKind.Unspecified).AddTicks(4873), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes",
                column: "VendedorId");
        }
    }
}
