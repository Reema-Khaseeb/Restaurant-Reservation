using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalRevenueToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalRevenue",
                table: "Restaurants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 793, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 793, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 793, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 793, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 793, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 792, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 792, DateTimeKind.Local).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 792, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 792, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 31, 41, 792, DateTimeKind.Local).AddTicks(6055));
        }
    }
}
