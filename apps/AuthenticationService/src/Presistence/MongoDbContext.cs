using AuthenticationService.Models;
using MongoDB.Driver;

namespace AuthenticationService.Presistence
{
    public interface IMongoDbContext
    {
        IMongoCollection<User> UsersCollection { get; }
    }

    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoDbContextSettings contextSettings)
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(contextSettings.ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            MongoClient client = new MongoClient(settings);
            _database = client.GetDatabase(contextSettings.DatabaseName);
        }

        // db collections
        public IMongoCollection<User> UsersCollection => _database.GetCollection<User>("User");
    }
}