using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateNewFieldInEntityApplicarionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataAniversario",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefoneCelular",
                table: "AspNetUsers",
                type: "integer",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 360, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 360, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 358, DateTimeKind.Unspecified).AddTicks(7211), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 6, 10, 20, 43, 358, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, -3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataAniversario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefoneCelular",
                table: "AspNetUsers");

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
    }
}
