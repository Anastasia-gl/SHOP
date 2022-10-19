using Shop.Context.Model;
using Shop.Domain.Dtos;

namespace Shop.Domain.Interface.Service
{
    public interface IUserService
    {
        public Task<UserProfile> Create(RegisterDto user);

        public Task<UserProfile> GetByEmail(string email);

        public Task<UserProfile> GetById(int id);
    }
}
