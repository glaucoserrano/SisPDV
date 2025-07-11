using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IStockMovementService
    {
        Task<ValidationResults> ValidateAsync(StockMovementDTO request);
        Task SaveAsync(StockMovementDTO request);
        Task<List<StockMovementDTO>> SearchAsync(string search);
    }
}
