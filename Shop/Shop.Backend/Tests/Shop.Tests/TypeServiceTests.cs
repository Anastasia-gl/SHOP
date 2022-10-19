using Moq;
using Shop.Context.Model;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class TypeServiceTests
    {
        private readonly TypeService _typeService;
        private readonly Mock<ITypeStore> _typeStoreMock = new();

        public TypeServiceTests()
        {
            _typeService = new(_typeStoreMock.Object);
        }

        [Fact]
        public async Task GetNameTypeAsync_ReturnListType_WhenTypeExists()
        {
            //Arrange
            List<TypeProduct> list = new()
            {
                new TypeProduct{TypeId = 1, TypeName = "Smartphone"},
                new TypeProduct{TypeId =2, TypeName = "Computer"}
            };

            _typeStoreMock.Setup(x => x.GetTypesAsync())
                .ReturnsAsync(list);

            //Act
            var typeList = await _typeService.GetNameTypeAsync();

            //Assert
            Assert.Equal(list, typeList);
        }

        [Fact]
        public async Task GetNameTypeAsync_ReturnListType_WhenTypeDoesNotExists()
        {
            //Arrange
            _typeStoreMock.Setup(x => x.GetTypesAsync())
                .ReturnsAsync(() => null);

            //Act
            var typeList = await _typeService.GetNameTypeAsync();

            //Assert
            Assert.Null(typeList);
        }


        [Fact]
        public async Task SortOneAsync_ReturnListProduct_WhenProductThisTypeExists()
        {
            //Arrange
            string name = "Smartphone";

            List<TypeProduct> list = new()
            {
                new TypeProduct{TypeId = 1, TypeName = "Smartphone"}
            };

            var products = new List<Product>()
            {
                new Product
                {  Id = 1, Name = "Iphone 14", TypeId = 1 },
                new Product
                {  Id = 2, Name = "Iphone 14",  TypeId = 1 },
                new Product
                {  Id = 3, Name = "Iphone 14",  TypeId = 1 }
            };


            var type = list.FirstOrDefault(x => x.TypeName == name);

            var listProduct = products
                  .Where(x => x.TypeId == type.TypeId)
                  .ToList();

            _typeStoreMock.Setup(x => x.SortOneTypeAsync(name))
                .ReturnsAsync(listProduct);

            //Act
            var productList = await _typeService.SortOneAsync(name);

            //Assert
            Assert.Equal(listProduct, productList);
        }

        [Fact]
        public async Task SortOneAsync_ReturnListProduct_WhenProductThisTypeDoesNotExists()
        {
            //Arrange
            _typeStoreMock.Setup(x => x.SortOneTypeAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            //Act
            var productList = await _typeService.SortOneAsync(It.IsAny<string>());

            //Assert
            Assert.Null(productList);
        }


        public async Task GetCountAsync_ReturnCountListProduct_WhenProductThisTypeExists()
        {
            //Arrange
            string name = "Smartphone";

            List<TypeProduct> list = new()
            {
                new TypeProduct{TypeId = 1, TypeName = "Smartphone"}
            };

            var products = new List<Product>()
            {
                new Product
                {  Id = 1, Name = "Iphone 14", TypeId = 1 },
                new Product
                {  Id = 2, Name = "Iphone 14",  TypeId = 1 },
                new Product
                {  Id = 3, Name = "Iphone 14",  TypeId = 1 }
            };


            var type = list.FirstOrDefault(x => x.TypeName == name);

            var listProduct = products
                  .Where(x => x.TypeId == type.TypeId)
                  .Count();

            _typeStoreMock.Setup(x => x.GetTypeCountAsync(name))
                .ReturnsAsync(listProduct);

            //Act
            var productList = await _typeService.GetCountAsync(name);

            //Assert
            Assert.Equal(listProduct, productList);
        }
    }
}
