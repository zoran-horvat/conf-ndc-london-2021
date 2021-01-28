using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    static class EntityBuilderExtensions
    {
        internal static void ForUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "Authentication").HasKey(user => user.Id);

            modelBuilder.Entity<User>().Property(user => user.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(obj => obj.Key).IsRequired();
            modelBuilder.Entity<User>().Ignore(obj => obj.Reference);

            modelBuilder.Entity<User>().HasIndex(obj => obj.UserName).IsUnique(true);
        }

        internal static void ForProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", "Content").HasKey(product => product.Id);

            modelBuilder.Entity<Product>().Property(product => product.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.OwnerKey).IsRequired();
        }

        internal static void ForFriendConnection(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendConnection>().ToTable("Friends", "Content").HasKey(friend => friend.Id);

            modelBuilder.Entity<FriendConnection>().Property(friend => friend.OwnerKey).IsRequired();
            modelBuilder.Entity<FriendConnection>().Property(friend => friend.FriendKey).IsRequired();
        }
    }
}