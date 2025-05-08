using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCreatedByOnTableMenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "System");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "");
        }
    }
}
