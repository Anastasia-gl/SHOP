using Moq;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class CharacteristicServiceTest
    {
        private readonly CharacteristicService _characteristicService;
        private readonly Mock<ICharacteristicStore> _characteristicStoreMock = new();

        public CharacteristicServiceTest()
        {
            _characteristicService = new(_characteristicStoreMock.Object);
        }

        [Fact]
        public async Task GetAsync_ReturnCharasteristic_WhenIdExists()
        {
            //Arrange
            int id = 1;

            List<Product> products = new()
            {
                new Product{CharacteristicId = 1}
            };


            List<Characteristic> characteristics = new()
            {
                new Characteristic{CharacteristicId = 1}
            };

            var product = products.FirstOrDefault(x=>x.CharacteristicId == id);
            var characteristic = characteristics.FirstOrDefault(x => x.CharacteristicId == product.CharacteristicId);
          
            _characteristicStoreMock.Setup(x=>x.GetCharacteristicsAsync(id))
                .ReturnsAsync(characteristic);

            //Act
            var actualCharacteristic = await _characteristicService.GetAsync(id);

            //Assert
            Assert.Equal(characteristic, actualCharacteristic);
        }
    }
}
