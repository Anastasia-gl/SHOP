using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class ProductStore : IProductStore
    {
        private readonly ShopContext _entityContext;

        public ProductStore(ShopContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _entityContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Product>> GetProductsAsync(int pages, int limit)
        {
            return await _entityContext.Products
                .Skip((pages - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await _entityContext.Products.CountAsync();
        }

        public async Task<IList<Product>> SortProductAsync(int pages, int limit)
        {
            return await _entityContext.Products
                .Skip((pages - 1) * limit)
                .Take(limit)
                .OrderBy(x => x.Price)
                .ToListAsync();
        }
    }
}