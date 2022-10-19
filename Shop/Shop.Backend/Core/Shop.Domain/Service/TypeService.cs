using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class TypeService : ITypeService
    {
        private readonly ITypeStore _typeStore;

        public TypeService(ITypeStore typeStore)
        {
            _typeStore = typeStore;
        }

        public async Task<IList<TypeProduct>> GetNameTypeAsync()
        {
            var typeList = await _typeStore.GetTypesAsync();

            if (typeList == null)
            {
                return null;
            }

            return typeList;
        }

        public async Task<IList<Product>> SortOneAsync(string name)
        {
            var productAccordingType = await _typeStore.SortOneTypeAsync(name);

            if (productAccordingType == null)
            {
                return null;
            }

            return productAccordingType;
        }

        public async Task<int> GetCountAsync(string name)
        {
            return await _typeStore.GetTypeCountAsync(name);
        }
    }
}