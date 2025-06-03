using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
  public class AppDbContext : DbContext
  {
    // Create a set to store data
    public DbSet<Employee> Employees { get; set; }

    // ctor + tab
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
  }
}