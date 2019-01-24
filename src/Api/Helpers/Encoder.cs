// ReSharper disable StringLiteralTypo

using System.Text;
using Api.Abstractions;
using Api.Extensions;

namespace Api.Helpers
{
    public class Encoder : IEncoder
    {
        private const string Set = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly int _base = Set.Length;

        public string Encode(int num)
        {
            if (num == 0)
            {
                return Set[0].ToString();
            }

            var sb = new StringBuilder();
            while (num > 0)
            {
                sb.Append(Set[num % _base]);
                num = num / _base;
            }

            return sb.ToString().Reverse();
        }

        public int Decode(string value)
        {
            var i = 0;
            foreach (char c in value)
            {
                i = i * _base + Set.IndexOf(c);
            }

            return i;
        }
    }
}
