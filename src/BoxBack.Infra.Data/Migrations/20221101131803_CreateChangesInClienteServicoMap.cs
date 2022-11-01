using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInClienteServicoMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 1, 10, 18, 2, 589, DateTimeKind.Unspecified).AddTicks(7772), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 1, 10, 18, 2, 589, DateTimeKind.Unspecified).AddTicks(7797), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 1, 10, 18, 2, 579, DateTimeKind.Unspecified).AddTicks(4786), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 1, 10, 18, 2, 579, DateTimeKind.Unspecified).AddTicks(4813), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
