using Ambev.DeveloperEvaluation.Common.Messages.Commnad;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.DeleteCategory
{
    public class DeleteCategoryHandler : CommandHandler, IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult?>
    {
        private readonly ICategoryRepository _categoryRepository;
      
        public DeleteCategoryHandler(DomainValidationContext domainNotificationContext,
            ICategoryRepository categoryRepository) : base(domainNotificationContext)
        {
            _categoryRepository = categoryRepository;

        }
        public async Task<DeleteCategoryResult?> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            if(!ValidCommand(command)) return null;

            var existsCategory = await _categoryRepository.GetByIdAsync(command.Id, cancellationToken);

            if (existsCategory == null)
            {
                _domainValidationContext.AddValidationError("Delete Category", $"Category with ID {command.Id} not found");
                return null;
            }

             await _categoryRepository.DeleteAsync(existsCategory, cancellationToken);

            return new DeleteCategoryResult { Success = true };
        }
    }
}
