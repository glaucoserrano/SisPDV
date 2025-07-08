using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;

namespace SisPDV.Domain.Entities
{
    public class PaymentMethod : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty; // Ex: Visa Crédito
        public SefazPaymentCode SefazCode { get; set; } // Código conforme tabela do SEFAZ (ex: 01 - Dinheiro)
        public bool IsActive { get; set; } = true;
    }
}
