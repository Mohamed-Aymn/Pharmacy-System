using System.Net;
using System.Net.Http.Json;
using AuthenticationService.Contracts;
using AuthenticationService.Models;
using AuthenticationService.Presistence;
using AuthenticationService.Tests.IntegrationTests.Constants;
using AuthenticationService.Tests.IntegrationTests.Fixtures;
using AuthenticationService.Utilities;

namespace AuthenticationService.Tests.IntegrationTests;

public class AuthenticationControllerTests
    : IClassFixture<IntegrationTestsWebAppFactoryFixture>, IClassFixture<DbFixture>
{
    private readonly MongoDbContext _dbFixture;
    public readonly HttpClient _clientFixture;

    public AuthenticationControllerTests(IntegrationTestsWebAppFactoryFixture ProgramFactory, DbFixture DbFactory)
    {
        _dbFixture = DbFactory.DbContext;
        _clientFixture = ProgramFactory.Client;
    }

    [Fact]
    public async Task AuthenticationController_Signout_ShouldDeleteCookie()
    {
        /**
         * 
         * arragne
         * 
         * */
        // create user and cookie
        User user = new(
            name: UserConstants.Name,
            email: UserConstants.Email,
            password: UserConstants.Password
        );
        var token = TokenGenerator.GenerateToken(user);

        var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/logout");
        request.Headers.Add("token", "token=" + token);

        /**
         * 
         * act
         * 
         * */
        HttpResponseMessage response = await _clientFixture.SendAsync(request);

        /**
         * 
         * assert
         * 
         * */
        // check token cookie existence
        Cookie tokenCookie = new();
        if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
        {
            var cookieContainer = new CookieContainer();
            foreach (var cookieValue in cookieValues)
            {
                cookieContainer.SetCookies(response.RequestMessage!.RequestUri!, cookieValue);
            }
            tokenCookie = cookieContainer.GetCookies(response.RequestMessage!.RequestUri!)["token"]!;
        }
        Assert.DoesNotContain("token=", tokenCookie.Value);
    }

    [Fact]
    public async Task AuthenticationController_RegisterUser_ShouldReturnUnauthorized()
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
        HttpResponseMessage response = await _clientFixture.SendAsync(request);

        /**
         * 
         * assert
         * 
         * */
        // ok status code check
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task AuthenticationController_RegisterUser_ShouldBeValid()
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
        HttpResponseMessage response = await _clientFixture.SendAsync(request);

        /**
         * 
         * assert
         * 
         * */
        // ok status code check
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // add user to db check
        UserRepository userRepository = new(_dbFixture);
        List<User> allUsers = await userRepository.GetAllAsync();
        Assert.NotNull(allUsers);

        // check token cookie existence
        Cookie tokenCookie = new();
        if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
        {
            var cookieContainer = new CookieContainer();
            foreach (var cookieValue in cookieValues)
            {
                cookieContainer.SetCookies(response.RequestMessage!.RequestUri!, cookieValue);
            }
            tokenCookie = cookieContainer.GetCookies(response.RequestMessage!.RequestUri!)["token"]!;
        }
        Assert.NotNull(tokenCookie);
    }
}