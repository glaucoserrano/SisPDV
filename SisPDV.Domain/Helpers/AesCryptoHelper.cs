using System.Security.Cryptography;
using System.Text;

namespace SisPDV.Domain.Helpers
{
    public class AesCryptoHelper
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public AesCryptoHelper(string keyBase64, string ivBase64)
        {
            _key = Convert.FromBase64String(keyBase64);
            _iv = Convert.FromBase64String(ivBase64);
        }

        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var encryptor = aes.CreateEncryptor();
            var inputBytes = Encoding.UTF8.GetBytes(plainText);
            var encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var decryptor = aes.CreateDecryptor();
            var inputBytes = Convert.FromBase64String(encryptedText);
            var decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        // Utilitário para gerar Key e IV aleatórios em Base64
        public static (string Key, string IV) GenerateKeyAndIV()
        {
            using var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();
            return (
                Convert.ToBase64String(aes.Key),
                Convert.ToBase64String(aes.IV)
            );
        }
    }
}
