using LoginApi.Data;
using LoginApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByCredentials(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email!.ToLower()
                                                                .Equals(email!.ToLower())
                                                                && x.Password == password);
        }
    }
}
