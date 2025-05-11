using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterConfigNfe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NFEXMLPath",
                table: "configs",
                newName: "NFeXmlPath");

            migrationBuilder.RenameColumn(
                name: "NFESerial",
                table: "configs",
                newName: "NFeSerial");

            migrationBuilder.RenameColumn(
                name: "NFESavePDF",
                table: "configs",
                newName: "NFeSavePDF");

            migrationBuilder.RenameColumn(
                name: "NFEPrint",
                table: "configs",
                newName: "NFePrint");

            migrationBuilder.RenameColumn(
                name: "NFEPresenceIndicator",
                table: "configs",
                newName: "NFePresenceIndicator");

            migrationBuilder.RenameColumn(
                name: "NFEPaymentForm",
                table: "configs",
                newName: "NFePaymentForm");

            migrationBuilder.RenameColumn(
                name: "NFEInitialNumber",
                table: "configs",
                newName: "NFeInitialNumber");

            migrationBuilder.RenameColumn(
                name: "NFEFinality",
                table: "configs",
                newName: "NFeFinality");

            migrationBuilder.RenameColumn(
                name: "NFEModeEnabled",
                table: "configs",
                newName: "NFeEnabled");

            migrationBuilder.RenameColumn(
                name: "NFEDestination",
                table: "configs",
                newName: "NFeDestinationEmail");

            migrationBuilder.AddColumn<int>(
                name: "NFeEnvironment",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NFeModel",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NFeVersionDF",
                table: "configs",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NFeEnvironment",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFeModel",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "NFeVersionDF",
                table: "configs");

            migrationBuilder.RenameColumn(
                name: "NFeXmlPath",
                table: "configs",
                newName: "NFEXMLPath");

            migrationBuilder.RenameColumn(
                name: "NFeSerial",
                table: "configs",
                newName: "NFESerial");

            migrationBuilder.RenameColumn(
                name: "NFeSavePDF",
                table: "configs",
                newName: "NFESavePDF");

            migrationBuilder.RenameColumn(
                name: "NFePrint",
                table: "configs",
                newName: "NFEPrint");

            migrationBuilder.RenameColumn(
                name: "NFePresenceIndicator",
                table: "configs",
                newName: "NFEPresenceIndicator");

            migrationBuilder.RenameColumn(
                name: "NFePaymentForm",
                table: "configs",
                newName: "NFEPaymentForm");

            migrationBuilder.RenameColumn(
                name: "NFeInitialNumber",
                table: "configs",
                newName: "NFEInitialNumber");

            migrationBuilder.RenameColumn(
                name: "NFeFinality",
                table: "configs",
                newName: "NFEFinality");

            migrationBuilder.RenameColumn(
                name: "NFeEnabled",
                table: "configs",
                newName: "NFEModeEnabled");

            migrationBuilder.RenameColumn(
                name: "NFeDestinationEmail",
                table: "configs",
                newName: "NFEDestination");
        }
    }
}
