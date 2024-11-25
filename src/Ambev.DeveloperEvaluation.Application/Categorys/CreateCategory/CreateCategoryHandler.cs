using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public async Task<CreateCategoryResult> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator();

            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existsCategory = await _categoryRepository.GetByCodeAsync(command.Code);

            if (existsCategory != null)
                throw new InvalidOperationException($"This code {command.Code} is already associated with a category.");

            var category = _mapper.Map<Category>(command);

            var createdCategory = await _categoryRepository.CreateAsync(category);
            var result = _mapper.Map<CreateCategoryResult>(createdCategory);

            return result;
        }
    }
}
