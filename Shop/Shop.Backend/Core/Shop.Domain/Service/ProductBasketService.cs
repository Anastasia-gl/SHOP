using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class ProductBasketService : IProductBasketService
    {
        private readonly IProductBasketStore _productBasketStore;

        public ProductBasketService(IProductBasketStore productBasketStore)
        {
            _productBasketStore = productBasketStore;
        }

        public async Task<ProductBasket> AddAsync(int productId, int basketId)
        {
            return await _productBasketStore.AddProductToBasketAsync(productId, basketId);
        }

        public async Task<ProductBasket> DeleteAsync(int productId, int basketId)
        {
          return await _productBasketStore.DeleteProductFromBasketAsync(productId,basketId);
        }

        public async Task<List<Product>> GetAsync(int basketId)
        {
            return await _productBasketStore.GetItemsByBasketIdAsync(basketId);
        }

        public async Task<List<ProductBasket>> GetListAsync(int basketId)
        {
            return await _productBasketStore.GetListFromBasketAsync(basketId);
        }
    }
}
