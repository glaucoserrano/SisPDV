using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Domain.Entities;

namespace SisPDV.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDTO?> GetAsync();
        Task SaveAsync(CompanyDTO request);
        Task SaveCnpjHashAsync(string cnpj);
        Task<string?> GetCnpjHashAsync();
        Task<bool> ValidateHash(string? cnpj, string? hash);
        Task<ValidationResults> ValidateCompanyData(CompanyDTO request);
    }
}
