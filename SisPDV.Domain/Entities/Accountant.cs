using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;

namespace SisPDV.Domain.Entities
{
    public class Accountant : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Nome do Contador
        public string CPF { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string CRC { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? CEP { get; set; }
        public Status Status { get; set; } = Status.Active;
    }

}
