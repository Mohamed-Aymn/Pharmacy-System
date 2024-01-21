namespace ManagementService.Models;

public class Branch
{
  public Branch(string name, int phoneNumber, string address)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Address = address;
  }

  public string Name { get; set; }
  public string Address { get; set; }
  public int PhoneNumber { get; set; }
}
