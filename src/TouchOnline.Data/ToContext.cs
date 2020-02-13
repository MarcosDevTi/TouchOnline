using Microsoft.EntityFrameworkCore;
using TouchOnline.Domain;
using TouchOnline.Domain.UserTracking;

namespace TouchOnline.Data
{
    public class ToContext : DbContext
    {
        public ToContext(DbContextOptions<ToContext> options) : base(options)
        {

        }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RecordedTracking> GetRecordeds { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
    }
}
