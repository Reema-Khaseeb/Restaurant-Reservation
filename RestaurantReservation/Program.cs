using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Services;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;
using RestaurantReservation.Db.Repositories.Interfaces;

using var context = new RestaurantReservationDbContext();

var objectValidator = new ObjectValidator();

// Create repository instances
var customerRepository = new CustomerRepository(context);
var restaurantRepository = new RestaurantRepository(context);
var reservationRepository = new ReservationRepository(context);
var orderItemRepository = new OrderItemRepository(context);
var orderRepository = new OrderRepository(context);
var tableRepository = new TableRepository(context);
var employeeRepository = new EmployeeRepository(context);
var menuItemRepository = new MenuItemRepository(context);

// Create services for each entity
var customerService = new CustomerService(customerRepository, objectValidator);
var restaurantService = new RestaurantService(restaurantRepository, objectValidator);
var reservationService = new ReservationService(reservationRepository, objectValidator);
var orderItemService = new OrderItemService(orderItemRepository, objectValidator);
var orderService = new OrderService(orderRepository, objectValidator);
var tableService = new TableService(tableRepository, objectValidator);
var employeeService = new EmployeeService(employeeRepository, objectValidator);
var menuItemService = new MenuItemService(menuItemRepository, objectValidator);

// Create sample data
var customer = new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "123-456-7890" };
var restaurant = new Restaurant { RestaurantName = "Sample Restaurant", Address = "123 Main St", PhoneNumber = "987-654-3210", OpeningHours = "8:00 AM - 10:00 PM" };
var reservation = new Reservation { CustomerId = 3, TableId = 3, RestaurantId = 1, ReservationDate = DateTime.Now, PartySize = 4 };
var orderItem = new OrderItem { OrderId = 3, ItemId = 1, Quantity = 2 };
var order = new Order { ReservationId = 3, EmployeeId = 1, OrderDate = DateTime.Now, TotalAmount = 50.0 };
var table = new Table { RestaurantId = 3, Capacity = 4 };
var employee = new Employee { RestaurantId = 1, FirstName = "Jane", LastName = "Smith", Position = "Waiter" };
var menuItem = new MenuItem { RestaurantId = 1, ItemName = "Burger", Description = "Delicious burger", Price = 10.99 };

// CRUD operations
await customerService.CreateCustomerAsync(customer);
await restaurantService.CreateRestaurantAsync(restaurant);
await reservationService.CreateReservationAsync(reservation);
await orderItemService.CreateOrderItemAsync(orderItem);
await orderService.CreateOrderAsync(order);
await tableService.CreateTableAsync(table);
await employeeService.CreateEmployeeAsync(employee);
await menuItemService.CreateMenuItemAsync(menuItem);

// Retrieve and update data
var retrievedCustomer = await customerService.GetCustomerAsync(4);
if (retrievedCustomer != null)
{
    retrievedCustomer.FirstName = "UpdatedName";
    await customerService.UpdateCustomerAsync(retrievedCustomer);
}

// Delete data
await customerService.DeleteCustomerAsync(2);

// Retrieve and list all entities
var allCustomers = await customerService.GetAllCustomersAsync();
var allRestaurants = await restaurantService.GetAllRestaurantsAsync();
var allReservations = await reservationService.GetAllReservationsAsync();
var allOrderItems = await orderItemService.GetAllOrderItemsAsync();
var allOrders = await orderService.GetAllOrdersAsync();
var allTables = await tableService.GetAllTablesAsync();
var allEmployees = await employeeService.GetAllEmployeesAsync();
var allMenuItems = await menuItemService.GetAllMenuItemsAsync();

// Print Customers' data
foreach (var customerData in allCustomers)
{
    Console.WriteLine($"Customer ID: {customerData.CustomerId}");
    Console.WriteLine($"First Name: {customerData.FirstName}");
    Console.WriteLine($"Last Name: {customerData.LastName}");
    Console.WriteLine($"Email: {customerData.Email}");
    Console.WriteLine($"Phone Number: {customerData.PhoneNumber}");
    Console.WriteLine();
}

