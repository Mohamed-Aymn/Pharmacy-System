namespace ManagementService.Models;

public class Company
{
  public Company(string name, string phoneNumber, string email, int[] paymentShares)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    Email = email;
    PaymentShares = paymentShares;
  }

  public string Name { get; set; }
  public string PhoneNumber { get; set; }
  public string Email { get; set; }
  public int[] PaymentShares { get; set; }
}
