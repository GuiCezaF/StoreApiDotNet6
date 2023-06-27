using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Application.DTOS.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain;
using MP.ApiDotNet6.Domain.Integration;
using MP.ApiDotNet6.Domain.Repositories.Interfaces;

namespace MP.ApiDotNet6.Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonImageRepository _personImageRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISavePersonImage _savePersonImage;

        public PersonImageService(IPersonImageRepository personImageRepository, IPersonRepository personRepository, ISavePersonImage savePersonImage)
        {
            _personImageRepository = personImageRepository;
            _personRepository = personRepository;
            _savePersonImage = savePersonImage;
        }

        public async Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
            {
                return ResultService.Fail("Objeto deve ser informado");
            }

            var validations = new PersonImageDTOValidation().Validate(personImageDTO);
            if (!validations.IsValid)
            {
                return ResultService.RequestError("Problemas de validação", validations);
            }

            var person = await _personImageRepository.GetByIdAsync(personImageDTO.PersonId);
            if (person == null)
            {
                return ResultService.Fail("Pessoa não encontrada");
            }

            var pathImage = _savePersonImage.Save(personImageDTO.Image);
            var personImage = new PersonImage(person.Id, pathImage, null);
            await _personImageRepository.CreateAsync(personImage);

            return ResultService.Ok("Imagem salva");
        }

        public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
            {
                return ResultService.Fail("Objeto deve ser informado");
            }
            var validations = new PersonImageDTOValidation().Validate(personImageDTO);
            if (!validations.IsValid)
            {
                return ResultService.RequestError("Problemas de validação", validations);
            }

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);
            if (person == null)
            {
                return ResultService.Fail("id da pessoa não foi encontrado");
            }

            var personImage = new PersonImage(person.Id, null, personImageDTO.Image);
            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem em base64 salva");
        }
    }
}