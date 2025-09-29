using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBPWebDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    No = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Mid = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ExchangeTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_ExchangeTables_ExchangeTableId",
                        column: x => x.ExchangeTableId,
                        principalTable: "ExchangeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_Code",
                table: "ExchangeRates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ExchangeTableId_Code",
                table: "ExchangeRates",
                columns: new[] { "ExchangeTableId", "Code" },
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTables_EffectiveDate",
                table: "ExchangeTables",
                column: "EffectiveDate");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTables_No",
                table: "ExchangeTables",
                column: "No",
                unique: true,
                filter: "[No] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "ExchangeTables");
        }
    }
}
