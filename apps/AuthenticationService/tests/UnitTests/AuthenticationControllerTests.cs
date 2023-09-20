using System.Net;
using AuthenticationService.Contracts;
using AuthenticationService.Controllers;
using AuthenticationService.Models;
using AuthenticationService.Services;
using AuthenticationService.UnitTests.Constants;
using Microsoft.Extensions.Configuration;
using Moq;

namespace UnitTests;

public class AuthenticationControllerTests
{
    private readonly Mock<IMongoDBService> _mongoDBService;
    private readonly Mock<IConfiguration> _config;

    public AuthenticationControllerTests()
    {
        _mongoDBService = new Mock<IMongoDBService>();

        _config = new Mock<IConfiguration>();
        _config.SetupGet(x => x["Jwt:key"]).Returns("restaurant-system-jwt-authentication-key-for-dotnet-application");
        _config.SetupGet(x => x["Jwt:Audience"]).Returns("https://localhost:5069");
        _config.SetupGet(x => x["Jwt:Issuer"]).Returns("https://localhost:5069");
    }

    [Fact]
    public async Task AuthenticationController_SignUp_ShouldReturnOkAsync()
    {
        // arrange
        User user = GetUserData();
        _mongoDBService.Setup(x => x.CreateAsync(user))
            .Returns(Task.FromResult(user));
        var authenticationController = new AuthenticationController(_mongoDBService.Object, _config.Object);

        // act
        RegisterUserRequest requestBody = new(
            UserConstants.Password,
            UserConstants.Email,
            UserConstants.Name
        );
        var response = await authenticationController.Signup(requestBody) as HttpResponseMessage;

        // asert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private User GetUserData()
    {
        User user = new(
            name: UserConstants.Name,
            email: UserConstants.Email,
            password: UserConstants.Password
        );
        return user;
    }
}