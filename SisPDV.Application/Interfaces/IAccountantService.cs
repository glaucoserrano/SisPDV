using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IAccountantService
    {
        Task<List<AccountantDTO>> GetAccountantAsync();
        Task<ValidationResults> ValidateAsync(AccountantDTO request);
        Task SaveAsync(AccountantDTO request);
        Task<List<AccountantDTO>> SearchAsync(string search, int statusFilter);
        Task<AccountantDTO?> GetByIdAsync(int id);
        Task<List<AccountantDTO>> GetAccountantActiveAsync();
    }
}
