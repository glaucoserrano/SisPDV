using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterActiveAccountant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "accountants");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "accountants",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "accountants");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "accountants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
