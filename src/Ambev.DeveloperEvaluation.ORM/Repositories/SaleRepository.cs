using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(DbContext context) : base(context)
        {

        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Sale>().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Sale?> GetWithSaleItemsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Sale>().Include(s => s.SaleItems)
                .ThenInclude(si => si.Product).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
    }
}
