using Shop.Context.Model;

namespace Shop.Domain.Interface.Store
{
    public interface ITypeStore
    {
        public Task<IList<TypeProduct>> GetTypesAsync();

        public Task<IList<Product>> SortOneTypeAsync(string name);

        public Task<int> GetTypeCountAsync(string name);
    }
}
