using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInApplicationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 20, 13, 41, 35, 959, DateTimeKind.Unspecified).AddTicks(9627), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 20, 13, 41, 35, 959, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 20, 13, 41, 35, 958, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 20, 13, 41, 35, 958, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 111, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 111, DateTimeKind.Unspecified).AddTicks(7303), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 109, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 109, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
