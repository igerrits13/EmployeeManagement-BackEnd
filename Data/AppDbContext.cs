using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
  public class AppDbContext : DbContext
  {
    // ctor + tab
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      
    }
  }
}