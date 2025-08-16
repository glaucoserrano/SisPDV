using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmenuOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[,]
                {
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, 21, null, "NFce", null, "", true },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, 22, 23, "Emitir", null, "", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 23);
        }
    }
}
