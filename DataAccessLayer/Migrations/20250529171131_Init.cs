using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    CarType = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseYearMonth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnginePower = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelConsumption = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarNumber);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassportSeries = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    PassportNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LicenseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LicenseCategory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverNumber);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DriverNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CarNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => new { x.DepartureDate, x.DriverNumber, x.CarNumber });
                    table.ForeignKey(
                        name: "FK_Departures_Cars_CarNumber",
                        column: x => x.CarNumber,
                        principalTable: "Cars",
                        principalColumn: "CarNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departures_Drivers_DriverNumber",
                        column: x => x.DriverNumber,
                        principalTable: "Drivers",
                        principalColumn: "DriverNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departures_CarNumber",
                table: "Departures",
                column: "CarNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_DriverNumber",
                table: "Departures",
                column: "DriverNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PassportSeries_PassportNumber",
                table: "Drivers",
                columns: new[] { "PassportSeries", "PassportNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
