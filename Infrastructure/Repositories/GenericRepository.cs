using Domain.Entities;
using Domain.Interfaces.Infrastructure;
using Infrastructure.Common.Factories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(IDbContextFactory factory)
        : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = (ApplicationDbContext)factory.Create();

        protected DbSet<T> Set => _dbContext.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Set.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Set.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Update(T entity)
        {
            Set.Update(entity);
            await Task.CompletedTask;
        }
    }
}
