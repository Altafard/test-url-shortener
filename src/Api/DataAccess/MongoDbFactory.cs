using System;
using Api.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Api.DataAccess
{
    public class MongoDbFactory : IMongoDbFactory
    {
        private readonly IConfiguration _configuration;

        public MongoDbFactory(IConfiguration configuration) => _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public IMongoDatabase Create()
        {
            var client = new MongoClient(_configuration.GetConnectionString("MongoDB"));
            return client.GetDatabase(_configuration.GetValue<string>("DatabaseName"));
        }
    }
}
