using Shop.Context.Model;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryStore _historyStore;

        public HistoryService(IHistoryStore historyStore)
        {
            _historyStore = historyStore;
        }

        public async Task<History> AddAsync(int basketId, HistoryDto history)
        {
            return await _historyStore.AddFromBasketToHistoryAsync(basketId, history);
        }

        public async Task<List<History>> GetAsync(int basketId)
        {
            return await _historyStore.GetHistoryAsync(basketId);
        }
    }
}
