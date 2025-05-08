using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class Company : AuditableEntity
    {
        //Cadastro empresa
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; } = string.Empty; //Razão Social

        [Required, MaxLength(100)]
        public string FantasyName { get; set; } = string.Empty; //Nome Fantasia

        [Required, MaxLength(14), MinLength(14)]
        public string CNPJ { get; set; } = string.Empty; //CNPJ

        [Required, MaxLength(20)]
        public string IE { get; set; } = string.Empty; //Inscrição Estadual

        [MaxLength(20)]
        public string IM { get; set; } = string.Empty; //Inscrição Municipal

        [Required,MaxLength(2)]
        public string UF { get; set; } = string.Empty; // UF

        [Required, MaxLength(60)]
        public string City { get; set; } = string.Empty; //Municipio (Cidade)

        [Required]
        public int CityCode { get; set; } //Código Cidade IBGE
        
        [Required, MaxLength(9)]
        public string CEP { get; set; } = string.Empty; // CEP

        [Required, MaxLength(100)]
        public string Street { get; set; } = string.Empty; //Logradouro

        [MaxLength(10)]
        public string Number { get; set; } = string.Empty; //Numero

        [MaxLength(50)]
        public string District { get; set; } = string.Empty; //Bairro

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty; //Telefone

        [MaxLength(100),EmailAddress]
        public string Email { get; set; } = string.Empty; // Email
        
        [Required]
        public TaxRegime TaxRegime { get; set; } //Regime Tributário
    }
}
