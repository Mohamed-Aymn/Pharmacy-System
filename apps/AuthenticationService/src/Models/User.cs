using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthenticationService.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public User(string name, string password, string email)
    {
        Id = ObjectId.GenerateNewId();
        Name = name;
        Password = password;
        Email = email;
    }

    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}