using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Order;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly PDVDbContext _context;

        public OrderService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<AddOrderItemsDTO> AddItemsAsync(AddOrderItemsDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = await _context.orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);

                if ((order == null))
                {
                    throw new InvalidOperationException("Pedido não encontrado");
                }

                var product = await _context.products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.ProductId);

                if(product == null || !product.Active)
                {
                    throw new InvalidOperationException("Produto inválido ou intivo");
                }

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    Discount = request.Discount,
                    Total = (request.UnitPrice * request.Quantity) - request.Discount,
                    Origin = request.Origin,
                };

                await _context.orderItems.AddAsync(orderItem);

                order.SubTotal += request.UnitPrice * request.Quantity;
                order.TotalAmount += orderItem.Total;
                order.DiscountAmount += orderItem.Discount;

                _context.orders.Update(order);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

                return new AddOrderItemsDTO
                {
                    OrderId = orderItem.OrderId,
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    UnitPrice = orderItem.UnitPrice,
                    Discount = orderItem.Discount,
                    Total = orderItem.Total,
                    DiscountTotal = order.DiscountAmount,
                    subTotal = order.SubTotal,
                    totalAmount = order.TotalAmount,
                    Notes = orderItem.Notes,
                    Origin = orderItem.Origin
                };
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public async Task<CreateOrderDTO> CreateAsync(CreateOrderDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    OrderNumber = request.OrderNumber,
                    CustomerId = request.CustomerId,
                    TableId = request.TableId,
                    CommandId = request.CommandId,
                    IsNFCe = request.IsNFCe,
                    Notes = request.Notes,
                    Origin = request.Origin,
                };

                await _context.orders.AddAsync(order);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

                return new CreateOrderDTO
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    CustomerId = order.CustomerId,
                    TableId = order.TableId,
                    CommandId = order.CommandId,
                    IsNFCe = order.IsNFCe,
                    Origin = order.Origin,
                    Notes = order.Notes,
                    Status = order.Status
                };
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public Task<ValidationResults> ValidateAsync(AddOrderItemsDTO request)
        {
            var errors = new List<string>();

            if (request.ProductId == 0)
                errors.Add("Selecione um produto.");

            if ((request.UnitPrice <= 0))
                errors.Add("Produto sem preço definido.");

            if (request.Quantity <= 0)
                errors.Add("Quantidade deve ser maior que zero.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }
    }
}
