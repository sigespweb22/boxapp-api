using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rotinas_Tenants_TenantId",
                table: "Rotinas");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes");

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Rotinas",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Rotinas",
                columns: new[] { "Id", "ChaveSequencial", "CreatedAt", "CreatedBy", "DataCompetenciaFim", "DataCompetenciaInicio", "Descricao", "DispatcherRoute", "IsDeleted", "Nome", "Observacao", "PropertyId", "TenantId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b0c60d41-7b31-4e02-ab9e-ad2c9e351443"), 8, new DateTimeOffset(new DateTime(2023, 1, 25, 14, 46, 45, 103, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esta rotina interna gera as comissões de um vendedor apenas. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).", "dispatch-vendedores-comissoes-create-by-vendedorId", false, "Gerar comissões para um vendedor ativo no Boxapp", "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.", null, new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new DateTimeOffset(new DateTime(2023, 1, 25, 14, 46, 45, 103, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes",
                column: "VendedorId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_Rotinas_Tenants_TenantId",
                table: "Rotinas",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rotinas_Tenants_TenantId",
                table: "Rotinas");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes");

            migrationBuilder.DropIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes");

            migrationBuilder.DeleteData(
                table: "Rotinas",
                keyColumn: "Id",
                keyValue: new Guid("b0c60d41-7b31-4e02-ab9e-ad2c9e351443"));

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Rotinas");

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_ClienteContratoId",
                table: "VendedoresComissoes",
                column: "ClienteContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendedoresComissoes_VendedorId",
                table: "VendedoresComissoes",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rotinas_Tenants_TenantId",
                table: "Rotinas",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
