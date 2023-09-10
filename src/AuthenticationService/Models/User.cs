using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthenticationService.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public User()
    {
        Id = ObjectId.GenerateNewId();
    }

    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}