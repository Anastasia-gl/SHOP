using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductStore _productStore;

        public ProductService(IProductStore productStore)
        {
            _productStore = productStore;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productStore.GetProductByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<int> GetCountAsync()
        {
            return await _productStore.GetProductsCountAsync();
        }

        public async Task<IList<Product>> GetListAsync(int pages, int limit)
        {
            var products = await _productStore.GetProductsAsync(pages, limit);

            if (products == null)
            {
                return null;
            }

            return products;
        }

        public async Task<IList<Product>> SortAsync(int pages, int limit)
        {
            var products = await _productStore.SortProductAsync(pages, limit);

            if(products == null)
            {
                return null;
            }

            return products;
        }
    }
}
