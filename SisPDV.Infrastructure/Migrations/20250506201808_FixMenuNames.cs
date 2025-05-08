using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMenuNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Configurações");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FormName", "Title" },
                values: new object[] { "UserAddForm", "Cadastro de Usuário" });

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FormName", "Order", "ParentId", "Title" },
                values: new object[] { "UserChangePassword", 2, 1, "Alterar Senha" });

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FormName", "Order", "ParentId", "Title" },
                values: new object[] { "PermissionMenuForm", 3, 1, "Permissão de Usuário" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Menu Principal");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FormName", "Title" },
                values: new object[] { null, "Configurações" });

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FormName", "Order", "ParentId", "Title" },
                values: new object[] { "UserAddForm", 1, 2, "Cadastro de Usuário" });

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FormName", "Order", "ParentId", "Title" },
                values: new object[] { "UserChangePassword", 2, 2, "Alterar Senha" });

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FormName", "Order", "ParentId", "Title", "UpdatedAt", "UpdatedBy", "Visible" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PermissionMenuForm", 3, 2, "Permissão de Usuário", null, "", true });
        }
    }
}
