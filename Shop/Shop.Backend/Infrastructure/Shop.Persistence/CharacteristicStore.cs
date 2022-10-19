using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class CharacteristicStore : ICharacteristicStore
    {

        private readonly ShopContext _entityContext;

        public CharacteristicStore(ShopContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<Characteristic> GetCharacteristicsAsync(int id)
        {
            var product =  _entityContext.Products.FirstOrDefault(p => p.Id == id);

            return await _entityContext.Characteristics.FirstOrDefaultAsync(x => x.CharacteristicId == product.CharacteristicId);
        }
    }
}
