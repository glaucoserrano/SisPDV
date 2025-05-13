using SisPDV.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Application.DTOs.Person
{
    public class PersonDTO
    {
        public int? Id { get; set; }

        // Identificação
        [Required(ErrorMessage = "O nome/razão social é obrigatório.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório.")]
        [MaxLength(14), MinLength(11)]
        public string CNPJ_CPF { get; set; } = string.Empty;

        [MaxLength(20)]
        public string IE { get; set; } = string.Empty;

        public IEIndicator IEIndicator { get; set; } = IEIndicator.ContribuinteICMS;

        [MaxLength(20)]
        public string IM { get; set; } = string.Empty;

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

        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Country { get; set; } = "Brasil";

        [MaxLength(4)]
        public string CountryCode { get; set; } = "1058";

        public int CityCode { get; set; }

        public PersonType PersonType { get; set; }

        // Finalidade
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCarrier { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
