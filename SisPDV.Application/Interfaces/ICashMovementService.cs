using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface ICashMovementService
    {
        Task<List<CashMovementDTO>> GetTodayMovementsAsync(int id);
        Task SaveCashMovementAsync(CashMovementDTO request);
        Task<ValidationResults> ValidateAsync(CashMovementDTO request);
    }
}
