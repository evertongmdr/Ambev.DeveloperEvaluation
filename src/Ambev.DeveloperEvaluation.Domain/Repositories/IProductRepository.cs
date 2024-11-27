using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
