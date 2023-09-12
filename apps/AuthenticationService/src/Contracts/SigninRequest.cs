namespace AuthenticationService.Contracts;

public class SigninRequest
{
    public string Email { set; get; }
    public string Password { set; get; }

    public SigninRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}