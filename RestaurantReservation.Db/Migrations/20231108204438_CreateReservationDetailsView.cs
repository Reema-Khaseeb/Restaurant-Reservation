using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW ReservationDetailsView AS
                SELECT
                    r.ReservationId,
                    r.ReservationDate,
                    r.PartySize,
                    r.CustomerId,
                    c.FirstName,
                    c.LastName,
                    c.Email,
                    c.PhoneNumber,
                    r.RestaurantId,
                    rest.RestaurantName,
                    rest.Address
                FROM Reservations r
                INNER JOIN Customers c ON r.CustomerId = c.CustomerId
                INNER JOIN Restaurants rest ON r.RestaurantId = rest.RestaurantId;
            ");

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
                value: new DateTime(2023, 11, 8, 22, 44, 38, 132, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 132, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 132, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 132, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 132, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 131, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 131, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 131, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 131, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 44, 38, 131, DateTimeKind.Local).AddTicks(5393));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetailsView;");
            migrationBuilder.Sql("DROP VIEW EmployeeWithRestaurantDetails");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 8, 22, 43, 30, 630, DateTimeKind.Local).AddTicks(3230));
        }
    }
}
