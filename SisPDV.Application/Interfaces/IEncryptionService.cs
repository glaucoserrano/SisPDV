namespace SisPDV.Application.Interfaces
{
    public interface IEncryptionService
    {
        Task<string> EncryptAsync(string plainText);
        Task<string> DecryptAsync(string encryptedText);
    }
}
