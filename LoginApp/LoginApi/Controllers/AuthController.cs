using LoginApi.Service;
using LoginApi.Service.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {        
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;               
        }

        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.GetUserByCredentials(email, password);

            if (user == null) return Unauthorized();

            var token = _tokenService.Generate(user);
            
            user.Token = token;
            
            return Ok(user);
        }
    }
}
