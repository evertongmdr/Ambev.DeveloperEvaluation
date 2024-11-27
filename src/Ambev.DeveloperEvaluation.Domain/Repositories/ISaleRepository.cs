using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository: IRepository<Sale>
    {
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        public Task<Sale?> GetWithSaleItemsByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
