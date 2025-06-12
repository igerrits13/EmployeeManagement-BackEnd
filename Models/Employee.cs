using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
  // Create the book model for API information
  public class Employee
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number required")]
    [Length(10, 10)]
    public string Phone { get; set; }
    public string Position { get; set; }

  }
}