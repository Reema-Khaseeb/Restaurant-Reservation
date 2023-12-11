using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RenameEmployeesWithRestaurantDetailsViews2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("EXEC sp_rename 'EmployeeWithRestaurantDetails', 'EmployeeWithRestaurantDetailsView';");
            
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 919, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 919, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 919, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 919, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 919, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 918, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 918, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 918, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 918, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 21, 17, 918, DateTimeKind.Local).AddTicks(7555));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 11, 13, 12, 19, 569, DateTimeKind.Local).AddTicks(3228));
        }
    }
}
