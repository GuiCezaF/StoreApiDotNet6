using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOS.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email deve ser informado!");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Senha deve ser informada!");
        }
    }
}