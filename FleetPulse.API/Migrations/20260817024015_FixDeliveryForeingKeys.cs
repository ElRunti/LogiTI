using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetPulse.API.Migrations
{
    /// <inheritdoc />
    public partial class FixDeliveryForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Customers_CustomerIdCustomer",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Drivers_DriverId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Deliveries_DeliveryIdDelivery",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_DeliveryIdDelivery",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_CustomerIdCustomer",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DriverId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DeliveryIdDelivery",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CustomerIdCustomer",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Deliveries");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_IdCustomer",
                table: "Deliveries",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_IdDriver",
                table: "Deliveries",
                column: "IdDriver");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_IdPackage",
                table: "Deliveries",
                column: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Customers_IdCustomer",
                table: "Deliveries",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Drivers_IdDriver",
                table: "Deliveries",
                column: "IdDriver",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Packages_IdPackage",
                table: "Deliveries",
                column: "IdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Customers_IdCustomer",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Drivers_IdDriver",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Packages_IdPackage",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_IdCustomer",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_IdDriver",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_IdPackage",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryIdDelivery",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdCustomer",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DeliveryIdDelivery",
                table: "Packages",
                column: "DeliveryIdDelivery");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_CustomerIdCustomer",
                table: "Deliveries",
                column: "CustomerIdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DriverId",
                table: "Deliveries",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Customers_CustomerIdCustomer",
                table: "Deliveries",
                column: "CustomerIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Drivers_DriverId",
                table: "Deliveries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Deliveries_DeliveryIdDelivery",
                table: "Packages",
                column: "DeliveryIdDelivery",
                principalTable: "Deliveries",
                principalColumn: "IdDelivery");
        }
    }
}
