using Shop.Context.Model;
using Shop.Domain.Dtos;

namespace Shop.Domain.Interface.Service
{
    public interface IHistoryService
    {
        public Task<History> AddAsync(int basketId, HistoryDto history);

        public Task<List<History>> GetAsync(int basketId);
    }
}
