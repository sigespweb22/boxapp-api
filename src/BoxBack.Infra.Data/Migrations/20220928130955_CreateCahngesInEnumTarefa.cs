using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateCahngesInEnumTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PipelineEtapaTarefas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 411, DateTimeKind.Unspecified).AddTicks(7230), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 411, DateTimeKind.Unspecified).AddTicks(7240), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 409, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 409, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PipelineEtapaTarefas");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 60, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 60, DateTimeKind.Unspecified).AddTicks(1003), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 57, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 57, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
