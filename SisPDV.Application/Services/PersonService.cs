using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Person;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;

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

        public async Task SaveAsync(PersonDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingPerson = await _context.person.FindAsync(request.Id);

                if(existingPerson == null)
                {
                    var newPerson = new Person
                    {
                        // Mapeamento
                        Name = request.Name,
                        CNPJ_CPF = request.CNPJ_CPF,
                        IE = request.IE,
                        IEIndicator = request.IEIndicator,
                        IM = request.IM,
                        Email = request.Email,
                        Phone = request.Phone,

                        ZipCode = request.ZipCode,
                        Street = request.Street,
                        Number = request.Number,
                        Complement = request.Complement,
                        District = request.District,
                        City = request.City,
                        CityCode = request.CityCode,
                        State = request.State,
                        //Country = request.Country,
                        //CountryCode = request.CountryCode,

                        PersonType = request.PersonType,

                        IsCustomer = request.IsCustomer,
                        IsSupplier = request.IsSupplier,
                        IsCarrier = request.IsCarrier,
                        IsActive = request.IsActive,
                    };
                    _context.person.Add(newPerson);
                }
                else
                {
                    // Mapeamento
                    existingPerson.Name = request.Name;
                    existingPerson.CNPJ_CPF = request.CNPJ_CPF;
                    existingPerson.IE = request.IE;
                    existingPerson.IEIndicator = request.IEIndicator;
                    existingPerson.IM = request.IM;
                    existingPerson.Email = request.Email;
                    existingPerson.Phone = request.Phone;

                    existingPerson.ZipCode = request.ZipCode;
                    existingPerson.Street = request.Street;
                    existingPerson.Number = request.Number;
                    existingPerson.Complement = request.Complement;
                    existingPerson.District = request.District;
                    existingPerson.City = request.City;
                    existingPerson.CityCode = request.CityCode;
                    existingPerson.State = request.State;
                    //existingPerson.Country = request.Country,
                    //existingPerson.CountryCode = request.CountryCode,

                    existingPerson.PersonType = request.PersonType;

                    existingPerson.IsCustomer = request.IsCustomer;
                    existingPerson.IsSupplier = request.IsSupplier;
                    existingPerson.IsCarrier = request.IsCarrier;
                    existingPerson.IsActive = request.IsActive;

                    _context.person.Update(existingPerson);
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

        public async Task<List<PersonDTO>> SearchAsync(string name, string doc, bool isActive, bool isClient, bool isSupplier, bool isCarrier)
        {
            var query = _context.person.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(doc))
                query = query.Where(p => p.CNPJ_CPF == doc);

            if (isActive)
                query = query.Where(p => p.IsActive);
            
            if(isClient || isSupplier || isCarrier)
            {
                query = query.Where(p =>
                    (!isClient || p.IsCustomer) &&
                    (!isSupplier || p.IsSupplier) &&
                    (!isCarrier || p.IsCarrier));
            }

            return await query
                .OrderBy(p => p.Name)
                .Select(p => new PersonDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    CNPJ_CPF = DocumentHelper.FormatCpfCnpj(p.CNPJ_CPF),
                    IE = p.IE,
                    IEIndicator = p.IEIndicator,
                    IM = p.IM,
                    Email = p.Email,
                    Phone = p.Phone,
                    ZipCode = p.ZipCode,
                    Street = p.Street,
                    Number = p.Number,
                    Complement = p.Complement,
                    District = p.District,
                    City = p.City,
                    CityCode = p.CityCode,
                    State = p.State,
                    Country = p.Country,
                    CountryCode = p.CountryCode,
                    PersonType = p.PersonType,
                    IsCustomer = p.IsCustomer,
                    IsSupplier = p.IsSupplier,
                    IsCarrier = p.IsCarrier,
                    IsActive = p.IsActive
                }).ToListAsync();
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

            if(!request.IsCustomer && !request.IsSupplier && !request.IsCarrier)
                errors.Add("Pelo menos um tipo deve ser escolhico (Cliente, Fornecedor ou Transportadora.");


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
