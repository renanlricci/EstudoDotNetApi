using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApi.Infrastructure.Repositories
{
    public abstract class BaseMongoConnector<T>
    {
        // docker run -d -p 27017:27017 -p 28017:28017 --name mongodb -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=secret mongo
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _db;
        protected readonly IMongoCollection<T> _collection;

        protected BaseMongoConnector()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("");
            _collection = _db.GetCollection<T>(typeof(T).Name);
        }
    }
}
