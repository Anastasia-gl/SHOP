using Shop.Context.Model;

namespace Shop.Domain.Interface.Service
{
    public interface IProductBasketService
    {
        public Task<ProductBasket> AddAsync(int productId, int basketId);

        public Task<List<Product>> GetAsync(int basketId);

        public Task<ProductBasket> DeleteAsync(int productId, int basketId);

        public Task<List<ProductBasket>> GetListAsync(int basketId);
    }
}
