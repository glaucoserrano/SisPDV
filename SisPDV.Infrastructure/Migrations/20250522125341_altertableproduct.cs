using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altertableproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "Fractional",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Service",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Weighing",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fractional",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Weighing",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "Name");
        }
    }
}
