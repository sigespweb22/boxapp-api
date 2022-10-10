using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornecedorSolucoes");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoMunicipio",
                table: "Fornecedores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Fornecedores",
                type: "text",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "CodigoMunicipio",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Fornecedores");

            migrationBuilder.CreateTable(
                name: "FornecedorSolucoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric(7,3)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorSolucoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorSolucoes_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FornecedorSolucoes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 8, 12, 36, 537, DateTimeKind.Unspecified).AddTicks(3853), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 8, 12, 36, 537, DateTimeKind.Unspecified).AddTicks(3878), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 8, 12, 36, 535, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 8, 12, 36, 535, DateTimeKind.Unspecified).AddTicks(315), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorSolucoes_FornecedorId",
                table: "FornecedorSolucoes",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorSolucoes_TenantId",
                table: "FornecedorSolucoes",
                column: "TenantId");
        }
    }
}
