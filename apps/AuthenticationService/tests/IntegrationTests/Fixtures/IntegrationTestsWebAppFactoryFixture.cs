using AuthenticationService.Presistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.Tests.IntegrationTests.Fixtures;

public class IntegrationTestsWebAppFactoryFixture : IClassFixture<DbFixture>
{
    public readonly HttpClient Client;

    public IntegrationTestsWebAppFactoryFixture()
    {
        var webAppFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // replace IMongoDbContext that exists in program.cs file
                    services.AddScoped<IMongoDbContext>(provider =>
                    {
                        MongoDbContextSettings contextSettings = new(
                            "mongodb://root:example@localhost:27019",
                            $"test_db_{Guid.NewGuid()}");

                        return new MongoDbContext(contextSettings);
                    });
                });
            });

        Client = webAppFactory.CreateClient();
    }
}