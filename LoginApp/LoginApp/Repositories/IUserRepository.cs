using LoginApp.MVVM.Models;

namespace LoginApp.Repositories
{
    public interface IUserRepository
    {      
        Task<User> Login(string email, string password);
    }
}
