namespace ManagementService.Models;

public class Manager
{
  public Manager(string name, int phoneNumber, string email)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Email = email;
  }

  public string Name { get; set; }
  public int PhoneNumber { get; set; }
  public string Email { get; set; }
}
