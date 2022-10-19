using Moq;
using Shop.Context.Model;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;

namespace Shop.Domain.Tests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserStore> _userStoreMock = new();

        public UserServiceTests()
        {
            _userService = new(_userStoreMock.Object);
        }


        [Fact]
        public async Task Add_ReturnUser_WhenUserExist()
        {
            //Arrange
            RegisterDto register = new();
            UserProfile user = new();

            register.Name = "Asnastasia";
            register.Email = "an@mail.com";
            register.Password = "123";

            user.UserId = 1;
            user.UserName = register.Name;
            user.Email = register.Email;
            user.Password = register.Password;

            _userStoreMock.Setup(x => x.AddUser(register))
                .ReturnsAsync(user);

            //Act
            var registredUser = await _userService.Create(register);

            //Assert
            Assert.Equal(user, registredUser);
        }

        [Fact]
        public async Task Add_ReturnUser_WhenUserDoesNotExist()
        {
            //Arrange
            _userStoreMock.Setup(x => x.AddUser(It.IsAny<RegisterDto>()))
                .ReturnsAsync(() => null);

            //Act
            var registredUser = await _userService.Create(new RegisterDto());

            //Assert
            Assert.Null(registredUser);
        }

        [Fact]
        public async Task GetById_ReturnUser_WhenUserExist()
        {
            //Arrange
            List<UserProfile> users = new()
            {
                new UserProfile
                {
                     UserId = 1,
                     UserName = "Asnastasia",
                     Email = "an@mail.com",
                     Password = "123"
                }
            };

            var user = users.FirstOrDefault(x => x.UserId == 1);

            _userStoreMock.Setup(x => x.GetUserById(1))
                        .ReturnsAsync(user);

            //Act
            var userById = await _userService.GetById(1);

            //Assert
            Assert.Equal(user, userById);
        }

        [Fact]
        public async Task GetById_ReturnUser_WhenUserDoesNotExist()
        {
            //Arrange
            _userStoreMock.Setup(x => x.GetUserById(It.IsAny<int>()))
                        .ReturnsAsync(() => null);

            //Act
            var userById = await _userService.GetById(It.IsAny<int>());

            //Assert
            Assert.Null(userById);
        }

        [Fact]
        public async Task GetByEmail_ReturnUser_WhenUserExist()
        {
            //Arrange
            List<UserProfile> users = new()
            {
                new UserProfile
                {
                     UserId = 1,
                     UserName = "Asnastasia",
                     Email = "an@mail.com",
                     Password = "123"
                }
            };

            var user = users.FirstOrDefault(x => x.Email == "an@mail.com");

            _userStoreMock.Setup(x => x.GetUserByEmail("an@mail.com"))
                        .ReturnsAsync(user);

            //Act
            var userById = await _userService.GetByEmail("an@mail.com");

            //Assert
            Assert.Equal(user, userById);
        }

        [Fact]
        public async Task GetByEmail_ReturnUser_WhenUserDoesNotExist()
        {
            //Arrange
            _userStoreMock.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
                        .ReturnsAsync(() => null);

            //Act
            var userById = await _userService.GetByEmail(It.IsAny<string>());

            //Assert
            Assert.Null(userById);
        }
    }
}
