using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Categorys.GetCategory
{
    public  class GetCategoryValidator : AbstractValidator<GetCategoryCommand>
    {
        public GetCategoryValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID is required");
        }
    }
}
