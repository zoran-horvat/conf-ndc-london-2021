using Demo.Logging;
using Demo.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users => base.Set<User>();

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForUser();
        }
    }
}
