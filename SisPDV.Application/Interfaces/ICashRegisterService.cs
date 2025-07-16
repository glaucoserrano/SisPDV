using SisPDV.Application.DTOs.Cash;

namespace SisPDV.Application.Interfaces
{
    public interface ICashRegisterService
    {
        Task<CashRegisterDTO?> CanOpenCashRegisterAsync(int cashNumber);
        Task<CashRegisterDTO?> GetTodayCashOpeningAsync(int cashNumber);
        Task<CashRegisterDTO> OpenCashRegisterAsync(int cashNumber, decimal openingAmount, string origin);
        Task<CashRegisterDTO> CloseCashRegisterAsync(CashMovementDTO request);
    }
}
