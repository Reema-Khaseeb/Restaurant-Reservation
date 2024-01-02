using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeWithRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW EmployeeWithRestaurantDetails AS
            SELECT
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.Position,
                r.RestaurantId,
                r.RestaurantName,
                r.Address,
                r.PhoneNumber
            FROM Employees e
            INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;
        ");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeWithRestaurantDetails");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 874, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 874, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 874, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 874, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 874, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 873, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 873, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 873, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 873, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 23, 27, 7, 873, DateTimeKind.Local).AddTicks(6951));
        }
    }
}
