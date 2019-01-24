using MongoDB.Driver;

namespace Api.Abstractions
{
    public interface IMongoDbFactory
    {
        IMongoDatabase Create();
    }
}
