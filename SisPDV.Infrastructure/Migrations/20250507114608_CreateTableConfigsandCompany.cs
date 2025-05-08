using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SisPDV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableConfigsandCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    IE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IM = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    City = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CityCode = table.Column<int>(type: "integer", nullable: false),
                    CEP = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    District = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaxRegime = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "configs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DigitalCertificate = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordCertificate = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CertificateA1 = table.Column<bool>(type: "boolean", nullable: false),
                    VersionDF = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Model = table.Column<int>(type: "integer", nullable: false),
                    Serial = table.Column<int>(type: "integer", nullable: false),
                    InitialNumber = table.Column<int>(type: "integer", nullable: false),
                    Environment = table.Column<int>(type: "integer", nullable: false),
                    CSC = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CSCId = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Print = table.Column<bool>(type: "boolean", nullable: false),
                    TypeEmission = table.Column<int>(type: "integer", nullable: false),
                    XMLPath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UseStockControl = table.Column<bool>(type: "boolean", nullable: false),
                    SalesZeroStock = table.Column<bool>(type: "boolean", nullable: false),
                    OrderPrint = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "configs");
        }
    }
}
