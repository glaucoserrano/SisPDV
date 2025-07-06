using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCfopTableAddNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "cfops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notas",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 2,
                column: "Notas",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 3,
                column: "Notas",
                value: "");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notas",
                table: "cfops");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 1);
        }
    }
}
