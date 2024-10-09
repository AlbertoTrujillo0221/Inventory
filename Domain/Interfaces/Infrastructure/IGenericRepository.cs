using Domain.Entities;

namespace Domain.Interfaces.Infrastructure
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task Update(T entity);

    }
}
