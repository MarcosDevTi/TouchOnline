using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.Domain;

namespace TouchOnline.Data
{
    public class ToContext : DbContext
    {
        public ToContext(DbContextOptions<ToContext> options) : base(options) { }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
