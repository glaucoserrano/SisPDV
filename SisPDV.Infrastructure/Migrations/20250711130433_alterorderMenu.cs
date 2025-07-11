using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterorderMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 8);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "Order",
                value: 12);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "Order",
                value: 13);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "Order",
                value: 14);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "Order",
                value: 15);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "Order",
                value: 16);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "Order",
                value: 17);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 8);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "Order",
                value: 12);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "Order",
                value: 7);
        }
    }
}
