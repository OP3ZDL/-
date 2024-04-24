using Microsoft.EntityFrameworkCore;
using Проект.Model;
using Проект.Model.AuthApp;


namespace Проект.Reposytory
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<AuthUser>? AuthUsers { get; set; }
        public DbSet<Car>? Cars { get; internal set; }
    }
    
}
