using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class EmployeeWithRestaurantDetailsService
    {
        private readonly EmployeeWithRestaurantDetailsRepository _employeeWithRestaurantDetailsRepository;

        public EmployeeWithRestaurantDetailsService(EmployeeWithRestaurantDetailsRepository employeeWithRestaurantDetailsRepository)
        {
            _employeeWithRestaurantDetailsRepository = employeeWithRestaurantDetailsRepository;
        }

        public async Task<IEnumerable<EmployeeWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync()
        {
            return await _employeeWithRestaurantDetailsRepository.GetEmployeesWithRestaurantDetailsAsync();
        }
    }
}
