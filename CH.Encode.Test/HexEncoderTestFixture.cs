using System;
using NUnit.Framework;

namespace CH.Encode.Test
{
    [TestFixture]
    public class HexEncoderTestFixture
    {
        [Test]
        public void ShouldThrowOnBadInputWhenDecoding()
        {
            var encoder = new HexEncoder();
            Assert.Throws(typeof (ArgumentException), () => encoder.Decode("odd"));
            Assert.Throws(typeof (ArgumentException), () => encoder.Decode("even"));
        }

        [Test]
        public void ShouldHandleUpperAndLowerCaseEncoded()
        {
            var encoder = new HexEncoder();
            Assert.AreEqual(new byte[] {0x33, 0xa4}, encoder.Decode("33a4"));
            Assert.AreEqual(new byte[] {0x33, 0xa4}, encoder.Decode("33A4"));
        }

        [Test]
        public void ShouldEncodeToUppercase()
        {
            var encoder = new HexEncoder();
            var encoded = encoder.Encode(new byte[] {0x66, 0xff, 0x00, 0x44});
            Assert.AreEqual("66FF0044", encoded);
        }
    }
}