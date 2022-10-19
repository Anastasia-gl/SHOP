using Moq;
using Shop.Context.Model;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class HistoryServiceTests
    {
        private readonly HistoryService _historyService;
        private readonly Mock<IHistoryStore> _historyStoreMock = new();

        public HistoryServiceTests()
        {
            _historyService = new(_historyStoreMock.Object);
        }

        [Fact]
        public async Task AddAsync_ReturnHistoty_WhenAllArgumentsAreExist()
        {
            //Arrange
            HistoryDto historyDto = new();
            History history = new();

           _historyStoreMock.Setup(x=>x.AddFromBasketToHistoryAsync(It.IsAny<int>(), historyDto))
                .ReturnsAsync(history);

            //Act
            var actualHistory =  await _historyService.AddAsync(It.IsAny<int>(), historyDto);

            //Assert
            Assert.Equal(history ,actualHistory);
        }

        [Fact]
        public async Task GetAsync_ReturnListHistories_WhenAllArgumentsAreExist()
        {
            //Arrange
            int basketId = 1;
          
            List<History> history = new()
            {
                new History {HistoryId = 1, BasketId = 2},
                new History {HistoryId = 2, BasketId = 2}
            };

            var expectedList = history.Where(x => x.BasketId == basketId).ToList();

            _historyStoreMock.Setup(x => x.GetHistoryAsync(basketId))
                .ReturnsAsync(expectedList);

            //Act
            var actualHistory = await _historyService.GetAsync(basketId);

            //Assert
            Assert.Equal(expectedList, actualHistory);
        }
    }
}
