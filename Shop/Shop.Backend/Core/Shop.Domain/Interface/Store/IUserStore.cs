using Shop.Context.Model;
using Shop.Domain.Dtos;

namespace Shop.Domain.Interface.Store
{
    public interface IUserStore
    {
        public Task<UserProfile> AddUser(RegisterDto user);

        public Task<UserProfile> GetUserByEmail(string email);

        public Task<UserProfile> GetUserById(int id);
    }
}
