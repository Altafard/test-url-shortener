namespace Api.Abstractions
{
    public interface IEncoder
    {
        string Encode(int num);

        int Decode(string value);
    }
}
