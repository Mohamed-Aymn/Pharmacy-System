namespace ManagementService.Models;

public class Branch
{
  public Branch(string name, string phoneNumber, string address)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Address = address;
  }

  public string Name { get; set; }
  public string Address { get; set; }
  public string PhoneNumber { get; set; }
}
