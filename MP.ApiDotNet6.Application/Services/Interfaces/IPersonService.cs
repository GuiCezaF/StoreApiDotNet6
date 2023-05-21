using MP.ApiDotNet6.Application.DTOS;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
    }
}