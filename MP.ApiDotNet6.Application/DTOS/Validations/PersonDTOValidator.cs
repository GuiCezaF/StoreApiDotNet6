using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOS.Validations
{
    public class PersonImageDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonImageDTOValidator()
        {
            RuleFor(x => x.Document)
            .NotEmpty()
            .NotNull()
            .WithMessage("Documento deve ser Informado");

            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome deve ser Informado");

            RuleFor(x => x.Phone)
            .NotNull()
            .NotEmpty()
            .WithMessage("Telefone deve ser Informado");
        }
    }
}