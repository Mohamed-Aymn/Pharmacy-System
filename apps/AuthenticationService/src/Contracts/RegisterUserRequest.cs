namespace AuthenticationService.Contracts;

public class RegisterUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public RegisterUserRequest(string password, string email, string name)
    {
        Password = password;
        Email = email;
        Name = name;
    }
}