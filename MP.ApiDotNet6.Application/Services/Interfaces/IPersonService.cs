using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Domain.FiltersDb;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);

        Task<ResultService<ICollection<PersonDTO>>> GetAsync();

        Task<ResultService<PersonDTO>> GetByIdAsync(int id);

        Task<ResultService> UpdateAsync(PersonDTO personDTO);

        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
    }
}