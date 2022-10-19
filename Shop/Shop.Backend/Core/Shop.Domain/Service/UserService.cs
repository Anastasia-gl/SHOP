using Shop.Context.Model;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;

namespace Shop.Domain.Service
{
    public class UserService : IUserService
    {

        private readonly IUserStore _store;

        public UserService(IUserStore store)
        {
            _store = store;
        }

        public async Task<UserProfile> Create(RegisterDto user)
        {
            if (user != null)
            {
                return await _store.AddUser(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<UserProfile> GetByEmail(string email)
        {
            var user = await _store.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<UserProfile> GetById(int id)
        {
            var user = await _store.GetUserById(id);

            if(user == null)
            {
                return user;
            }

            return user;
        }
    }
}
