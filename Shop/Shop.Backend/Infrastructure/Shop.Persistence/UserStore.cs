using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Store;

namespace Shop.Persistence
{
    public class UserStore : IUserStore
    {
        private readonly ShopContext _context;

        public UserStore(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> AddUser(RegisterDto user)
        {
            UserProfile profile = new();

            profile.UserName = user.Name;
            profile.Email = user.Email;
            profile.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.UserProfiles.Add(profile);

            await _context.SaveChangesAsync();
            return (profile);
        }

        public async Task<UserProfile> GetUserByEmail(string email)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserProfile> GetUserById(int id)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
