using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IProductService
    {
        Task<ValidationResults> ValidateAsync(ProductDTO request);
        Task SaveAsync(ProductDTO request);
        Task <ProductDTO?> GetBySearchTermAsync(string  searchTerm);
        Task<List<ProductDTO>> SearchAsync(SearchFilterProductsDTO filter);
        Task<List<ProductStockSearchDTO>> GetProductsForStockAsync();
        Task<ProductDTO> GetByIdAsync(int id);
    }
}
