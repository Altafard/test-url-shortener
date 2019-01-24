namespace Api.Abstractions
{
    public interface IShortenerService
    {
        string Create(string origin);

        string Obtain(string value);

        int GetClicks(string value);
    }
}
