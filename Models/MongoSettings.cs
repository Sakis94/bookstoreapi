using System;
using Microsoft.Extensions.Configuration;

namespace Models
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}