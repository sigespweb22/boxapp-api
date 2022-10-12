using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateRefactoringFornecedorClienteServicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesAtivos");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.CreateTable(
                name: "FornecedorServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CodigoServico = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UnidadeMedida = table.Column<int>(type: "integer", nullable: false),
                    Caracteristicas = table.Column<string>(type: "text", nullable: true),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorServicos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CodigoUnico = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ValorCusto = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m),
                    Caracteristicas = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    UnidadeMedida = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    FornecedorServicoId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_FornecedorServicos_FornecedorServicoId",
                        column: x => x.FornecedorServicoId,
                        principalTable: "FornecedorServicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Servicos_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClienteServicos",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m),
                    Caracteristicas = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    CobrancaTipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteServicos", x => new { x.ClienteId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_ClienteServicos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClienteServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 591, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 591, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 589, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 20, 58, 2, 589, DateTimeKind.Unspecified).AddTicks(7951), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteServicos_ServicoId",
                table: "ClienteServicos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorServicos_FornecedorId",
                table: "FornecedorServicos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CodigoUnico",
                table: "Servicos",
                column: "CodigoUnico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FornecedorServicoId",
                table: "Servicos",
                column: "FornecedorServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Nome",
                table: "Servicos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_TenantId",
                table: "Servicos",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteServicos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "FornecedorServicos");

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    AtivoTipoServicoTipo = table.Column<int>(type: "integer", nullable: false),
                    Caracteristica = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    CodigoUnico = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Observacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Referencia = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UnidadeMedida = table.Column<int>(type: "integer", nullable: false),
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
                    AtivoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Caracteristica = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ValorCusto = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m),
                    ValorVenda = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m)
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
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 16, 15, 9, 26, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 16, 15, 9, 26, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 16, 15, 9, 23, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 16, 15, 9, 23, DateTimeKind.Unspecified).AddTicks(7210), new TimeSpan(0, -3, 0, 0, 0)) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_TenantId",
                table: "Ativos",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesAtivos_AtivoId",
                table: "ClientesAtivos",
                column: "AtivoId");
        }
    }
}
