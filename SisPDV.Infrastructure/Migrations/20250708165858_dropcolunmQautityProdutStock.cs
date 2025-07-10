using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dropcolunmQautityProdutStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "productStock");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "productStock",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "productStock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "productStock",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "productStock",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "productStock");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "productStock");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "productStock");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "productStock",
                newName: "LastUpdate");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "productStock",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
