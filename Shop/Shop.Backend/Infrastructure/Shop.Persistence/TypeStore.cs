using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class TypeStore : ITypeStore
    {
        private readonly ShopContext _entityContext;

        public TypeStore(ShopContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IList<TypeProduct>> GetTypesAsync()
        {
            return await _entityContext.TypeProducts.ToListAsync();
        }

        public async Task<IList<Product>> SortOneTypeAsync(string name)
        {
            var type = _entityContext.TypeProducts.FirstOrDefault(x => x.TypeName == name);

            return await _entityContext.Products
                .Where(x => x.TypeId == type.TypeId)
                .ToListAsync();
        }

        public async Task<int> GetTypeCountAsync(string name)
        {
            var type = _entityContext.TypeProducts.FirstOrDefault(x => x.TypeName == name);

           return await _entityContext.Products
                .Where(x => x.TypeId == type.TypeId).CountAsync();
        }
    }
}
