using System;
using System.Threading.Tasks;
using Api.Abstractions;
using Api.Models;
using MongoDB.Driver;

namespace Api.Services
{
    public class ShortenerService : IShortenerService
    {
        private const string Urls = "urls";
        private const string Counters = "counters";

        private readonly IMongoDatabase _db;
        private readonly IEncoder _encoder;

        public ShortenerService(IMongoDbFactory mongoDbFactory, IEncoder encoder)
        {
            if (mongoDbFactory == null)
                throw new ArgumentNullException(nameof(mongoDbFactory));

            _db = mongoDbFactory.Create();
            _encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));
        }

        public async Task<string> Create(string original)
        {
            // TODO : check if url is exists in the collection already
            int seq = await IncrementSeq();
            var url = new Url(original, seq, _encoder);
            _db.GetCollection<Url>(Urls).InsertOne(url);
            return url.ShortUrl;
        }

        public async Task<string> Obtain(string value)
        {
            UpdateDefinition<Url> update = Builders<Url>.Update.Inc(url => url.ClicksCount, 1);
            Url result = await _db.GetCollection<Url>(Urls).FindOneAndUpdateAsync(url => url.ShortUrl.Equals(value), update);
            return result.LongUrl;
        }

        public Task<int> GetClicks(string value)
        {
            return _db.GetCollection<Url>(Urls)
                .Find(url => url.ShortUrl.Equals(value))
                .Project(url => url.ClicksCount)
                .SingleAsync();
        }

        private Task<int> IncrementSeq()
        {
            FilterDefinition<Counter> filter = Builders<Counter>.Filter.Eq(counter => counter.Key, Urls);
            UpdateDefinition<Counter> update = Builders<Counter>.Update.Inc(counter => counter.Seq, 1);
            ProjectionDefinition<Counter, int> projection = Builders<Counter>.Projection.Expression(counter => counter.Seq);

            return _db.GetCollection<Counter>(Counters)
                .FindOneAndUpdateAsync(filter, update,
                    new FindOneAndUpdateOptions<Counter, int>
                    {
                        IsUpsert = true,
                        Projection = projection
                    });
        }
    }
}
