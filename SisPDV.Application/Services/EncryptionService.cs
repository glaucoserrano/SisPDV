using Microsoft.EntityFrameworkCore;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly PDVDbContext _context;

        public EncryptionService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<string> DecryptAsync(string encryptedText)
        {
            var settings = await _context.encryptionSettings.FirstAsync();
            var aes = new AesCryptoHelper(settings.Key, settings.IV);

            return aes.Decrypt(encryptedText);
        }

        public async Task<string> EncryptAsync(string plainText)
        {
            var settings = await _context.encryptionSettings.FirstAsync();
            var aes = new AesCryptoHelper(settings.Key, settings.IV);

            return aes.Encrypt(plainText);
        }
    }
}
