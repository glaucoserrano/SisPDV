using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmenustockform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[] { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "StockForm", 6, null, "Configuração", null, "", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
