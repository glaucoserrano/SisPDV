using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altermenuOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FormName", "Order", "Title" },
                values: new object[] { "OrderForm", 22, "Pedido" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FormName", "Order", "Title" },
                values: new object[] { null, 21, "NFce" });

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[] { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, 22, 23, "Emitir", null, "", true });
        }
    }
}
