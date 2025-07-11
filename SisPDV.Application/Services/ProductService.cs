using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
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

            if ((request.ProductTypeId == 0))
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
        public async Task SaveAsync(ProductDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingProduct = await _context.products.FindAsync(request.Id);

                if (existingProduct == null)
                {
                    // Novo cadastro
                    var newProduct = new Product
                    {
                        Description = request.Description,
                        ProductTypeId = request.ProductTypeId,
                        Barcode = request.Barcode,
                        NCM = request.NCM,
                        CEST = request.CEST,
                        CfopId = request.CfopId,
                        UnityId = request.UnityId,
                        CategoryId = request.CategoryId,
                        Notes = request.Notes,
                        Active = request.Active,

                        CostPrice = PriceConverter.ToCents(request.CostPrice),  // centavos
                        Price = PriceConverter.ToCents(request.Price), //centavos
                        MarginProfit = request.ProfitMargin,

                        Weighing = request.Weighing,
                        Fractional = request.Fractional,
                        Service = request.Service,

                        UseStockControl = request.UseStockControl,
                        AllowZeroStockSale = request.AllowZeroStockSale,

                        UsePrinterSector = request.PrintInSector,
                        PrinterSectorId = request.SectorPrinterId,
                        
                        ImagePath = request.ImagePath,
                        RefSupplier = request.RefSupplier
                    };
                    await _context.products.AddAsync(newProduct);
                }
                else
                {
                    existingProduct.Description = request.Description;
                    existingProduct.ProductTypeId = request.ProductTypeId;
                    existingProduct.Barcode = request.Barcode;
                    existingProduct.NCM = request.NCM;
                    existingProduct.CEST = request.CEST;
                    existingProduct.CfopId = request.CfopId;
                    existingProduct.UnityId = request.UnityId;
                    existingProduct.CategoryId = request.CategoryId;
                    existingProduct.Notes = request.Notes;
                    existingProduct.Active = request.Active;

                    existingProduct.CostPrice = PriceConverter.ToCents(request.CostPrice);  // centavos
                    existingProduct.Price = PriceConverter.ToCents(request.Price); //centavos
                    existingProduct.MarginProfit = request.ProfitMargin;

                    existingProduct.Weighing = request.Weighing;
                    existingProduct.Fractional = request.Fractional;
                    existingProduct.Service = request.Service;

                    existingProduct.UseStockControl = request.UseStockControl;
                    existingProduct.AllowZeroStockSale = request.AllowZeroStockSale;

                    existingProduct.UsePrinterSector = request.PrintInSector;
                    existingProduct.PrinterSectorId = request.SectorPrinterId;

                    existingProduct.ImagePath = request.ImagePath;
                    existingProduct.RefSupplier = request.RefSupplier;

                    _context.products.Update(existingProduct);
                }
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }
        public async Task<ProductDTO?> GetBySearchTermAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            var query = _context.products.AsNoTracking();

            Product? product = null;

            // Tenta converter para ID (int)
            if (int.TryParse(searchTerm, out var id))
            {
                product = await query.FirstOrDefaultAsync(p => p.Id == id);
            }

            // Se não achou por ID, tenta por código interno, código de barras ou código fornecedor
            if (product == null)
            {
                product = await query.FirstOrDefaultAsync(p =>
                    p.Barcode == searchTerm ||
                    p.RefSupplier == searchTerm);
            }

            if (product == null)
                return null;
            var productStock = await _context.productStock
                .AsNoTracking()
                .FirstOrDefaultAsync(ps => ps.ProductId == product.Id);
            return new ProductDTO
            {
                Id = product.Id,
                Description = product.Description,
                Barcode = product.Barcode!,
                RefSupplier = product.RefSupplier,
                NCM = product.NCM,
                CEST = product.CEST,
                Notes = product.Notes,
                CfopId = product.CfopId,
                UnityId = product.UnityId,
                CategoryId = product.CategoryId,
                ProductTypeId = product.ProductTypeId,
                CostPrice = PriceConverter.FromCents(product.CostPrice),
                Price = PriceConverter.FromCents(product.Price),
                ProfitMargin = product.MarginProfit,
                UseStockControl = product.UseStockControl,
                AllowZeroStockSale = product.AllowZeroStockSale,
                Weighing = product.Weighing,
                Fractional = product.Fractional,
                Service = product.Service,
                PrintInSector = product.UsePrinterSector,
                SectorPrinterId = product.PrinterSectorId,
                ImagePath = product.ImagePath,
                Active = product.Active,
                maxQuantity = productStock!.MaximumQuantity,
                minQuantity = productStock!.MinimumQuantity,
                Location = productStock.Location,
                Stock = productStock.Quantity
            };
        }

        public async Task<List<ProductDTO>> SearchAsync(SearchFilterProductsDTO filter)
        {
            var query = _context.products
                .Include(p => p.ProductType)
                .Include(p => p.Cfop)
                .Include(p => p.Unity)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Description))
                query = query.Where(p => p.Description.Contains(filter.Description));

            if (filter.ProductTypeId.HasValue && filter.ProductTypeId > 0)
                query = query.Where(p => p.ProductTypeId == filter.ProductTypeId);

            if (filter.CfopId.HasValue && filter.CfopId > 0)
                query = query.Where(p => p.CfopId == filter.CfopId);

            if (filter.Status.HasValue && (Status)filter.Status == Status.Active)
                query = query.Where(p => p.Active == true);
            else if(filter.Status.HasValue && (Status)filter.Status == Status.Inactive)
                query = query.Where(p => p.Active == false);

            var result = await query
                .OrderBy(p => p.Description)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    ProductType = p.ProductType.Type,
                    Unity = p.Unity.Description,
                    Price = PriceConverter.FromCents(p.Price),
                    Cfop = p.Cfop!.Description.ToString()
                })
                .ToListAsync();
            return result;
        }

        public async Task<List<ProductStockSearchDTO>> GetProductsForStockAsync()
        {
            return await _context.products
                .Where(p => p.UseStockControl && p.Active == true)
                .Select(p => new ProductStockSearchDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    Code = p.Id.ToString(), // Ou outro campo se houver
                    Barcode = p.Barcode ?? "",
                    SupplierCode = p.RefSupplier ?? ""
                })
            .ToListAsync();
        }
        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product =  await _context.products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && p.Active == true);

            if (product == null)
                return new ProductDTO();

            return new ProductDTO
            {
                Id = product.Id,
                Description = product.Description
            };
        }   
    }
}
