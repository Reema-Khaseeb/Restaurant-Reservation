using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Services;
using RestaurantReservation.Db.Repositories;

using var context = new RestaurantReservationDbContext();

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
var customerService = new CustomerService(customerRepository);
var restaurantService = new RestaurantService(restaurantRepository);
var reservationService = new ReservationService(reservationRepository);
var orderItemService = new OrderItemService(orderItemRepository);
var orderService = new OrderService(orderRepository);
var tableService = new TableService(tableRepository);
var employeeService = new EmployeeService(employeeRepository);
var menuItemService = new MenuItemService(menuItemRepository);

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
await customerService.DeleteCustomerAsync(4);

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
