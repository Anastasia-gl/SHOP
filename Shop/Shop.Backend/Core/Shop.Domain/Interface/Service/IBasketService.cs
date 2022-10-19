using Shop.Context.Model;

namespace Shop.Domain.Interface.Service
{
    public interface IBasketService
    {
        public Task<Basket> CreateNewBasket(UserProfile user);

        public Task<Basket> GetByUserIdAsync(int id);
    }
}
