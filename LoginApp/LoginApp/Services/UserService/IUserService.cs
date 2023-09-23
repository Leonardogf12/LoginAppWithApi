using LoginApp.MVVM.Models;

namespace LoginApp.Services.UserService
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);
    }
}
