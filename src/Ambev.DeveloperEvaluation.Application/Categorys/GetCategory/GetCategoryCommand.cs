using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.GetCategory
{
    public class GetCategoryCommand : IRequest<GetCategoryResult>
    {
        public Guid Id { get; set; }

        public GetCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
