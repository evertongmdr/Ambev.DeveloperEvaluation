using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);
            return await SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Update(entity);
            return await SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Releases resources used by the repository instance, including the database context.
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }

        /// <summary>
        /// Helper method to handle SaveChangesAsync with exception handling.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The number of state entries written to the database.</returns>
        private async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes to the database. Please try again later.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred. Please contact support.");
            }
        }
    }
}


