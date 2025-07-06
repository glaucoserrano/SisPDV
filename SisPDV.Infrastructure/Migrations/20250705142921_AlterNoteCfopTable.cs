using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterNoteCfopTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notas",
                table: "cfops");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "cfops",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 2,
                column: "Notes",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 3,
                column: "Notes",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "cfops");

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
        }
    }
}
