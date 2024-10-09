using Application.Common;
using Domain.Entities;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infrastructure;

namespace Application.Services
{
    public class ProductService(IGenericRepository<Product> repository) : IProductService
    {
        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();
            Utils.SendTopic(products);
            return products;
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id);
        }

        public async Task Update(Product entity, CancellationToken cancellationToken)
        {
            await repository.Update(entity);
        }
    }
}
