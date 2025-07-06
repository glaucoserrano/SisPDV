using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAccountants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accountant",
                table: "accountant");

            migrationBuilder.RenameTable(
                name: "accountant",
                newName: "accountants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountants",
                table: "accountants",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accountants",
                table: "accountants");

            migrationBuilder.RenameTable(
                name: "accountants",
                newName: "accountant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountant",
                table: "accountant",
                column: "Id");
        }
    }
}
