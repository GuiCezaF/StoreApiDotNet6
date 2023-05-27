using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOS.Validations
{
  public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.CodeErp).NotNull().NotEmpty().WithMessage("Codigo Erp deve ser informado");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Documento deve ser informado");

        }
    }
}