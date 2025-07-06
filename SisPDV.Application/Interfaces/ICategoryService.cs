using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCagoriesAsync();
        Task<ValidationResults> ValidateAsync(CategoryDTO request);
        Task SaveAsync(CategoryDTO request);
        Task<List<CategoryDTO>> SearchAsync(string search, int statusFilter);
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<List<CategoryDTO>> GetCategoriesActiveAsync();


    }
}
