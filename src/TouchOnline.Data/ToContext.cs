using Microsoft.EntityFrameworkCore;
using TouchOnline.Domain;

namespace TouchOnline.Data
{
    public class ToContext : DbContext
    {
        public ToContext(DbContextOptions<ToContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
