using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IProductStockService
    {

        Task<List<ProductStockDTO>> GetProductStockAsync();
        Task SaveAsync(ProductStockDTO request);
        Task<ValidationResults> ValidateAsync(ProductStockDTO request);
        Task<List<ProductStockDTO>> SearchAsync(string search);
        Task<ProductStockDTO> GetByProductIdAsync(int ProductId);
    }
}
