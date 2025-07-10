using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmenustockformparentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "ParentId",
                value: 16);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "ParentId",
                value: null);
        }
    }
}
