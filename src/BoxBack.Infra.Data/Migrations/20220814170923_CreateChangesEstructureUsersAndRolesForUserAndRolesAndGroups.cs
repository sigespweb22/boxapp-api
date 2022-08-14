using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesEstructureUsersAndRolesForUserAndRolesAndGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a5b61d-7ff4-43cb-bad4-a945b150fc72");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"));

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NomeExibicao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    WhatsAppPrincipal = table.Column<string>(type: "text", nullable: true),
                    EmailPrincipal = table.Column<string>(type: "text", nullable: false),
                    ApiKey = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UniqueKey = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetGroups_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleGroups",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleGroups", x => new { x.RoleId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleGroups_AspNetGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AspNetGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoleGroups_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserGroups",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_AspNetUserGroups_AspNetGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AspNetGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserGroups_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ApiKey", "Cnpj", "CreatedAt", "CreatedBy", "EmailPrincipal", "IsDeleted", "Nome", "NomeExibicao", "NomeFantasia", "RazaoSocial", "UpdatedAt", "UpdatedBy", "WhatsAppPrincipal" },
                values: new object[] { new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), new Guid("57d390e7-2b87-47fe-9bc8-0bae3a388499"), "12.368.943/0001-50", new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 77, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", "rafale@boxtecnologia.com.br", false, "Box Tecnologia Ltda", "Box Tecnologia", null, null, new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 77, DateTimeKind.Unspecified).AddTicks(2684), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", null });

            migrationBuilder.InsertData(
                table: "AspNetGroups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "TenantId", "UniqueKey", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 78, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9", false, "Master", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"), "ors0eAr4DPkvrwhy5gVnQAqRDnJUO43j9HzbkPyZ/7Q=", new DateTimeOffset(new DateTime(2022, 8, 14, 14, 9, 23, 78, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, -3, 0, 0, 0)), "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Avatar", "FullName", "TenantId" },
                values: new object[] { "ALDR", "Alan Leite de Rezende", new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45") });

            migrationBuilder.InsertData(
                table: "AspNetRoleGroups",
                columns: new[] { "GroupId", "RoleId" },
                values: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.InsertData(
                table: "AspNetUserGroups",
                columns: new[] { "GroupId", "UserId" },
                values: new object[] { new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetGroups_TenantId",
                table: "AspNetGroups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleGroups_GroupId",
                table: "AspNetRoleGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserGroups_GroupId",
                table: "AspNetUserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApiKey",
                table: "Tenants",
                column: "ApiKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Cnpj",
                table: "Tenants",
                column: "Cnpj",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleGroups");

            migrationBuilder.DropTable(
                name: "AspNetUserGroups");

            migrationBuilder.DropTable(
                name: "AspNetGroups");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3a5b61d-7ff4-43cb-bad4-a945b150fc72", "194c8eaf-4f2e-4d0e-9b45-ab664a763c1e", "Servicos_Todos", "SERVICOS_TODOS" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Avatar", "FullName" },
                values: new object[] { null, null });
        }
    }
}
