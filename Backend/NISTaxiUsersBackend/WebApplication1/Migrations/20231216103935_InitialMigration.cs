using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelCombinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel1Id = table.Column<int>(type: "int", nullable: false),
                    Fuel2Id = table.Column<int>(type: "int", nullable: true),
                    LimitFirstFuel = table.Column<double>(type: "float", nullable: false),
                    LimitLastFuel = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelCombinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelCombinations_Fuels_Fuel1Id",
                        column: x => x.Fuel1Id,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelCombinations_Fuels_Fuel2Id",
                        column: x => x.Fuel2Id,
                        principalTable: "Fuels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxiCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    TaxiLicence = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NumberOfId = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DriverStatus = table.Column<int>(type: "int", nullable: false),
                    SMSNotification = table.Column<bool>(type: "bit", nullable: false),
                    EmailNotification = table.Column<bool>(type: "bit", nullable: false),
                    FuelCombinationId = table.Column<int>(type: "int", nullable: false),
                    AmountPouredFirst = table.Column<double>(type: "float", nullable: false),
                    AmountPouredSecond = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_FuelCombinations_FuelCombinationId",
                        column: x => x.FuelCombinationId,
                        principalTable: "FuelCombinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfTransaction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_FuelCombinationId",
                table: "Drivers",
                column: "FuelCombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelCombinations_Fuel1Id",
                table: "FuelCombinations",
                column: "Fuel1Id");

            migrationBuilder.CreateIndex(
                name: "IX_FuelCombinations_Fuel2Id",
                table: "FuelCombinations",
                column: "Fuel2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DriverId",
                table: "Transactions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FuelId",
                table: "Transactions",
                column: "FuelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "FuelCombinations");

            migrationBuilder.DropTable(
                name: "Fuels");
        }
    }
}
