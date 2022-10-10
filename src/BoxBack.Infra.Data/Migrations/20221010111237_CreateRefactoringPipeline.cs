using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateRefactoringPipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PipelineEtapaTarefas");

            migrationBuilder.CreateTable(
                name: "PipelineTarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PipelineEtapaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineTarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineTarefas_PipelineEtapas_PipelineEtapaId",
                        column: x => x.PipelineEtapaId,
                        principalTable: "PipelineEtapas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineTarefaAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    PipelineTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineTarefaAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineTarefaAnexos_PipelineTarefas_PipelineTarefaId",
                        column: x => x.PipelineTarefaId,
                        principalTable: "PipelineTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineTarefaApontamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    PipelineTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineTarefaApontamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineTarefaApontamentos_PipelineTarefas_PipelineTarefaId",
                        column: x => x.PipelineTarefaId,
                        principalTable: "PipelineTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineTarefaAssinantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PipelineTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineTarefaAssinantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineTarefaAssinantes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PipelineTarefaAssinantes_PipelineTarefas_PipelineTarefaId",
                        column: x => x.PipelineTarefaId,
                        principalTable: "PipelineTarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineTarefaTags",
                columns: table => new
                {
                    PipelineTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_PipelineTarefaTags", x => new { x.TarefaTagId, x.PipelineTarefaId });
                    table.ForeignKey(
                        name: "FK_PipelineTarefaTags_PipelineTarefas_PipelineTarefaId",
                        column: x => x.PipelineTarefaId,
                        principalTable: "PipelineTarefas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipelineTarefaTags_TarefaTags_TarefaTagId",
                        column: x => x.TarefaTagId,
                        principalTable: "TarefaTags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipelineTarefaApontamentoAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    PipelineTarefaApontamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineTarefaApontamentoAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineTarefaApontamentoAnexos_PipelineTarefaApontamentos_~",
                        column: x => x.PipelineTarefaApontamentoId,
                        principalTable: "PipelineTarefaApontamentos",
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
                name: "IX_PipelineTarefaAnexos_PipelineTarefaId",
                table: "PipelineTarefaAnexos",
                column: "PipelineTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaApontamentoAnexos_PipelineTarefaApontamentoId",
                table: "PipelineTarefaApontamentoAnexos",
                column: "PipelineTarefaApontamentoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaApontamentos_PipelineTarefaId",
                table: "PipelineTarefaApontamentos",
                column: "PipelineTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaAssinantes_PipelineTarefaId",
                table: "PipelineTarefaAssinantes",
                column: "PipelineTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaAssinantes_UserId",
                table: "PipelineTarefaAssinantes",
                column: "UserId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefas_PipelineEtapaId",
                table: "PipelineTarefas",
                column: "PipelineEtapaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaTags_PipelineTarefaId",
                table: "PipelineTarefaTags",
                column: "PipelineTarefaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineTarefaTags_TarefaTagId",
                table: "PipelineTarefaTags",
                column: "TarefaTagId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipelineTarefaAnexos");

            migrationBuilder.DropTable(
                name: "PipelineTarefaApontamentoAnexos");

            migrationBuilder.DropTable(
                name: "PipelineTarefaAssinantes");

            migrationBuilder.DropTable(
                name: "PipelineTarefaTags");

            migrationBuilder.DropTable(
                name: "PipelineTarefaApontamentos");

            migrationBuilder.DropTable(
                name: "PipelineTarefas");

            migrationBuilder.CreateTable(
                name: "PipelineEtapaTarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PipelineEtapaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
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
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
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
                    TarefaTagId = table.Column<Guid>(type: "uuid", nullable: false),
                    PipelineEtapaTarefaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                    PipelineEtapaTarefaApontamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 233, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 233, DateTimeKind.Unspecified).AddTicks(5045), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 231, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 3, 9, 28, 11, 231, DateTimeKind.Unspecified).AddTicks(1831), new TimeSpan(0, -3, 0, 0, 0)) });

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
        }
    }
}
