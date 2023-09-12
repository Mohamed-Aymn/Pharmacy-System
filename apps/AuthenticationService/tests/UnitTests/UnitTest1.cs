using AuthenticationService.Models;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        User user = new(
            "asfd",
            "asdf",
            "asdf"
        );
    }
}