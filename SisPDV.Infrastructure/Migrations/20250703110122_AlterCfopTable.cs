﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCfopTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "cfops",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "cfops");
        }
    }
}
