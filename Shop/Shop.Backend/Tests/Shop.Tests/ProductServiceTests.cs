using Moq;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductStore> _productStoreMock = new();

        public ProductServiceTests()
        {
            _productService = new(_productStoreMock.Object);
        }

        [Fact]
        public async void GetCountAsync_ShouldReturnCount_WhenListProductsExist()
        {
            //Arrange
            var products = new List<Product>()
            {
                new Product
                {  Id = 1, Name = "Iphone 14" },
                new Product
                {  Id = 2, Name = "Iphone 14" },
                new Product
                {  Id = 3, Name = "Iphone 14" }
            };

            _productStoreMock.Setup(x => x.GetProductsCountAsync())
                .ReturnsAsync(products.Count);

            //Act
            var productList = await _productService.GetCountAsync();

            //Assert
            Assert.Equal(products.Count, productList);
        }


        [Fact]
        public async void GetListAsync_ShouldReturnListProducts_WhenProductsExist()
        {
            //Arrange
            int page = 1;
            int limit = 2;

            var products = new List<Product>()
            {
                new Product
                {  Id = 1, Name = "Iphone 14" },
                new Product
                {  Id = 2, Name = "Iphone 14" },
                new Product
                {  Id = 3, Name = "Iphone 14" }
            };

            var paginationList = products.Skip((page - 1) * limit).Take(limit).ToList();

            _productStoreMock.Setup(x => x.GetProductsAsync(page, limit))
                .ReturnsAsync(paginationList);

            //Act
            var productList = await _productService.GetListAsync(page, limit);

            //Assert
            Assert.Equal(paginationList, productList);
        }


        [Fact]
        public async void GetListAsync_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            //Arrange
            _productStoreMock.Setup(x => x.GetProductsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var productList = await _productService.GetListAsync(It.IsAny<int>(), It.IsAny<int>());

            //Assert
            Assert.Null(productList);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct__WhenProductExist()
        {
            //Arrange
            int id = 1;
            Product product = new()
            {
                Id = id,
                Name = "Iphone 14"
            };

            _productStoreMock.Setup(x => x.GetProductByIdAsync(id))
                .ReturnsAsync(product);

            //Act
            var productService = await _productService.GetByIdAsync(id);

            //Assert
            Assert.Equal(id, productService.Id);
        }


        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull__WhenProductDoesNotExist()
        {
            //Arrange
            _productStoreMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var productService = await _productService.GetByIdAsync(It.IsAny<int>());

            //Assert
            Assert.Null(productService);
        }


        [Fact]
        public async void SortAsync_ShouldReturnListProducts_WhenProductsExist()
        {
            //Arrange
            int page = 1;
            int limit = 2;

            var products = new List<Product>()
            {
                new Product
                {  Id = 1, Name = "Iphone 14", Price = 1000M},
                new Product
                {  Id = 2, Name = "Iphone 14", Price = 899M },
                new Product
                {  Id = 3, Name = "Iphone 14", Price = 1200M }
            };

            var paginationList = products.Skip((page - 1) * limit).Take(limit).OrderBy(x => x.Price).ToList();

            _productStoreMock.Setup(x => x.SortProductAsync(page, limit))
                .ReturnsAsync(paginationList);

            //Act
            var productList = await _productService.SortAsync(page, limit);

            //Assert
            Assert.Equal(paginationList, productList);
        }


        [Fact]
        public async void SortAsync_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            //Arrange
            _productStoreMock.Setup(x => x.SortProductAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var productList = await _productService.SortAsync(It.IsAny<int>(), It.IsAny<int>());

            //Assert
            Assert.Null(productList);
        }
    }
}