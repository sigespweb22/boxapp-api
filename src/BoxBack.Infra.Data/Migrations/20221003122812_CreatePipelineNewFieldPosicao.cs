using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreatePipelineNewFieldPosicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Posicao",
                table: "Pipelines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 233, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 233, DateTimeKind.Unspecified).AddTicks(5045), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 231, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 231, DateTimeKind.Unspecified).AddTicks(1831), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicao",
                table: "Pipelines");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 594, DateTimeKind.Unspecified).AddTicks(2456), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 594, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 592, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 592, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
