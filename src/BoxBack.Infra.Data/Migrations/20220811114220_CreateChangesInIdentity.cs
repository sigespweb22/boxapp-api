using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaUsuarios");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Funcao",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Setor",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ContaUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Funcao = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    PerfilFoto = table.Column<string>(type: "text", nullable: true),
                    Setor = table.Column<string>(type: "varchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaUsuarios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContaUsuarios",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Funcao", "IsDeleted", "Nome", "PerfilFoto", "Setor", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"), new DateTime(2022, 7, 18, 10, 45, 4, 767, DateTimeKind.Local).AddTicks(5454), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "ENGENHEIRO_SOFTWARE", false, "Alan Leite de Rezende", "data:image/jpeg;base64,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", "TECNOLOGIA_INFORMACAO", new DateTime(2022, 7, 18, 10, 45, 4, 768, DateTimeKind.Local).AddTicks(3278), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_ContaUsuarios_UserId",
                table: "ContaUsuarios",
                column: "UserId",
                unique: true);
        }
    }
}
