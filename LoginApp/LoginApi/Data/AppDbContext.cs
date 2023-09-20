using LoginApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
