using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IProductTypeService
    {
        Task<ValidationResults> ValidateAsync(ProductTypeDTO resquest);
        Task<List<ProductTypeDTO>> GetProductTypesAsync();

        Task<ProductTypeDTO> GetByIdAsync(int id);
        Task SaveAsync(ProductTypeDTO request);
    }
}
