using Shop.Context.Model;

namespace Shop.Domain.Interface.Service
{
    public interface ICharacteristicService
    {
        public Task<Characteristic> GetAsync(int id);
    }
}
