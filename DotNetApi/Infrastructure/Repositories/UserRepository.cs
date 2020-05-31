using DotNetApi.Domain.Entities;
using DotNetApi.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetApi.Infrastructure.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        // docker run -d -p 27017:27017 -p 28017:28017 --name mongodb -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=secret mongo
        private readonly IMongoClient _client = new MongoClient("mongodb://mongoadmin:secret@localhost:27017/?authSource=admin&readPreference=primary&appname=DotNetApi&ssl=false");
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<User> _collection;

        public UserRepository()
        {
            _db = _client.GetDatabase("DotNetApi");
            _collection = _db.GetCollection<User>("User");
        }

        public async Task AddAsync(User user) => await _collection.InsertOneAsync(user);

        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var result = await _collection.FindAsync(new BsonDocument());
            return result.ToEnumerable();
        }

        public async Task<User> GetAsync(ObjectId id)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user) => await _collection.ReplaceOneAsync(obj => obj.Id == user.Id, user);
    }
}
