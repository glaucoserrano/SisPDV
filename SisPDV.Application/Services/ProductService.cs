using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PDVDbContext _context;

        public ProductService(PDVDbContext context)
        {
            _context = context;
        }

        public Task<ValidationResults> ValidateAsync(ProductDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Description))
                errors.Add("Descrição é obrigatória.");

            if (string.IsNullOrWhiteSpace(request.Type))
                errors.Add("Tipo do produto é obrigatório.");

            if (request.CfopId <= 0)
                errors.Add("CFOP é obrigatório.");

            if (request.UnityId == null || request.UnityId <= 0)
                errors.Add("Unidade de venda é obrigatória.");


            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }
    }
}
