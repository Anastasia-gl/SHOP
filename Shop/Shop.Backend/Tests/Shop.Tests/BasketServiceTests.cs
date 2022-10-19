using Moq;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class BasketServiceTests
    {
        private readonly BasketService _basketService;
        private readonly Mock<IBasketStore> _basketStoreMock = new();

        public BasketServiceTests()
        {
            _basketService = new(_basketStoreMock.Object);
        }

        [Fact]
        public async Task CreateNewBasket_ReturnBasket_WhenArgumentExist()
        {
            //Arrange
            UserProfile user = new();
            user.UserId = 1;

            Basket basket = new();
            basket.UserId = user.UserId;

            _basketStoreMock.Setup(x=>x.AddClientToBasketAsync(user))
                .ReturnsAsync(basket);

            //Act
            var actualBasket = await _basketService.CreateNewBasket(user);

            //Assert
            Assert.Equal(basket, actualBasket);
        }

        [Fact]
        public async Task GetByUserIdAsync_ReturnBasket_WhenArgumentExist()
        {
            //Arrange
            List<Basket> baskets = new()
             {
                 new Basket {BasketId = 1}
             };

            var basket = baskets.FirstOrDefault(x => x.BasketId == 1);

            _basketStoreMock.Setup(x => x.GetBasketByUserIdAsync(1))
                .ReturnsAsync(basket);

            //Act
            var actualBasket = await _basketService.GetByUserIdAsync(1);

            //Assert
            Assert.Equal(basket, actualBasket);
        }
    }
}
