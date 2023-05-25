using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOS.Validations
{
  public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.CodeErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("CodErp Deve ser informado");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que Zero");
        }
    }
}