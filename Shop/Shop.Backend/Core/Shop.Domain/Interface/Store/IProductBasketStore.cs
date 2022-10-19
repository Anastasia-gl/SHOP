using Shop.Context.Model;

namespace Shop.Domain.Interface.Store
{
    public interface IProductBasketStore
    {
        public Task<ProductBasket> AddProductToBasketAsync(int productId, int basketId);

        public Task<List<Product>> GetItemsByBasketIdAsync(int basketId);

        public Task<ProductBasket> DeleteProductFromBasketAsync(int productId, int basketId);

        public Task<List<ProductBasket>> GetListFromBasketAsync(int basketId);
    }
}
