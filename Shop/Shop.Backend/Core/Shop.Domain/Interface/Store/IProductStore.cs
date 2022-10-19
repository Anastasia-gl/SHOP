using Shop.Context.Model;

namespace Shop.Domain.Interface.Store
{
    public interface IProductStore
    {
        public Task<IList<Product>> GetProductsAsync(int pages, int limit);

        public Task<Product> GetProductByIdAsync(int id);

        public  Task<int> GetProductsCountAsync();

        public Task<IList<Product>> SortProductAsync(int pages, int limit);
    }
}
