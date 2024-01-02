using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartySize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "MenuItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, "alice.johnson@example.com", "Alice", "Johnson", "555-555-5555" },
                    { 4, "bob.brown@example.com", "Bob", "Brown", "111-222-3333" },
                    { 5, "eve.white@example.com", "Eve", "White", "999-888-7777" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "OpeningHours", "PhoneNumber", "RestaurantName" },
                values: new object[,]
                {
                    { 1, "123 Main St", "9:00 AM - 10:00 PM", "555-123-4567", "Restaurant A" },
                    { 2, "456 Elm St", "8:00 AM - 9:00 PM", "555-987-6543", "Restaurant B" },
                    { 3, "789 Oak St", "10:00 AM - 8:00 PM", "555-555-5555", "Restaurant C" },
                    { 4, "101 Pine St", "7:00 AM - 11:00 PM", "555-111-2222", "Restaurant D" },
                    { 5, "234 Cedar St", "11:00 AM - 9:00 PM", "555-999-8888", "Restaurant E" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Employee1", "Smith", "Server", 1 },
                    { 2, "Employee2", "Johnson", "Chef", 2 },
                    { 3, "Employee3", "Brown", "Server", 1 },
                    { 4, "Employee4", "White", "Manager", 3 },
                    { 5, "Employee5", "Green", "Server", 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "Description", "ItemName", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Delicious dish A", "Dish A", 12.99, 1 },
                    { 2, "Tasty dish B", "Dish B", 9.9900000000000002, 2 },
                    { 3, "Amazing dish C", "Dish C", 15.99, 1 },
                    { 4, "Special dish D", "Dish D", 10.99, 3 },
                    { 5, "Exquisite dish E", "Dish E", 14.99, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 1 },
                    { 4, 4, 3 },
                    { 5, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(3040), 1, 1 },
                    { 2, 2, 2, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(3075), 2, 2 },
                    { 3, 3, 6, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(3078), 1, 3 },
                    { 4, 4, 3, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(3080), 3, 4 },
                    { 5, 5, 5, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(3082), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(7957), 1, 50.0 },
                    { 2, 2, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(7968), 2, 30.0 },
                    { 3, 3, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(7970), 3, 75.0 },
                    { 4, 4, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(7972), 4, 40.0 },
                    { 5, 5, new DateTime(2023, 11, 8, 22, 40, 58, 539, DateTimeKind.Local).AddTicks(7974), 5, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 3 },
                    { 4, 4, 4, 1 },
                    { 5, 5, 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetailsView;");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
