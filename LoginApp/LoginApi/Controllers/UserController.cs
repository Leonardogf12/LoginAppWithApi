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

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll() => Ok(await _context.Users.ToListAsync());

        [HttpPost("Add")]
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

        [HttpPost("Delete")]
        public async Task<ActionResult<User>> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<ActionResult<User>> Update(User user)
        {
            if (user.Id == 0 || user == null) return BadRequest("Usuário não encontrado.");
          
            if(ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("Ocorreu um erro inesperado. Tente novamente em alguns instantes.");
        }

    }
}
