using AuthenticationService.Utilities;

namespace UnitTests;

public class PasswordHashingTests
{

    // PasswordHasher is a static class, it can't be mocked, I may fix this later
    // by creating an interface and register it in program.cs file then make
    //  PasswordHashercode rely on.

    // PasswordHasher class can be used here safly as it doesn't have dependencies
    // and it interact with any component in the application compoenents.

    [Fact]
    public void UserRegisteration_PasswordHashing_ShouldBeValid()
    {
        // arange
        string password = "1234567";

        // act
        string hash = PasswordHasher.HashPassword(password);
        bool isValid = PasswordHasher.ValidatePassword(password, hash);

        // assert
        Assert.True(isValid, "should be true (valid password)");
    }


    [Fact]
    public void UserRegisteration_PasswordHashing_ShouldBeNotValid()
    {
        // arange
        string password = "1234567";
        string UserEntry = "123456789";

        // act
        string hash = PasswordHasher.HashPassword(password);
        bool isValid = PasswordHasher.ValidatePassword(UserEntry, hash);

        // assert
        Assert.False(isValid, "should be false (not valid password)");
    }


    [Fact]
    public void UserRegisteration_ComplexPasswordHashing_ShouldBeValid()
    {
        // arange
        string password = "M4*/%!m|";

        // act
        string hash = PasswordHasher.HashPassword(password);
        bool isValid = PasswordHasher.ValidatePassword(password, hash);

        // assert
        Assert.True(isValid, "should be true (valid password)");
    }
}