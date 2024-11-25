using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }

        public async Task<Category?> GetByCodeAsync(int code, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Category?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>().FirstOrDefaultAsync(c => c.Id == Id);
        }

        
    }
}
