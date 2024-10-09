using Domain.Entities;

namespace Domain.Interfaces.Application
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken);
        Task<Product> GetById(Guid id, CancellationToken cancellationToken); 
        Task Update(Product entity, CancellationToken cancellationToken);
    }
}
