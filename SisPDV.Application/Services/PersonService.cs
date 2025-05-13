using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Person;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;
using System;

namespace SisPDV.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly PDVDbContext _context;

        public PersonService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<PersonDTO?> GetByDocument(string document)
        {
            var person = await _context.person.FirstOrDefaultAsync(p => p.CNPJ_CPF == document);

            if(person == null)
            {
                return null;
            }
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                CNPJ_CPF = person.CNPJ_CPF,
                IE = person.IE,
                IEIndicator = person.IEIndicator,
                IM = person.IM,
                Email = person.Email,
                Phone = person.Phone,
                ZipCode = person.ZipCode,
                Street = person.Street,
                Number = person.Number,
                Complement = person.Complement,
                District = person.District,
                City = person.City,
                State = person.State,
                Country = person.Country,
                CountryCode = person.CountryCode,
                CityCode = person.CityCode,
                PersonType = person.PersonType,
                IsCustomer = person.IsCustomer,
                IsSupplier = person.IsSupplier,
                IsCarrier = person.IsCarrier,
                IsActive = person.IsActive
            };
        }

        public  async Task<ValidationResults> ValidateAsync(PersonDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
                errors.Add("O nome ou razão social é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.CNPJ_CPF))
                errors.Add("O CPF ou CNPJ é obrigatório.");
            else
            {
                if (request.PersonType == PersonType.Individual && !ValidationHelper.ValidCPF(request.CNPJ_CPF))
                    errors.Add("CPF inválido.");
                else if (request.PersonType == PersonType.Company && !ValidationHelper.ValidCNPJ(request.CNPJ_CPF))
                    errors.Add("CNPJ inválido.");
            }

            if (request.CityCode == 0)
                errors.Add("O código IBGE da cidade é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Street))
                errors.Add("O logradouro (rua) é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.ZipCode))
                errors.Add("O CEP é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.State) || request.State.Length != 2)
                errors.Add("A UF (estado) é obrigatória e deve ter 2 caracteres.");

            if (string.IsNullOrWhiteSpace(request.City))
                errors.Add("O município (cidade) é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Country))
                errors.Add("O país é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.CountryCode))
                errors.Add("O código do país é obrigatório.");

            // Verifica duplicidade de documento (exceto se for uma edição)
            var exists = await _context.person
                .AnyAsync(p => p.CNPJ_CPF == request.CNPJ_CPF && p.Id != request.Id);
            if (exists)
                errors.Add("Já existe uma pessoa cadastrada com este CPF/CNPJ.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return result;
        }
    }
}
