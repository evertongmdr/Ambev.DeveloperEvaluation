using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetByCodeAsync(int code, CancellationToken cancellationToken = default);
        Task<Category?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
