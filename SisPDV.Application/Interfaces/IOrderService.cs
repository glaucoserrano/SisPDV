using SisPDV.Application.DTOs.Order;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Domain.Entities;

namespace SisPDV.Application.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderDTO> CreateAsync(CreateOrderDTO request);
        Task<ValidationResults> ValidateAsync(AddOrderItemsDTO request);

        Task<AddOrderItemsDTO> AddItemsAsync(AddOrderItemsDTO request);
    }
}
