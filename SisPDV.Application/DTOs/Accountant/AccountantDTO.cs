namespace SisPDV.Application.DTOs.Accountant
{
    public class AccountantDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;           // Nome do contador
        public string CRC { get; set; } = string.Empty;            // CRC do contador (Conselho Regional de Contabilidade)
        public string CPF { get; set; } = string.Empty;            // CPF do contador
        public string CNPJ { get; set; } = string.Empty;           // CNPJ do escritório, se houver
        public string Email { get; set; } = string.Empty;          // Email de contato
        public string Phone { get; set; } = string.Empty;          // Telefone de contato

        public string Street { get; set; } = string.Empty;         // Logradouro
        public string Number { get; set; } = string.Empty;         // Número
        public string District { get; set; } = string.Empty;       // Bairro
        public string City { get; set; } = string.Empty;           // Cidade
        public string State { get; set; } = string.Empty;          // UF
        public string ZipCode { get; set; } = string.Empty;        // CEP

        public bool IsActive { get; set; } = true;                 // Status (ativo/inativo)
        public string? Notes { get; set; }                         // Campo de observações (opcional)
    }
}
