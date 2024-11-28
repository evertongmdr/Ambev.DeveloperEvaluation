using Ambev.DeveloperEvaluation.Common.Data;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository : IRepository<Sale>
    {
        public Task<Sale?> GetWithSaleItemsByIdAsync(Guid id);
    }
}