Console.WriteLine("List of Managers:");
var managers = await employeeService.ListManagersAsync();
foreach (var manager in managers)
{
    Console.WriteLine($"Manager ID: {manager.EmployeeId}, Name: {manager.FirstName} {manager.LastName}");
}

Console.WriteLine("\nReservations by Customer ID:");
var customerId = 3;
var customerReservations = await reservationService.GetReservationsByCustomerAsync(customerId);
foreach (var customerReservation in customerReservations)
{
    Console.WriteLine("\n\t- Reservation ID: " + customerReservation.ReservationId + ",");
    Console.WriteLine("\t- Date: " + customerReservation.ReservationDate + ",");
    Console.WriteLine("\t- PartySize: " + customerReservation.PartySize);
}

var employeeId = 1;
var averageAmount = await orderService.CalculateAverageOrderAmountAsync(employeeId);
Console.WriteLine($"\nAverage Order Amount for Employee ID {employeeId} = {averageAmount:C}\n\n");

var reservationId = 3;
var ordersAndMenuItems = await orderService.ListOrdersAndMenuItemsAsync(reservationId);
foreach (var orderAndMenuItem in ordersAndMenuItems)
{
    Console.WriteLine($"Order ID: {orderAndMenuItem.OrderId}");

    foreach (var orderItem_ in orderAndMenuItem.OrderItems)
    {
        var menuItem_ = orderItem_.MenuItem;
        Console.WriteLine($"  Item ID: {orderItem_.ItemId}, Name: {menuItem_.ItemName}, Price: {menuItem_.Price:C}");
        
    }
}

var orderedMenuItems = await orderService.ListOrderedMenuItemsAsync(reservationId);
Console.WriteLine($"Ordered Menu Items for Reservation ID {reservationId}:");
foreach (var menuItem_ in orderedMenuItems)
    Console.WriteLine($"  Item ID: {menuItem_.ItemId}, Name: {menuItem_.ItemName}, Price: {menuItem_.Price:C}");

Console.WriteLine("\n----------- Reservations with their associated Customer and Restaurant View -----------");
var reservationDetails = await reservationService.GetReservationDetailsViewAsync();
foreach (var reservationDetailsView in reservationDetails)
{
    Console.WriteLine($"Reservation ID: {reservationDetailsView.ReservationId}");
    Console.WriteLine($"Customer Name: {reservationDetailsView.FirstName} {reservationDetailsView.LastName}");
    Console.WriteLine($"Customer Email: {reservationDetailsView.Email}");
    Console.WriteLine($"Restaurant Name: {reservationDetailsView.RestaurantName}");
    Console.WriteLine($"Reservation Date: {reservationDetailsView.ReservationDate}");
    Console.WriteLine($"Party Size: {reservationDetailsView.PartySize}");
    Console.WriteLine();
}

Console.WriteLine("\n----------- Employee With Restaurant Details View -----------");
var employeeWithRestaurantDetailsView = await employeeService.GetEmployeesWithRestaurantDetailsAsync();
foreach (var employeeReservationDetails in employeeWithRestaurantDetailsView)
{
    Console.WriteLine($"Employee Name: {employeeReservationDetails.FirstName} {employeeReservationDetails.LastName}");
    Console.WriteLine($"Position: {employeeReservationDetails.Position}");
    Console.WriteLine($"Restaurant: {employeeReservationDetails.RestaurantName}");
    Console.WriteLine();
}

var restaurantId = 1;
decimal totalRevenue = await restaurantService.CalculateRestaurantTotalRevenueAsync(restaurantId);
Console.WriteLine($"Total Revenue for Restaurant ID {restaurantId}: {totalRevenue:C}");


var partySizeThreshold = 5;
Console.WriteLine($"\n\n----------- Customers With Reservation PartySize > {partySizeThreshold}: -----------"); 
var customersByReservationPartySize = await customerService.FindCustomersByReservationPartySizeAsync(partySizeThreshold);
foreach (var customerByReservationPartySize in customersByReservationPartySize)
{
    Console.WriteLine($"\t- Customer ID: {customerByReservationPartySize.CustomerId}, First Name: {customerByReservationPartySize.FirstName}");
}