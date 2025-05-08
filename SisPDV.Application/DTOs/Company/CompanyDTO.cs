using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Company
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? FantasyName { get; set; } = string.Empty;
        public string? CNPJ { get; set; } = string.Empty;
        public string? IE { get; set; } = string.Empty;
        public string? IM { get; set; } = string.Empty;
        public string? UF { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public int CityCode { get; set; }
        public string? CEP { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string? Number { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public TaxRegime TaxRegime { get; set; }
    }
}
