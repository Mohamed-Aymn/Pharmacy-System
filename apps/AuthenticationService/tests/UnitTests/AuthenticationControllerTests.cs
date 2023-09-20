using System.Net;
using AuthenticationService.Contracts;
using AuthenticationService.Controllers;
using AuthenticationService.Models;
using AuthenticationService.Services;
using AuthenticationService.UnitTests.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        /**
         * 
         * arragne
         * 
         * */
        // this should be mongodb resopnse
        User user = GetUserData();
        // configure mongodb service function response
        _mongoDBService.Setup(x => x.CreateAsync(user))
            .Returns(Task.FromResult(user));
        // pass required parameters to the authentication controller
        AuthenticationController authenticationController = new(_mongoDBService.Object, _config.Object);

        // I have to mock http tokens because I will not be using http request
        // in this test funtcion
        var httpContext = new DefaultHttpContext();
        httpContext.Response.Cookies.Append("Token", "mock-token");
        authenticationController.ControllerContext = new ControllerContext()
        {
            HttpContext = httpContext
        };

        /**
         * 
         * act
         * 
         * */
        RegisterUserRequest requestBody = new(
            name: UserConstants.Name,
            email: UserConstants.Email,
            password: UserConstants.Password
        );
        var response = await authenticationController.Signup(requestBody);

        /**
         * 
         * assert
         * 
         * */
        Assert.Equal(200, (response as IStatusCodeActionResult)!.StatusCode);
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