using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly ICharacteristicStore _characteristicStore;

        public CharacteristicService(ICharacteristicStore characteristicStore)
        {
            _characteristicStore = characteristicStore;
        }

        public async Task<Characteristic> GetAsync(int id)
        {
            return await _characteristicStore.GetCharacteristicsAsync(id);
        }
    }
}
