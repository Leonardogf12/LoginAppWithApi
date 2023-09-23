using LoginApi.Models;
using System.Security.Claims;

namespace LoginApi.Service
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
