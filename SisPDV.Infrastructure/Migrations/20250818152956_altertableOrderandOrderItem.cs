using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altertableOrderandOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "orderItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "orderItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "cashMovements",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cashMovements_OrderId",
                table: "cashMovements",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_cashMovements_orders_OrderId",
                table: "cashMovements",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cashMovements_orders_OrderId",
                table: "cashMovements");

            migrationBuilder.DropIndex(
                name: "IX_cashMovements_OrderId",
                table: "cashMovements");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "cashMovements");
        }
    }
}
