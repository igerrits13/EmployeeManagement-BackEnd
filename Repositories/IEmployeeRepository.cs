using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
  public interface IEmployeeRepository
  {
    // Use Task to make methods asyncronous
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int id);
  }
}