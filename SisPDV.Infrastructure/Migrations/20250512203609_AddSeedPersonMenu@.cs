using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPersonMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Cadastro de Pessoas (Cliente, Fornecedor, Transportadora)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Cadastro de Pessoas (Cliente, Fornecedor, Transportadora");
        }
    }
}
