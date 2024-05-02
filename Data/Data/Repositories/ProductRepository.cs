using Core;
using Core.Entities;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
