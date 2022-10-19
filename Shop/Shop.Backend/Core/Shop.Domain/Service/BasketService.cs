using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketStore _basketStore;

        public BasketService(IBasketStore basketStore)
        {
            _basketStore = basketStore;
        }

        public async Task<Basket> CreateNewBasket(UserProfile user)
        {
            return await _basketStore.AddClientToBasketAsync(user);
        }

        public async Task<Basket> GetByUserIdAsync(int id)
        {
            return await _basketStore.GetBasketByUserIdAsync(id);
        }
    }
}
