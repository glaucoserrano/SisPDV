using System.Security.Cryptography;
using System.Text;

namespace SisPDV.Domain.Helpers
{
    public class PasswordHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }

        public static bool Verify(string password, string oldPassword)
        {
            var hashofInput = ComputeSha256Hash(oldPassword);

            return hashofInput == password;
        }
    }
}
