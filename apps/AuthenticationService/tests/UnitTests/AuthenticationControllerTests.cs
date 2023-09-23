using AuthenticationService.Contracts;
using AuthenticationService.Controllers;
using AuthenticationService.Models;
using AuthenticationService.Presistence;
using AuthenticationService.UnitTests.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace UnitTests;

public class AuthenticationControllerTests
{
    private readonly Mock<IUserRepository> _userRepository;

    public AuthenticationControllerTests()
    {
        _userRepository = new Mock<IUserRepository>();
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
        _userRepository.Setup(x => x.Add(user))
            .Returns(Task.FromResult(user));
        // pass required parameters to the authentication controller
        AuthenticationController authenticationController = new(_userRepository.Object);
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

    [Fact]
    public async Task AuthenticationController_Signin_ShouldReturnOkAsync()
    {
        /**
         * 
         * arragne
         * 
         * */
        // this should be mongodb resopnse
        User user = GetUserData();
        // configure mongodb service function response
        _userRepository.Setup(x => x.GetByEmail(user.Email))
            .Returns(Task.FromResult(user));
        // pass required parameters to the authentication controller
        AuthenticationController authenticationController = new(_userRepository.Object);
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
        SigninRequest requestBody = new(
            email: UserConstants.Email,
            password: UserConstants.Password
        );
        var response = await authenticationController.Signin(requestBody);

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
            password: UserConstants.HasedPassword
        );
        return user;
    }
}