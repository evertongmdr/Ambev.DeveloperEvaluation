using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResult>
    {
        /// <summary>
        /// Get The Code for the Category
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Get name of the Category
        /// </summary>
        public string Name { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateCategoryCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

}
