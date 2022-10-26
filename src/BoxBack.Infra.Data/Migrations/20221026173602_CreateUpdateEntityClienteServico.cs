using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateUpdateEntityClienteServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteServicos",
                table: "ClienteServicos");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ClienteServicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClienteServicos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClienteServicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClienteServicos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ClienteServicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClienteServicos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ClienteServicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteServicos",
                table: "ClienteServicos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 26, 14, 36, 1, 453, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 26, 14, 36, 1, 453, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 26, 14, 36, 1, 450, DateTimeKind.Unspecified).AddTicks(7510), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 26, 14, 36, 1, 450, DateTimeKind.Unspecified).AddTicks(7537), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteServicos_ClienteId",
                table: "ClienteServicos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteServicos",
                table: "ClienteServicos");

            migrationBuilder.DropIndex(
                name: "IX_ClienteServicos_ClienteId",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClienteServicos");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClienteServicos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteServicos",
                table: "ClienteServicos",
                columns: new[] { "ClienteId", "ServicoId" });

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 591, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 591, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 589, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 589, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
