using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
  // Create the route - https://localhost:5201/api/books
  [Route("api/[controller]")]

  // Server side error checking
  [ApiController]

  public class EmployeeController : ControllerBase
  {
    private readonly IEmployeeRepository _employeeRepository;

    // ctor + tab, get data via dependency injection
    public EmployeeController(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }

    // Add a new employee using the repository functions
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
      await _employeeRepository.AddEmployeeAsync(employee);
      return Created();
    }
  }
}