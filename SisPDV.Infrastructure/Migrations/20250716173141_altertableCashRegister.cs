using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altertableCashRegister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "closingAmount",
                table: "cashRegisters");

            migrationBuilder.AddColumn<int>(
                name: "ClosingDifferenceAmount",
                table: "cashRegisters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClosingExpectedAmount",
                table: "cashRegisters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClosingInformedAmount",
                table: "cashRegisters",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingDifferenceAmount",
                table: "cashRegisters");

            migrationBuilder.DropColumn(
                name: "ClosingExpectedAmount",
                table: "cashRegisters");

            migrationBuilder.DropColumn(
                name: "ClosingInformedAmount",
                table: "cashRegisters");

            migrationBuilder.AddColumn<int>(
                name: "closingAmount",
                table: "cashRegisters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
