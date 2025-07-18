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

    // Get all employees using the repository functions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
    {
      return Ok(await _employeeRepository.GetAllAsync());
    }

    // Get a specified using the repository functions
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeById(int id)
    {
      var employee = await _employeeRepository.GetByIdAsync(id);

      // If not a valid id, return 404 not found
      if (employee == null)
      {
        return NotFound();
      }

      return Ok(employee);
    }

    // Add a new employee using the repository functions and return the created employee
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {

      if (ModelState.IsValid == false)
      {
        return BadRequest();
      }

      await _employeeRepository.AddEmployeeAsync(employee);
      return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    // Remove an emplyee by id using the repository functions
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployeeById(int id)
    {
      var employee = await _employeeRepository.GetByIdAsync(id);

      // If not a valid id, return bad request
      if (employee == null)
      {
        return BadRequest();
      }

      await _employeeRepository.DeleteEmployeeAsync(id);
      return NoContent();
    }

    // Update an employee by id using the repository functions
    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
    {
      // If not a valid id, return bad request
      if (id != employee.Id || ModelState.IsValid == false)
      {
        return BadRequest();
      }

      await _employeeRepository.UpdateEmployeeAsync(employee);
      return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
  }
}