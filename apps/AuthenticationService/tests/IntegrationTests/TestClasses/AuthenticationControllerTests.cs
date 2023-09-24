using System.Net;
using System.Net.Http.Json;
using AuthenticationService.Contracts;
using AuthenticationService.Models;
using AuthenticationService.Presistence;
using AuthenticationService.Tests.IntegrationTests.Constants;
using AuthenticationService.Tests.IntegrationTests.Fixtures;

namespace AuthenticationService.Tests.IntegrationTests.TestClasses;

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
        var response = await _clientFixture.SendAsync(request);

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
    }
}