using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IProductService
    {
        Task<ValidationResults> ValidateAsync(ProductDTO request);
    }
}
