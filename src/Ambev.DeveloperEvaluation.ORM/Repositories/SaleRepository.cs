using Ambev.DeveloperEvaluation.Common.Data;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DefaultContext context) : base(context)
        {

        }

        public async Task<Sale?> GetWithSaleItemsByIdAsync(Guid id)
        {
            return await _context.Set<Sale>().Include(s => s.SaleItems)
                .ThenInclude(si => si.Product).FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}
