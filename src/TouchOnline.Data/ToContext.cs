using Microsoft.EntityFrameworkCore;
using TouchOnline.Data.Maps;
using TouchOnline.Domain;
using TouchOnline.Domain.UserTracking;

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
        public DbSet<RecordedTracking> GetRecordeds {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordedTrackingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
