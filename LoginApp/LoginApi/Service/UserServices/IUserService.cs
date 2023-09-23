using LoginApi.Models;

namespace LoginApi.Service.UserServices
{
    public interface IUserService
    {       
        Task<User> GetUserByCredentials(string email, string password);
    }
}
