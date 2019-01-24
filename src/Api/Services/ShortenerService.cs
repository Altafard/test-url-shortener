using Api.Abstractions;

namespace Api.Services
{
    public class ShortenerService : IShortenerService
    {
        public string Create(string origin)
        {
            return "short url";
        }

        public string Obtain(string value)
        {
            return "original url";
        }

        public int GetClicks(string value)
        {
            return 1;
        }
    }
}
