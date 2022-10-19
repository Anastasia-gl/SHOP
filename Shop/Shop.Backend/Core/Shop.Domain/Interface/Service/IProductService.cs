using Shop.Context.Model;

namespace Shop.Domain.Interface.Service
{
    public interface IProductService
    {

        public Task<IList<Product>> GetListAsync(int pages, int limit);

        public Task<Product> GetByIdAsync(int id);

        public Task<int> GetCountAsync();

        public Task<IList<Product>> SortAsync(int pages, int limit);
    }
}
