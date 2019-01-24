using System.Threading.Tasks;

namespace Api.Abstractions
{
    public interface IShortenerService
    {
        Task<string> Create(string origin);

        Task<string> Obtain(string value);

        Task<int> GetClicks(string value);
    }
}
