using System.Threading.Tasks;
using Api.Abstractions;

namespace Api.Services
{
    public class ShortenerService : IShortenerService
    {
        public async Task<string> Create(string origin)
        {
            return "short url";
        }

        public async Task<string> Obtain(string value)
        {
            return "original url";
        }

        public async Task<int> GetClicks(string value)
        {
            return 1;
        }
    }
}
