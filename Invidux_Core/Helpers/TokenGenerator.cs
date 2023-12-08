using System.Security.Cryptography;
using System.Text;

namespace Invidux_Core.Helpers
{
    public class TokenGenerator
    {
        public static int GetUniqueKey(int maxSize)
        {
            char[] chars = "123456789".ToCharArray();
            byte[] data = new byte[maxSize];

            // Generates cryptographically strong random numbers
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);

            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return Int32.Parse(result.ToString());
        }
    }
}
