using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altermenuOrderCash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FormName", "Title" },
                values: new object[] { null, "Venda" });

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[] { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "OrderForm", 23, null, "Pedido", null, "", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FormName", "Title" },
                values: new object[] { "OrderForm", "Pedido" });
        }
    }
}
