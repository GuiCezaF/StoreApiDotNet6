using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Repositories.Interfaces;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOS.Validations;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Services
{
  public class PersonService : IPersonService
  {
        private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
      _personRepository = personRepository;
      _mapper = mapper;
    }

    async public Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
    {
      if (personDTO == null)
      {
        return ResultService.Fail<PersonDTO>("Objeto deve ser informado");
      }

      var result = new PersonDTOValidator().Validate(personDTO);
      if (!result.IsValid)
      {
        return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);
      }

      var person = _mapper.Map<Person>(personDTO);
      var data = await _personRepository.CreateAsync(person);

      return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }

    public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
    {
      var people = await _personRepository.GetPeopleAsync();
      return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
    }

    public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
    {
      var person = await _personRepository.GetByIdAsync(id);

      if (person == null)
      {
        return ResultService.Fail<PersonDTO>("Pessoa não encontrada");
      }

      return ResultService.Ok(_mapper.Map<PersonDTO>(person));
    }
  }
}