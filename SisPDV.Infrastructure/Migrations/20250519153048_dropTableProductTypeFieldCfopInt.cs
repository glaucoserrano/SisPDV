using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dropTableProductTypeFieldCfopInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CFOP",
                table: "productTypes");

            migrationBuilder.AddColumn<int>(
                name: "CfopId",
                table: "productTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "System");

            migrationBuilder.CreateIndex(
                name: "IX_productTypes_CfopId",
                table: "productTypes",
                column: "CfopId");

            migrationBuilder.AddForeignKey(
                name: "FK_productTypes_cfops_CfopId",
                table: "productTypes",
                column: "CfopId",
                principalTable: "cfops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productTypes_cfops_CfopId",
                table: "productTypes");

            migrationBuilder.DropIndex(
                name: "IX_productTypes_CfopId",
                table: "productTypes");

            migrationBuilder.DropColumn(
                name: "CfopId",
                table: "productTypes");

            migrationBuilder.AddColumn<string>(
                name: "CFOP",
                table: "productTypes",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "cfops",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "unities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "");
        }
    }
}
