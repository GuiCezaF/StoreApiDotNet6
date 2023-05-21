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
  }
}