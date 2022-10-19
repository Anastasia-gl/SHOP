using Shop.Context.Model;

namespace Shop.Domain.Interface.Service
{
    public interface ITypeService
    {
        public Task<IList<TypeProduct>> GetNameTypeAsync();

        public Task<IList<Product>> SortOneAsync(string name);

        public Task<int> GetCountAsync(string name);
    }
}
