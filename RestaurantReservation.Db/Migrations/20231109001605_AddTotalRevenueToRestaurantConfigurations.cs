using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalRevenueToRestaurantConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRevenue",
                table: "Restaurants",
                type: "DECIMAL(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 357, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 357, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 357, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 357, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 357, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 356, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 356, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 356, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 356, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 16, 5, 356, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "TotalRevenue",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2,
                column: "TotalRevenue",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3,
                column: "TotalRevenue",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4,
                column: "TotalRevenue",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5,
                column: "TotalRevenue",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRevenue",
                table: "Restaurants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 422, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 422, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 422, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 422, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 422, DateTimeKind.Local).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 421, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 421, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 421, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 421, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 9, 2, 6, 28, 421, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "TotalRevenue",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2,
                column: "TotalRevenue",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3,
                column: "TotalRevenue",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4,
                column: "TotalRevenue",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5,
                column: "TotalRevenue",
                value: 0m);
        }
    }
}
