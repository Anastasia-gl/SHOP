using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class BasketStore : IBasketStore
    {
        private readonly ShopContext _entityContext;

        public BasketStore(ShopContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<Basket> AddClientToBasketAsync(UserProfile user)
        {
            Basket basketFromDb = new();
            basketFromDb.UserId = user.UserId;

            _entityContext.Baskets.Add(basketFromDb);
            await _entityContext.SaveChangesAsync();
            return basketFromDb;
        }

        public async Task<Basket> GetBasketByUserIdAsync(int id)
        {
            return await _entityContext.Baskets.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
