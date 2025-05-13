using SisPDV.Application.DTOs.Person;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO?> GetByDocument(string document);
        Task<ValidationResults> ValidateAsync(PersonDTO request);


    }
}
