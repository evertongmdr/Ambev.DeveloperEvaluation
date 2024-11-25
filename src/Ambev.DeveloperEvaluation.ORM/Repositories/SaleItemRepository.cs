using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : Repository<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(DbContext context) : base(context)
        {

        }
    }
}
