using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly AppDbContext _context;

    // ctor + tab
    public EmployeeRepository(AppDbContext context)
    {
      _context = context;
    }

    // Add employee to the existing database
    public async Task AddEmployeeAsync(Employee employee)
    {
      await _context.Employees.AddAsync(employee);
      await _context.SaveChangesAsync();
    }

    // Remove an existing employee from the database
    public async Task DeleteEmployeeAsync(int id)
    {
      var employeeInDb = await _context.Employees.FindAsync(id);

      // Ensure the employee exists
      if (employeeInDb == null)
      {
        throw new KeyNotFoundException($"Employee with id {id} not found.");
      }

      _context.Employees.Remove(employeeInDb);
      await _context.SaveChangesAsync();
    }

    // Return all existing employees in database
    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
      return await _context.Employees.ToListAsync();
    }

    // Return a specified employee in database, allowing for possible null (?) response
    public async Task<Employee?> GetByIdAsync(int id)
    {
      return await _context.Employees.FindAsync(id);
    }

    // Update an existing employee in database
    public async Task UpdateEmployeeAsync(Employee employee)
    {
      _context.Employees.Update(employee);
      await _context.SaveChangesAsync();
    }
  }
}