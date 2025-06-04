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

      // Add testing middleware
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // If in developer environment, show UI for testing
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
          c.RoutePrefix = string.Empty;
        });
      }

      // Apply the CORS configuration
      app.UseCors("MyCors");

      // Map controllers
      app.MapControllers();

      app.Run();
    }
  }
}
