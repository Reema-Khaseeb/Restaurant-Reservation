using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

public class EmployeeService
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
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
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
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
}
