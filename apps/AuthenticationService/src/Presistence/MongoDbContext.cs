using AuthenticationService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthenticationService.Presistence
{
    public interface IMongoDbContext
    {

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

            try
            {
                BsonDocument result = client.GetDatabase("RestaurantSystem").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // db collections
        public IMongoCollection<User> UsersCollection => _database.GetCollection<User>("User");
    }
}