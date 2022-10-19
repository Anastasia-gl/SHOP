using Shop.Context.Model;

namespace Shop.Domain.Interface.Store
{ 
    public interface IBasketStore
    {
        public Task<Basket> AddClientToBasketAsync(UserProfile user);

        public Task<Basket> GetBasketByUserIdAsync(int id);
    }
}
