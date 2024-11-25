using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
      
        public DeleteCategoryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteCategoryCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existsCategory = await _categoryRepository.GetByIdAsync(command.Id, cancellationToken);

            if (existsCategory == null)
                throw new KeyNotFoundException($"Category with ID {command.Id} not found");

            await _categoryRepository.DeleteAsync(existsCategory, cancellationToken);

            return new DeleteCategoryResult { Success = true };
        }
    }
}
