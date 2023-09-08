namespace AuthenticationService.Models;

public class User
{
    public int Id { get; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Email { get; }
}