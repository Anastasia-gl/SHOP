using Shop.Context.Model;

namespace Shop.Domain.Interface.Store
{
    public interface ICharacteristicStore
    {
        public Task<Characteristic> GetCharacteristicsAsync(int id);
    }
}
