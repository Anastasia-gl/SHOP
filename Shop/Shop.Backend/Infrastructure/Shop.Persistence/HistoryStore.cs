using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class HistoryStore : IHistoryStore
    {
        private readonly ShopContext _shopContext;

        public HistoryStore(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<History> AddFromBasketToHistoryAsync(int basketId, HistoryDto history)
        {
            History historyFromDb = new();
            historyFromDb.BasketId = basketId;
            historyFromDb.OrderDate = DateTime.Now.Date;
            historyFromDb.FirstName = history.FirstName;
            historyFromDb.LastName = history.LastName;
            historyFromDb.Telephone = history.Telephone;
            historyFromDb.Address = history.Address;
            _shopContext.Histories.Add(historyFromDb);
            await _shopContext.SaveChangesAsync();
            await Delete(basketId);
            return historyFromDb;
        }

        private async Task Delete(int id)
        {
            var list = await _shopContext.ProductBaskets.Where(x => x.BasketId == id).ToListAsync();
            _shopContext.ProductBaskets.RemoveRange(list);
            await _shopContext.SaveChangesAsync();
        }

        public async Task<List<History>> GetHistoryAsync(int basketId)
        {
            return await _shopContext.Histories.Where(x => x.BasketId == basketId).ToListAsync();
        }
    }
}
