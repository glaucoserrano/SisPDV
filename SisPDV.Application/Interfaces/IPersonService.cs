using SisPDV.Application.DTOs.Person;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO?> GetByDocument(string document);
        Task<ValidationResults> ValidateAsync(PersonDTO request);

        Task SaveAsync(PersonDTO request);

        Task<List<PersonDTO>> SearchAsync(string name, string doc, bool isActive, bool isClient, bool isSupplier, bool isCarrier);

    }
}
