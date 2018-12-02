using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

using Models;

namespace Services
{

    public class DBService
    {
        private IMongoClient _provider;
        private IMongoDatabase _db;

        public MongoRepository<User> Users { get; private set; }

        public DBService(string connectionString, string dbname)
        {
            _provider = new MongoClient(connectionString);
            _db = _provider.GetDatabase(dbname, null);
            Users = new MongoRepository<User>(_db, "Users");
        }


    }
}