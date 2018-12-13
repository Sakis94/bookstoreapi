using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class MongoRepository<T> where T : Entity
    {
        protected internal IMongoCollection<T> collection;

        public MongoRepository(IMongoDatabase db, string tableName)
        {
            collection = db.GetCollection<T>(tableName);
        }

        public T Add(T item)
        {
            collection.InsertOne(item);
            return item;
        }

        public List<T> Get(BsonDocument filters)
        {
            var query = collection.Find(filters).ToListAsync();
            return query.Result;
        }

        public void Dispose()
        {

        }
    }
}