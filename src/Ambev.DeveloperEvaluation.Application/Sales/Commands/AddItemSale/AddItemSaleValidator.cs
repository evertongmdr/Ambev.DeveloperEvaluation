using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddItemSaleCommandValidator : AbstractValidator<AddItemSaleCommand>
    {
        public AddItemSaleCommandValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is requerid");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is requerid");

            RuleFor(x => x.QuantityProduct)
                .GreaterThan(0)
                .WithMessage("The quantity must be greater than 0");
        }
    }
}
