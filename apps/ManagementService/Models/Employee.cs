using ManagementService.Types;

namespace ManagementService.Models;

public class Employee
{
  public Employee(string name, string phoneNumber, string email, EmployeeRole role, string branchName)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Email = email;
    Role = role;
    BranchName = branchName;
  }

  public string Name { get; set; }
  public string PhoneNumber { get; set; }
  public string Email { get; set; }
  public EmployeeRole Role { get; set; }
  public string BranchName { get; set; }
}
