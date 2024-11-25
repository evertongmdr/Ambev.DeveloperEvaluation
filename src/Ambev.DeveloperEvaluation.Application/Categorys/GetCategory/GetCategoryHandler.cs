using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.GetCategory
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryCommand, GetCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryResult> Handle(GetCategoryCommand commmand, CancellationToken cancellationToken)
        {
            var validator = new GetCategoryValidator();
            var validationResult = await validator.ValidateAsync(commmand, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var category = await _categoryRepository.GetByIdAsync(commmand.Id, cancellationToken);

            if(category == null)
                throw new KeyNotFoundException($"Category with ID {commmand.Id} not found");

            return _mapper.Map<GetCategoryResult>(category);
        }
    }
}
