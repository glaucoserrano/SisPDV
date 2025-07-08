using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.DTOs.PaymentMethod;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethodDTO>> GetPaymentMethodAsync();
        Task<ValidationResults> ValidateAsync(PaymentMethodDTO request);
        Task SaveAsync(PaymentMethodDTO request);
        Task<List<PaymentMethodDTO>> SearchAsync(string search, int statusFilter);
        Task<PaymentMethodDTO?> GetByIdAsync(int id);
        Task<List<PaymentMethodDTO>> GetPaymentMethodActiveAsync();
    }
}
