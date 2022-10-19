using Shop.Context.Model;
using Shop.Domain.Dtos;

namespace Shop.Domain.Interface.Store
{
    public interface IHistoryStore
    {
        public Task<History> AddFromBasketToHistoryAsync(int basketId, HistoryDto history);

        public Task<List<History>> GetHistoryAsync(int basketId);
    }
}
