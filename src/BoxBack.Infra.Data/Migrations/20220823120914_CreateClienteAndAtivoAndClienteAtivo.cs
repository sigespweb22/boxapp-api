using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateClienteAndAtivoAndClienteAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Referencia = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CodigoUnico = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m),
                    ValorVenda = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m),
                    UnidadeMedida = table.Column<int>(type: "integer", nullable: false),
                    ClienteAtivoTipoServicoTipo = table.Column<int>(type: "integer", nullable: false),
                    Caracteristica = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientesAtivos",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    AtivoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesAtivos", x => new { x.ClienteId, x.AtivoId });
                    table.ForeignKey(
                        name: "FK_ClientesAtivos_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientesAtivos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_TenantId",
                table: "Ativos",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesAtivos_AtivoId",
                table: "ClientesAtivos",
                column: "AtivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesAtivos");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 22, 13, 24, 13, 384, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 22, 13, 24, 13, 384, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 8, 22, 13, 24, 13, 382, DateTimeKind.Unspecified).AddTicks(7414), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 22, 13, 24, 13, 382, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, -3, 0, 0, 0)) });
        }
    }
}
