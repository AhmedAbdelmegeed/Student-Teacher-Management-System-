using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // User & Roles
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Courses & Students
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        // Courses & Teachers
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }
    }
}
