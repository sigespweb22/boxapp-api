using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreatePipelineAndAllReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pipelines_Tenants_TenantId",
                table: "Pipelines");

            migrationBuilder.DropIndex(
                name: "IX_Pipelines_TenantId",
                table: "Pipelines");

            migrationBuilder.CreateTable(
                name: "PipelineAssinantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PipelineId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineAssinantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineAssinantes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PipelineAssinantes_Pipelines_PipelineId",
                        column: x => x.PipelineId,
                        principalTable: "Pipelines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    AlertaEstagnacao = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    PipelineId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapas_Pipelines_PipelineId",
                        column: x => x.PipelineId,
                        principalTable: "Pipelines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TarefaTags",
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
                    table.PrimaryKey("PK_TarefaTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarefaTags_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    PipelineEtapaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefas_PipelineEtapas_PipelineEtapaId",
                        column: x => x.PipelineEtapaId,
                        principalTable: "PipelineEtapas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefaAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefaAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaAnexos_PipelineEtapaTarefas_PipelineEtap~",
                        column: x => x.PipelineEtapaTarefaId,
                        principalTable: "PipelineEtapaTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefaApontamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefaApontamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaApontamentos_PipelineEtapaTarefas_Pipeli~",
                        column: x => x.PipelineEtapaTarefaId,
                        principalTable: "PipelineEtapaTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefaAssinantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefaAssinantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaAssinantes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaAssinantes_PipelineEtapaTarefas_Pipeline~",
                        column: x => x.PipelineEtapaTarefaId,
                        principalTable: "PipelineEtapaTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefaTags",
                columns: table => new
                {
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    TarefaTagId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefaTags", x => new { x.TarefaTagId, x.PipelineEtapaTarefaId });
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaTags_PipelineEtapaTarefas_PipelineEtapaT~",
                        column: x => x.PipelineEtapaTarefaId,
                        principalTable: "PipelineEtapaTarefas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaTags_TarefaTags_TarefaTagId",
                        column: x => x.TarefaTagId,
                        principalTable: "TarefaTags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefaApontamentoAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    PipelineEtapaTarefaApontamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineEtapaTarefaApontamentoAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineEtapaTarefaApontamentoAnexos_PipelineEtapaTarefaApo~",
                        column: x => x.PipelineEtapaTarefaApontamentoId,
                        principalTable: "PipelineEtapaTarefaApontamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 60, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 60, DateTimeKind.Unspecified).AddTicks(1003), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 57, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 26, 14, 37, 54, 57, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Pipelines_TenantId",
                table: "Pipelines",
                column: "TenantId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineAssinantes_PipelineId",
                table: "PipelineAssinantes",
                column: "PipelineId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineAssinantes_UserId",
                table: "PipelineAssinantes",
                column: "UserId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapas_PipelineId",
                table: "PipelineEtapas",
                column: "PipelineId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaAnexos_PipelineEtapaTarefaId",
                table: "PipelineEtapaTarefaAnexos",
                column: "PipelineEtapaTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaApontamentoAnexos_PipelineEtapaTarefaApo~",
                table: "PipelineEtapaTarefaApontamentoAnexos",
                column: "PipelineEtapaTarefaApontamentoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaApontamentos_PipelineEtapaTarefaId",
                table: "PipelineEtapaTarefaApontamentos",
                column: "PipelineEtapaTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaAssinantes_PipelineEtapaTarefaId",
                table: "PipelineEtapaTarefaAssinantes",
                column: "PipelineEtapaTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaAssinantes_UserId",
                table: "PipelineEtapaTarefaAssinantes",
                column: "UserId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefas_PipelineEtapaId",
                table: "PipelineEtapaTarefas",
                column: "PipelineEtapaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaTags_PipelineEtapaTarefaId",
                table: "PipelineEtapaTarefaTags",
                column: "PipelineEtapaTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineEtapaTarefaTags_TarefaTagId",
                table: "PipelineEtapaTarefaTags",
                column: "TarefaTagId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_TarefaTags_TenantId",
                table: "TarefaTags",
                column: "TenantId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_Pipelines_Tenants_TenantId",
                table: "Pipelines",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pipelines_Tenants_TenantId",
                table: "Pipelines");

            migrationBuilder.DropTable(
                name: "PipelineAssinantes");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefaAnexos");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefaApontamentoAnexos");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefaAssinantes");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefaTags");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefaApontamentos");

            migrationBuilder.DropTable(
                name: "TarefaTags");

            migrationBuilder.DropTable(
                name: "PipelineEtapaTarefas");

            migrationBuilder.DropTable(
                name: "PipelineEtapas");

            migrationBuilder.DropIndex(
                name: "IX_Pipelines_TenantId",
                table: "Pipelines");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pipelines_Tenants_TenantId",
                table: "Pipelines",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
