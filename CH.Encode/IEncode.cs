namespace CH.Encode
{
    public interface IEncode
    {
        string Encode(byte[] byteArray);
        byte[] Decode(string encoded);
    }
}