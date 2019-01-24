namespace Api.Abstractions
{
    public interface IEncoder
    {
        string Encode(long num);

        long Decode(string value);
    }
}
