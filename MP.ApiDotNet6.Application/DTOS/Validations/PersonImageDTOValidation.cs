using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOS.Validations
{
    public class PersonImageDTOValidation : AbstractValidator<PersonImageDTO>
    {
        public PersonImageDTOValidation()
        {
            RuleFor(x => x.PersonId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Person Id não pode ser menor ou igual a zero");

            RuleFor(x => x.Image).NotEmpty().NotNull().WithMessage("Image devve ser informado");
        }
    }
}