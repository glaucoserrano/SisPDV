using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPersonMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[,]
                {
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, 6, null, "Cadastro", null, "", true },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "PersonForm", 6, 7, "Cadastro de Pessoas (Cliente, Fornecedor, Transportadora)", null, "", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
