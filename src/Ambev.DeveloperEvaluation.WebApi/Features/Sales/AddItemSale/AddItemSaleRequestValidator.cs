using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddItemSale
{
    public class AddItemSaleRequestValidator: AbstractValidator<AddOrRemoveItemSaleRequest>
    {

        public AddItemSaleRequestValidator()
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
