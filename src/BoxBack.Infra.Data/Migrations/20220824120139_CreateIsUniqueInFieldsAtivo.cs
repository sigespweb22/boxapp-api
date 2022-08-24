using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateIsUniqueInFieldsAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 24, 9, 1, 38, 967, DateTimeKind.Unspecified).AddTicks(1957), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 24, 9, 1, 38, 967, DateTimeKind.Unspecified).AddTicks(1971), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 24, 9, 1, 38, 965, DateTimeKind.Unspecified).AddTicks(5595), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 24, 9, 1, 38, 965, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_CodigoUnico",
                table: "Ativos",
                column: "CodigoUnico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_Nome",
                table: "Ativos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_Referencia",
                table: "Ativos",
                column: "Referencia",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ativos_CodigoUnico",
                table: "Ativos");

            migrationBuilder.DropIndex(
                name: "IX_Ativos_Nome",
                table: "Ativos");

            migrationBuilder.DropIndex(
                name: "IX_Ativos_Referencia",
                table: "Ativos");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 23, 9, 9, 13, 366, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 23, 9, 9, 13, 366, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 23, 9, 9, 13, 364, DateTimeKind.Unspecified).AddTicks(5364), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 23, 9, 9, 13, 364, DateTimeKind.Unspecified).AddTicks(5394), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
