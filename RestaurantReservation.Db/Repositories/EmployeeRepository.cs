using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> ListManagersAsync()
        {
            return await _context.Employees
                .Where(e => e.Position == "Manager")
                .ToListAsync();
        }
    }
}
