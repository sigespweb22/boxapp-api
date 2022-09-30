using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxBack.Infra.Data.Migrations
{
    public partial class CreateChangesInPipelineAssinanteMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PipelineAssinantes_PipelineId",
                table: "PipelineAssinantes");

            migrationBuilder.DropIndex(
                name: "IX_PipelineAssinantes_UserId",
                table: "PipelineAssinantes");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 594, DateTimeKind.Unspecified).AddTicks(2456), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 594, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 592, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 16, 12, 15, 592, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_PipelineAssinantes_PipelineId",
                table: "PipelineAssinantes",
                column: "PipelineId");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineAssinantes_UserId",
                table: "PipelineAssinantes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PipelineAssinantes_PipelineId",
                table: "PipelineAssinantes");

            migrationBuilder.DropIndex(
                name: "IX_PipelineAssinantes_UserId",
                table: "PipelineAssinantes");

            migrationBuilder.UpdateData(
                table: "AspNetGroups",
                keyColumn: "Id",
                keyValue: new Guid("23e63d9c-283b-496b-b7d8-7dac2ef7a822"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 411, DateTimeKind.Unspecified).AddTicks(7230), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 411, DateTimeKind.Unspecified).AddTicks(7240), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 409, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 28, 10, 9, 54, 409, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, -3, 0, 0, 0)) });

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
        }
    }
}
