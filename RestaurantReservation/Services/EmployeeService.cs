using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IObjectValidator _objectValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IObjectValidator objectValidator)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _objectValidator = objectValidator ?? throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            _objectValidator.ValidateObjectNotNull(employee);
            await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            _objectValidator.ValidatePositiveObjectId(employeeId);
            return await _employeeRepository.GetEmployeeAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _objectValidator.ValidateObjectNotNull(employee);
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeId);

            _objectValidator.ValidateObjectNotNull(employee);
            await _employeeRepository.DeleteEmployeeAsync(employee);
        }

        public async Task<IEnumerable<Employee>> ListManagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }

        public async Task<IEnumerable<EmployeeWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync()
        {
            return await _employeeRepository.GetEmployeesWithRestaurantDetailsAsync();
        }
    }
}
