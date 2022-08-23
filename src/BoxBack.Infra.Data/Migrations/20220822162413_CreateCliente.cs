using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AspNetGroups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CNPJ = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TelefonePrincipal = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    EmailPrincipal = table.Column<string>(type: "text", nullable: true),
                    Observacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DataFundacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CodigoMunicipio = table.Column<int>(type: "integer", nullable: true),
                    Rua = table.Column<string>(type: "text", nullable: true, defaultValue: "500"),
                    Numero = table.Column<string>(type: "text", nullable: true, defaultValue: "5"),
                    Complemento = table.Column<string>(type: "text", nullable: true, defaultValue: "50"),
                    Cidade = table.Column<string>(type: "text", nullable: true, defaultValue: "255"),
                    Estado = table.Column<string>(type: "text", nullable: true, defaultValue: "4"),
                    Cep = table.Column<string>(type: "text", nullable: true, defaultValue: "20"),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TenantId",
                table: "Clientes",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AspNetGroups",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"));

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
    }
}
