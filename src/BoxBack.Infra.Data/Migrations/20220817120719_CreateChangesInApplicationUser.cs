using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 111, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 111, DateTimeKind.Unspecified).AddTicks(7303), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Avatar", "Email", "EmailConfirmed", "FullName", "NormalizedEmail" },
                values: new object[] { "", "alan.rezende@boxtecnologia.com.br", true, "ALAN LEITE DE REZENDE", "ALAN.REZENDE@BOXTECNOLOGIA.COM.BR" });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 109, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 17, 9, 7, 19, 109, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 78, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 78, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Avatar", "Email", "EmailConfirmed", "FullName", "NormalizedEmail" },
                values: new object[] { "ALDR", null, false, "Alan Leite de Rezende", null });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 77, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 77, DateTimeKind.Unspecified).AddTicks(2684), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
