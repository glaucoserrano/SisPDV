using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigNfe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NFEDestination",
                table: "configs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NFEFinality",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NFEInitialNumber",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NFEModeEnabled",
                table: "configs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NFEPaymentForm",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NFEPresenceIndicator",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NFEPrint",
                table: "configs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NFESavePDF",
                table: "configs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NFESerial",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NFEXMLPath",
                table: "configs",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NFEDestination",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEFinality",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEInitialNumber",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEModeEnabled",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEPaymentForm",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEPresenceIndicator",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEPrint",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFESavePDF",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFESerial",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFEXMLPath",
                table: "configs");
        }
    }
}
