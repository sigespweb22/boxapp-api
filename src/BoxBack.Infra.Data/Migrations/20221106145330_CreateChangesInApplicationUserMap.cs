using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInApplicationUserMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TelefoneCelular",
                table: "AspNetUsers",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                defaultValue: 99999999999L,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 28, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 28, DateTimeKind.Unspecified).AddTicks(6161), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TelefoneCelular",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 26, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 11, 53, 30, 26, DateTimeKind.Unspecified).AddTicks(4851), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelefoneCelular",
                table: "AspNetUsers",
                type: "integer",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 20,
                oldDefaultValue: 99999999999L);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 360, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 360, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TelefoneCelular",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 358, DateTimeKind.Unspecified).AddTicks(7211), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 358, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
