using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetPulse.API.Migrations
{
    /// <inheritdoc />
    public partial class FixPackageForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_CustomerIdCustomer",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Drivers_DriverId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CustomerIdCustomer",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CustomerIdCustomer",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Packages",
                newName: "IdCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_DriverId",
                table: "Packages",
                newName: "IX_Packages_IdCustomer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickupTime",
                table: "Packages",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Packages",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Drivers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Drivers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Deliveries",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Deliveries",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_IdDriver",
                table: "Packages",
                column: "IdDriver");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_IdCustomer",
                table: "Packages",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Drivers_IdDriver",
                table: "Packages",
                column: "IdDriver",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_IdCustomer",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Drivers_IdDriver",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_IdDriver",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Packages",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_IdCustomer",
                table: "Packages",
                newName: "IX_Packages_DriverId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickupTime",
                table: "Packages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Packages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdCustomer",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Drivers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Drivers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Deliveries",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Deliveries",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CustomerIdCustomer",
                table: "Packages",
                column: "CustomerIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_CustomerIdCustomer",
                table: "Packages",
                column: "CustomerIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Drivers_DriverId",
                table: "Packages",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
