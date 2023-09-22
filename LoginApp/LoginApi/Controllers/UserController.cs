using LoginApi.Data;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll() => Ok(await _context.Users.ToListAsync());

        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest("Invalid request");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email!.ToLower().Equals(email.ToLower()) 
                                                                && x.Password == password); 

            return user != null ? Ok(user) : NotFound("User ot found");            
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {
            if (user != null)
            {
                var result = _context.Users.Add(user).Entity;
                await _context.SaveChangesAsync();

                return Ok(result);
            }

            return BadRequest("Invalid request");
        }



    }
}
