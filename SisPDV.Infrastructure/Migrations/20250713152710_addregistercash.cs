using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addregistercash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cashNumber = table.Column<int>(type: "integer", nullable: false),
                    openingDateTime = table.Column<int>(type: "integer", nullable: false),
                    closingDateTime = table.Column<int>(type: "integer", nullable: false),
                    openingAmount = table.Column<int>(type: "integer", nullable: false),
                    closingAmount = table.Column<int>(type: "integer", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cashMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashRegisterId = table.Column<int>(type: "integer", nullable: true),
                    MovementDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Origin = table.Column<string>(type: "text", nullable: false),
                    paymentMethodId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cashMovements_cashRegisters_CashRegisterId",
                        column: x => x.CashRegisterId,
                        principalTable: "cashRegisters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cashMovements_paymentMethods_paymentMethodId",
                        column: x => x.paymentMethodId,
                        principalTable: "paymentMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cashMovements_CashRegisterId",
                table: "cashMovements",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_cashMovements_paymentMethodId",
                table: "cashMovements",
                column: "paymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cashMovements");

            migrationBuilder.DropTable(
                name: "cashRegisters");
        }
    }
}
