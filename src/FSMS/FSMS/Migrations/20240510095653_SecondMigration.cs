using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMS.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Fuel");

            migrationBuilder.EnsureSchema(
                name: "Measures");

            migrationBuilder.CreateTable(
                name: "Dispensers",
                schema: "Fuel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispensers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                schema: "Fuel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sensors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitPrices",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nozzles",
                schema: "Fuel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    DispenserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nozzles_Dispensers_DispenserId",
                        column: x => x.DispenserId,
                        principalSchema: "Fuel",
                        principalTable: "Dispensers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DispenserTank",
                schema: "Fuel",
                columns: table => new
                {
                    DispensersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TanksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenserTank", x => new { x.DispensersId, x.TanksId });
                    table.ForeignKey(
                        name: "FK_DispenserTank_Dispensers_DispensersId",
                        column: x => x.DispensersId,
                        principalSchema: "Fuel",
                        principalTable: "Dispensers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DispenserTank_Tanks_TanksId",
                        column: x => x.TanksId,
                        principalSchema: "Fuel",
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                schema: "Measures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Tanks_TankId",
                        column: x => x.TankId,
                        principalSchema: "Fuel",
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Tanks_TankId",
                        column: x => x.TankId,
                        principalSchema: "Fuel",
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_UnitPrices_UnitPriceId",
                        column: x => x.UnitPriceId,
                        principalSchema: "Sales",
                        principalTable: "UnitPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NozzleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DispenserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Dispensers_DispenserId",
                        column: x => x.DispenserId,
                        principalSchema: "Fuel",
                        principalTable: "Dispensers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Nozzles_NozzleId",
                        column: x => x.NozzleId,
                        principalSchema: "Fuel",
                        principalTable: "Nozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_UnitPrices_UnitPriceId",
                        column: x => x.UnitPriceId,
                        principalSchema: "Sales",
                        principalTable: "UnitPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dates_UnitPriceId",
                schema: "Sales",
                table: "Dates",
                column: "UnitPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenserTank_TanksId",
                schema: "Fuel",
                table: "DispenserTank",
                column: "TanksId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_DispenserId",
                schema: "Fuel",
                table: "Nozzles",
                column: "DispenserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DispenserId",
                schema: "Sales",
                table: "Sales",
                column: "DispenserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_NozzleId",
                schema: "Sales",
                table: "Sales",
                column: "NozzleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UnitPriceId",
                schema: "Sales",
                table: "Sales",
                column: "UnitPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_TankId",
                schema: "Measures",
                table: "Sensors",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_States_TankId",
                schema: "Measures",
                table: "States",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dates",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "DispenserTank",
                schema: "Fuel");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Sensors",
                schema: "Measures");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Measures");

            migrationBuilder.DropTable(
                name: "Nozzles",
                schema: "Fuel");

            migrationBuilder.DropTable(
                name: "UnitPrices",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Tanks",
                schema: "Fuel");

            migrationBuilder.DropTable(
                name: "Dispensers",
                schema: "Fuel");
        }
    }
}
