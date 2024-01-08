namespace Invidux_Core.Helpers
{
    public class GenerateInternalRef
    {
        private static Random random = new Random();

        public static string TransactionRef()
        {
            string randomPart = GenerateRandomString(10);
            string timeStampPart = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            return $"TXN-{randomPart}-{timeStampPart}";
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }
}
