using SisPDV.Application.DTOs.Cash;

namespace SisPDV.Application.Interfaces
{
    public interface ICashRegisterService
    {
        Task<CashRegisterDTO?> CanOpenCashRegisterAsync(int cashNumber);
    }
}
