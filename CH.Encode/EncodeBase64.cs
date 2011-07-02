using System;

namespace CH.Encode
{
    public class EncodeBase64 : IEncode
    {
        // .Net include a Base64 encoder, so we might as well use that.
        public string Encode(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }

        public byte[] Decode(string encoded)
        {
            return Convert.FromBase64String(encoded);
        }
    }
}