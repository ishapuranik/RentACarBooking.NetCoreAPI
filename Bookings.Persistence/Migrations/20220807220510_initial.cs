using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookings.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Renter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPassengerSeats = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeID = table.Column<int>(type: "int", nullable: false),
                    StandardPerDayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PeakPerDayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FleetQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    RenterID = table.Column<int>(type: "int", nullable: false),
                    RenterStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RenterEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingStatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_BookingStatus_BookingStatusID",
                        column: x => x.BookingStatusID,
                        principalTable: "BookingStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Renter_RenterID",
                        column: x => x.RenterID,
                        principalTable: "Renter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookingStatus",
                columns: new[] { "ID", "Status" },
                values: new object[,]
                {
                    { 1, "Reserved" },
                    { 2, "Confirmed" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { 1, "Hatchback" },
                    { 2, "SUV" },
                    { 3, "4 -Wheel Drive" },
                    { 4, "Minivan" },
                    { 5, "Convertible" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "ID", "FleetQuantity", "Make", "Model", "NumberOfPassengerSeats", "PeakPerDayRate", "StandardPerDayRate", "VehicleTypeID" },
                values: new object[,]
                {
                    { 1, 5, "Fiat", "500", 40, 145.7m, 130.88m, 1 },
                    { 2, 2, "Vauxhall", "Crossland", 4, 180.30m, 165.30m, 2 },
                    { 3, 2, "Range Rover", "Evoque", 4, 275.50m, 250.00m, 3 },
                    { 4, 1, "Mercedes-Benz", "E300 Cabriolet", 3, 300.65m, 270.22m, 5 },
                    { 5, 2, "Mercedes-Benz", "V220d Sport MPV", 7, 410.05m, 362.30m, 4 },
                    { 6, 3, "Range Rover", "Velar D300 R", 4, 380.00m, 350.99m, 3 },
                    { 7, 3, "Citroen", "Grand Picasso", 6, 380.00m, 345.17m, 4 },
                    { 8, 3, "Volkswagen", "Golf", 4, 200.12m, 180.04m, 1 },
                    { 9, 3, "Mercedes-Benz", "A Class", 4, 282.99m, 270.31m, 1 },
                    { 10, 2, "Skoda", "Octavia", 4, 283.12m, 272.42m, 1 },
                    { 11, 1, "MG", "ZS Auto", 4, 250.81m, 245.72m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingStatusID",
                table: "Booking",
                column: "BookingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RenterID",
                table: "Booking",
                column: "RenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VehicleID",
                table: "Booking",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeID",
                table: "Vehicle",
                column: "VehicleTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "Renter");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
