using EmployeeManagement.Data;
using EmployeeManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace EmployeeManagement
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add database context
      builder.Services.AddDbContext<AppDbContext>(
        options => options.UseInMemoryDatabase("EmployeeDb")
      );

      // Configure CORS policy
      builder.Services.AddCors(options =>
      {
        options.AddPolicy("MyCors", builder =>
        {
          builder.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod();
        });
      });

      // Add the repository to the dependency injection
      builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

      // Add controllers
      builder.Services.AddControllers();

      var app = builder.Build();

      // Apply the CORS configuration
      app.UseCors("MyCors");

      app.MapGet("/", () => "Hello World!");

      app.Run();
    }
  }
}
