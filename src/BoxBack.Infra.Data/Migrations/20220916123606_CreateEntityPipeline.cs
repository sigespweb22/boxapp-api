using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateEntityPipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorCusto",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "Ativos");

            migrationBuilder.RenameColumn(
                name: "ClienteAtivoTipoServicoTipo",
                table: "Ativos",
                newName: "AtivoTipoServicoTipo");

            migrationBuilder.AddColumn<string>(
                name: "Caracteristica",
                table: "ClientesAtivos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "ClientesAtivos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorCusto",
                table: "ClientesAtivos",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorVenda",
                table: "ClientesAtivos",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Pipelines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pipelines_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 16, 9, 36, 5, 509, DateTimeKind.Unspecified).AddTicks(2334), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 16, 9, 36, 5, 509, DateTimeKind.Unspecified).AddTicks(2352), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 16, 9, 36, 5, 507, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 16, 9, 36, 5, 507, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Pipelines_TenantId",
                table: "Pipelines",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pipelines");

            migrationBuilder.DropColumn(
                name: "Caracteristica",
                table: "ClientesAtivos");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "ClientesAtivos");

            migrationBuilder.DropColumn(
                name: "ValorCusto",
                table: "ClientesAtivos");

            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "ClientesAtivos");

            migrationBuilder.RenameColumn(
                name: "AtivoTipoServicoTipo",
                table: "Ativos",
                newName: "ClienteAtivoTipoServicoTipo");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorCusto",
                table: "Ativos",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorVenda",
                table: "Ativos",
                type: "numeric(7,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 8, 10, 35, 37, 951, DateTimeKind.Unspecified).AddTicks(2084), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 8, 10, 35, 37, 951, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 8, 10, 35, 37, 949, DateTimeKind.Unspecified).AddTicks(2747), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 8, 10, 35, 37, 949, DateTimeKind.Unspecified).AddTicks(2780), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
