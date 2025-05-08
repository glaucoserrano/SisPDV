using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly PDVDbContext _context;

        public CompanyService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> GetAsync()
        {
            return await _context.company.FirstOrDefaultAsync();
        }

        public async Task<string?> GetCnpjHashAsync()
        {
            return await _context.systemValidation.
                Select(sv => sv.CnpjHash).
                FirstOrDefaultAsync();
        }

        public async Task SaveAsync(CompanyDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var existing = await _context.company.FirstOrDefaultAsync();

                if(existing == null)
                {
                    var newCompany = new Company
                    {
                        CNPJ = request.CNPJ!,
                        CompanyName = request.CompanyName!,
                        FantasyName = request.FantasyName!,
                        IE = request.IE!,
                        IM = request.IM!,
                        UF = request.UF!,
                        City = request.City!,
                        CityCode = request.CityCode!,
                        CEP = request.CEP!,
                        Street = request.Street!,
                        Number = request.Number!,
                        District = request.District!,
                        Phone = request.Phone!,
                        Email = request.Email!,
                        TaxRegime = request.TaxRegime
                    };
                    _context.company.Add(newCompany);
                }
                else
                {
                    var existsCompany = await _context.company.FindAsync(request.Id);

                    if (existsCompany == null)
                        throw new Exception("Empresa não encontrada");

                    existsCompany.CompanyName = request.CompanyName;
                    existsCompany.FantasyName = request.FantasyName;
                    existsCompany.IE = request.IE;
                    existsCompany.IM = request.IM;
                    existsCompany.UF = request.UF;
                    existsCompany.City = request.City;
                    existsCompany.CityCode = request.CityCode;
                    existsCompany.CEP = request.CEP;
                    existsCompany.Street = request.Street;
                    existsCompany.Number = request.Number;
                    existsCompany.District = request.District;
                    existsCompany.Phone = request.Phone;
                    existsCompany.Email = request.Email;
                    existsCompany.TaxRegime = request.TaxRegime;

                    _context.company.Update(existsCompany);
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

        public async Task SaveCnpjHashAsync(string cnpj)
        {
            var hash = HashHelper.ComputeSha256Hash(cnpj);

            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var validation = await _context.systemValidation.FirstOrDefaultAsync();

                if(validation == null)
                {
                    _context.systemValidation.Add(new SystemValidation
                    {
                        CnpjHash = hash
                    });
                }
                else
                {
                    validation.CnpjHash = hash;
                    _context.systemValidation.Update(validation);

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

        public Task<ValidationResults> ValidateCompanyData(CompanyDTO request)
        {
            var errors = new List<string>();

            // CNPJ
            if (string.IsNullOrWhiteSpace(request.CNPJ) || request.CNPJ.Length != 14)
                errors.Add("CNPJ inválido. Deve conter 14 dígitos.");

            // Razão Social
            if (string.IsNullOrWhiteSpace(request.CompanyName))
                errors.Add("Razão Social é obrigatória.");

            // Nome Fantasia
            if (string.IsNullOrWhiteSpace(request.FantasyName))
                errors.Add("Nome Fantasia é obrigatório.");

            // Inscrição Estadual
            if (string.IsNullOrWhiteSpace(request.IE))
                errors.Add("Inscrição Estadual é obrigatória.");

            // UF
            if (string.IsNullOrWhiteSpace(request.UF) || request.UF.Length != 2)
                errors.Add("UF inválida. Informe o estado com 2 letras.");

            // Cidade e Código IBGE
            if (string.IsNullOrWhiteSpace(request.City))
                errors.Add("Município é obrigatório.");
            if (request.CityCode <= 0)
                errors.Add("Código IBGE do município é obrigatório.");

            // Endereço
            if (string.IsNullOrWhiteSpace(request.Street))
                errors.Add("Logradouro (rua) é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.Number))
                errors.Add("Número do endereço é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.District))
                errors.Add("Bairro é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.CEP) || request.CEP.Length != 8)
                errors.Add("CEP inválido. Deve conter 8 dígitos.");

            // Contato
            if (string.IsNullOrWhiteSpace(request.Phone))
                errors.Add("Telefone da empresa é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains("@"))
                errors.Add("E-mail da empresa é obrigatório e deve ser válido.");

            // Regime Tributário
            if (!Enum.IsDefined(typeof(TaxRegime), request.TaxRegime) || request.TaxRegime == TaxRegime.None)
                errors.Add("Selecione um Regime Tributário válido.");

            var validate = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(validate);
        }

        public Task<bool> ValidateHash(string? cnpj, string? hash )
        {
            if (string.IsNullOrEmpty(cnpj) || string.IsNullOrEmpty(hash))
                return Task.FromResult(false);

            var computedHash = HashHelper.ComputeSha256Hash(cnpj);
            var isValid = computedHash == hash;

            return Task.FromResult(isValid);
        }
    }
}
