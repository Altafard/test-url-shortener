using Api.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Url
    {
        public Url(string original, long num, IEncoder encoder)
        {
            ShortUrl = encoder.Encode(num);
            LongUrl = original;
        }

        [BsonId]
        public string ShortUrl { get; set; }

        public string LongUrl { get; set; }

        public int ClicksCount { get; set; }
    }
}
