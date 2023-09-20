
using System.Net;
using System.Net.Http.Json;
using AuthenticationService.Contracts;
using AuthenticationService.IntegrationTests.Constants;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationsTests;

public class AuthenticationControllerTests : IClassFixture<Program>
{
    private readonly HttpClient _client;

    public AuthenticationControllerTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _client = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task AuthenticationController_GetCurrentUser_ReturnsUnAuthorized()
    {
        /**
         * 
         * arragne
         * 
         * */
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/auth/currentuser");

        /**
         * 
         * act
         * 
         * */
        var response = await _client.SendAsync(request);

        /**
         * 
         * assert
         * 
         * */
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task AuthenticationController_CreateUser_ReturnCookie()
    {
        /**
         * 
         * arragne
         * 
         * */
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/register")
        {
            Content = JsonContent.Create(
                new RegisterUserRequest(
                    email: UserConstants.Email,
                    password: UserConstants.Password,
                    name: UserConstants.Name
                )
            )
        };

        /**
         * 
         * act
         * 
         * */
        var response = await _client.SendAsync(request);

        /**
         * 
         * assert
         * 
         * */
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // cookie check
    }
}