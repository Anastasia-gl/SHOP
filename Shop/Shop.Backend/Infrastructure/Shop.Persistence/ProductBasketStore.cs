using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class ProductBasketStore : IProductBasketStore
    {
        private readonly ShopContext _entityContext;

        public ProductBasketStore(ShopContext entityContext)
        {
            _entityContext = entityContext;
        }
        
        public async Task<ProductBasket> AddProductToBasketAsync(int productId, int basketId)
        {
            var price = _entityContext.Products.FirstOrDefault(x => x.Id == productId);

            ProductBasket basket = new();
            basket.ProductId = productId;
            basket.BasketId = basketId;
            basket.TotalPrice = price.Price;

            _entityContext.ProductBaskets.Add(basket);
            await _entityContext.SaveChangesAsync();

            return basket;
        }

        public async Task<List<Product>> GetItemsByBasketIdAsync(int basketId)
        {
            var productBaskets = _entityContext.ProductBaskets.Include(x => x.Product).Where(x => x.BasketId == basketId);
            return await productBaskets.Select(x => x.Product).ToListAsync();
        }

        public async Task<ProductBasket> DeleteProductFromBasketAsync(int productId, int basketId)
        {
            var product = _entityContext.ProductBaskets.FirstOrDefault(x => x.ProductId == productId && x.BasketId == basketId);

            _entityContext.ProductBaskets.Remove(product);
            await _entityContext.SaveChangesAsync();

            return product;
        }

        public async Task<List<ProductBasket>> GetListFromBasketAsync(int basketId)
        {
            return await _entityContext.ProductBaskets.Where(x=>x.BasketId == basketId).ToListAsync();
        }
    }
}
