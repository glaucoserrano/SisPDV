using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class Person : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        // Identificação
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty; // Razão Social / Nome

        [Required, MaxLength(14), MinLength(11)]
        public string CNPJ_CPF { get; set; } = string.Empty; // CPF (11) ou CNPJ (14)

        [MaxLength(20)]
        public string IE { get; set; } = string.Empty; // Inscrição Estadual

        [Required]
        public IEIndicator IEIndicator { get; set; } = IEIndicator.ContribuinteICMS;

        [MaxLength(20)]
        public string IM { get; set; } = string.Empty; // Inscrição Municipal

        [MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        // Endereço
        [MaxLength(9)]
        public string ZipCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Street { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Number { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Complement { get; set; } = string.Empty;

        [MaxLength(50)]
        public string District { get; set; } = string.Empty;

        [MaxLength(60)]
        public string City { get; set; } = string.Empty;

        [Required]
        public int CityCode { get; set; } // Código IBGE

        [Required, MaxLength(2)]
        public string State { get; set; } = string.Empty; // UF

        [Required, MaxLength(60)]
        public string Country { get; set; } = "Brasil";

        [Required, MaxLength(4)]
        public string CountryCode { get; set; } = "1058"; // Código Brasil (IBGE)

        // Tipo de pessoa
        [Required]
        public PersonType PersonType { get; set; }

        // Finalidade no sistema
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCarrier { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
