using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNetApi.Domain.Entities
{
    public sealed class User
    {
        public User()
        {
        }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Username { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        public string Email { get; set; }
    }
}
