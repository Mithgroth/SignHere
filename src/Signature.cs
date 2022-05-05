using SignHere.Database;

namespace SignHere
{
    public class Signature
    {
        public Extension Extension { get; set; }
        public byte[] MagicBytes { get; set; }
        public string Description { get; set; }
    }
}