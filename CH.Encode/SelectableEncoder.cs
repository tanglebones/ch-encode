using System;

namespace CH.Encode
{
    // Base64 gets broken up by [+/=] when double clicking to select it. The replaces them with double character sequences
    // so double clicking selects all of the encoded data.
    public class SelectableEncoder : IEncode
    {
        public string Encode(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray)
                .Replace("Z", "Za")
                .Replace("+", "Zb")
                .Replace("/", "Zc")
                .Replace("=", "Zd");
        }

        public byte[] Decode(string encoded)
        {
            return Convert.FromBase64String(
                encoded
                    .Replace("Zd", "=")
                    .Replace("Zc", "/")
                    .Replace("Zb", "+")
                    .Replace("Za", "Z"));
        }
    }
}