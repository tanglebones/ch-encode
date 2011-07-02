using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Encode
{
    public class HexEncoder : IEncode
    {
        // there are faster ways, but this is readable.
        // also, why didn't .Net include Convert.ToHexString ?!

        private static readonly string[] ByteToHex = new string[256];
        private static readonly IDictionary<string, byte> HexToByte = new Dictionary<string, byte>();

        static HexEncoder()
        {
            foreach (var i in Enumerable.Range(0, 256))
            {
                var hex = ((byte) i).ToString("X2");
                ByteToHex[i] = hex;
                HexToByte[hex] = (byte)i;
                HexToByte[hex.ToLowerInvariant()] = (byte)i;
            }
        }

        public string Encode(byte[] byteArray)
        {
            var sb = new StringBuilder(byteArray.Length*2);
            foreach (var b in byteArray)
                sb.Append(ByteToHex[b]);
            return sb.ToString();
        }

        public byte[] Decode(string encoded)
        {
            if ((encoded.Length & 1) != 0)
                throw new ArgumentException("encoded must have an even length.");
            var byteArray = new byte[encoded.Length/2];
            try
            {
                foreach (var i in Enumerable.Range(0, byteArray.Length))
                    byteArray[i] = HexToByte[encoded.Substring(i * 2, 2)];
            }
            catch
            {
                throw new ArgumentException("encoded isn't hex.");
            }
            return byteArray;
        }
    }
}