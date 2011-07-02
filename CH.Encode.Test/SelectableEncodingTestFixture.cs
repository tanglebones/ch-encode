using NUnit.Framework;

namespace CH.Encode.Test
{
    [TestFixture]
    public class SelectableEncodingTestFixture
    {
        [Test]
        public void ShouldEncodeToExpected()
        {
            var encoder = new SelectableEncoder();
            var encoded = encoder.Encode(new byte[] {0, 255, 0, 255});
            Assert.AreEqual("AP8AZcwZdZd", encoded);
        }
        [Test]
        public void ShouldDecodeFromExpected()
        {
            var encoder = new SelectableEncoder();
            var encoded = "AP8AZcwZdZd";
            Assert.AreEqual(new byte[]{0,255,0,255}, encoder.Decode(encoded));
        }
    }
}