using AuthenticationService.Presistence;
using MongoDB.Driver;

namespace IntegrationTests.Fixtures;

public class DbFixture : IDisposable
{
    public MongoDbContext DbContext { get; }
    private readonly MongoDbContextSettings _dbContextSettings = new(
            "mongodb://root:example@localhost:27019",
            $"test_db_{Guid.NewGuid()}"
    );

    public DbFixture()
    {
        DbContext = new(_dbContextSettings);
    }

    public void Dispose()
    {
        var client = new MongoClient(_dbContextSettings.ConnectionString);
        client.DropDatabase(_dbContextSettings.DatabaseName);
    }
}