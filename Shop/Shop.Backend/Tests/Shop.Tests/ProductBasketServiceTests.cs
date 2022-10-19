using Moq;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class ProductBasketServiceTests
    {
        private readonly ProductBasketService _productBasketService;
        private readonly Mock<IProductBasketStore> _productBasketStoreMock = new();

        public ProductBasketServiceTests()
        {
            _productBasketService = new(_productBasketStoreMock.Object);
        }

        [Fact]
        public async Task AddAsync_ReturnProductBasket_WhenItExists()
        {
            //Arrange

            int basketId = 2;
            int productId = 1;
            ProductBasket productBasket = new();
            productBasket.BasketId = basketId;
            productBasket.ProductId = productId;

            _productBasketStoreMock.Setup(x => x.AddProductToBasketAsync(productId, basketId))
                .ReturnsAsync(productBasket);

            //Act
            var returnedProductBasket = await _productBasketService.AddAsync(productId, basketId);

            //Assert
            Assert.Equal(productBasket, returnedProductBasket);
        }

        [Fact]
        public async Task DeleteAsync_ReturnProductBasket_WhenItExists()
        {
            //Arrange

            int basketId = 2;
            int productId = 1;
            ProductBasket productBasket = new();
            productBasket.BasketId = basketId;
            productBasket.ProductId = productId;

            _productBasketStoreMock.Setup(x => x.DeleteProductFromBasketAsync(productId, basketId))
                .ReturnsAsync(productBasket);

            //Act
            var returnedProductBasket = await _productBasketService.DeleteAsync(productId, basketId);

            //Assert
            Assert.Equal(productBasket, returnedProductBasket);
        }

        [Fact]
        public async Task GetAsync_ReturnListProducts_WhenItExists()
        {
            //Arrange

            int basketId = 2;
       
            List<ProductBasket> productBasket = new()
            {
                new ProductBasket {BasketId = 1, ProductId = 1},
                new ProductBasket { BasketId= 2, ProductId=2 }
            };
          
            var expectedProduct = productBasket.Where(x => x.BasketId == basketId).Select(x=>x.Product).ToList();

            _productBasketStoreMock.Setup(x => x.GetItemsByBasketIdAsync(basketId))
                .ReturnsAsync(expectedProduct);

            //Act
            var returnedProductBasket = await _productBasketService.GetAsync(basketId);

            //Assert
            Assert.Equal(expectedProduct, returnedProductBasket);
        }

        [Fact]
        public async Task GetListAsync_ReturnListProductBaskets_WhenItExists()
        {
            //Arrange

            int basketId = 2;

            List<ProductBasket> productBasket = new()
            {
                new ProductBasket {BasketId = 1, ProductId = 1},
                new ProductBasket { BasketId= 2, ProductId=2 }
            };

            var expectedProduct = productBasket.Where(x => x.BasketId == basketId).ToList();

            _productBasketStoreMock.Setup(x => x.GetListFromBasketAsync(basketId))
                .ReturnsAsync(expectedProduct);

            //Act
            var returnedProductBasket = await _productBasketService.GetListAsync(basketId);

            //Assert
            Assert.Equal(expectedProduct, returnedProductBasket);
        }
    }
}
