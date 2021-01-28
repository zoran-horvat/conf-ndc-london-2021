using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class EntireContext : DbContext
    {
        public EntireContext(DbContextOptions<EntireContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForUser();
            modelBuilder.ForProduct();
            modelBuilder.ForFriendConnection();

            UserRef me = new UserRef("DFE27E47-2BBE-4C7D-B419-25AC7835881F");
            UserRef neighbor = new UserRef("C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55");

            modelBuilder.Entity<User>().HasData(
                new User(1, "me", me),
                new User(2, "neighbor", neighbor));

            modelBuilder.Entity<Product>().HasData(
                new Product(1, "one", me),
                new Product(2, "two", me),
                new Product(3, "three", me),
                new Product(4, "square", neighbor),
                new Product(5, "pointy", neighbor),
                new Product(6, "round", neighbor));

            modelBuilder.Entity<FriendConnection>().HasData(
                new FriendConnection(1, neighbor, me));
        }
    }
}
