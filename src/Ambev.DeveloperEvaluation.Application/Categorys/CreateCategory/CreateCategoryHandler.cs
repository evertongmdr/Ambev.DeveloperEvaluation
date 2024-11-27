using Ambev.DeveloperEvaluation.Common.Messages.Commnad;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Net;

namespace Ambev.DeveloperEvaluation.Application.Categorys.CreateCategory
{
    public class CreateCategoryHandler : CommandHandler, IRequestHandler<CreateCategoryCommand, CreateCategoryResult?>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(DomainValidationContext domainNotificationContext,
            ICategoryRepository categoryRepository, IMapper mapper) : base(domainNotificationContext)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public async Task<CreateCategoryResult?> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {

            if (!ValidCommand(command)) return null;
            
            var existsCategory = await _categoryRepository.GetByCodeAsync(command.Code);

            if (existsCategory != null)
            {
                _domainValidationContext.AddValidationError("Create Category", $"This code {command.Code} is " +
                    $"already associated with a category.");

                return null;
            }

            var category = _mapper.Map<Category>(command);

            var createdCategory = await _categoryRepository.CreateAsync(category);
            var result = _mapper.Map<CreateCategoryResult>(createdCategory);

            return result;
        }
    }


}
