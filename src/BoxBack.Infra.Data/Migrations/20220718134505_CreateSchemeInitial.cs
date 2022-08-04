using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateSchemeInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    PerfilFoto = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Funcao = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "da8e4f70-8be9-4d8f-a684-5b97f19d252c", "Master", "MASTER" },
                    { "b3a5b61d-7ff4-43cb-bad4-a945b150fc72", "194c8eaf-4f2e-4d0e-9b45-ab664a763c1e", "Servicos_Todos", "SERVICOS_TODOS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "ca431822-360a-4ee6-b978-66564d429fc7", null, false, false, null, null, "ALAN.REZENDE@BOXTECNOLOGIA.COM.BR", "AQAAAAEAACcQAAAAEFGbgHKOKiDDs5fvXN8kHviorntHToMKurnVJNmsFQNInxhQOyZTwJ2w0SpbyCdZbA==", null, false, "c9514850-61dd-4cc1-b909-88b79b035643", false, "alan.rezende@boxtecnologia.com.br" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "b3a5b61d-7ff4-43cb-bad4-a945b150fc72" }
                });

            migrationBuilder.InsertData(
                table: "ContaUsuarios",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Funcao", "IsDeleted", "Nome", "PerfilFoto", "Setor", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"), new DateTime(2022, 7, 18, 10, 45, 4, 767, DateTimeKind.Local).AddTicks(5454), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "ENGENHEIRO_SOFTWARE", false, "Alan Leite de Rezende", "data:image/jpeg;base64,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", "TECNOLOGIA_INFORMACAO", new DateTime(2022, 7, 18, 10, 45, 4, 768, DateTimeKind.Local).AddTicks(3278), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaUsuarios_UserId",
                table: "ContaUsuarios",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContaUsuarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
