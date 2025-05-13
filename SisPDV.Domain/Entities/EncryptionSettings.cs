using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class EncryptionSettings
    {
        public int Id { get; set; }

        [Required]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string IV { get; set; } = string.Empty;
    }
}
