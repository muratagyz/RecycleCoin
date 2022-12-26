using System.Security.Cryptography;
using System.Text;

namespace RecycleCoin.UI.Utilities.Hashing
{
    public class HashingHelper
    {
        public static string SHA256Hash()
        {
            string text = Guid.NewGuid().ToString();
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }
    }
}