using Microsoft.EntityFrameworkCore.ChangeTracking;
using Demo.Logging;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure
{
    public class ContentContext : DbContext
    {
        public DbSet<Product> Products => base.Set<Product>();
        public DbSet<FriendConnection> Friends => base.Set<FriendConnection>();

        private LogSink Logger { get; }
        private string AuthenticatedUserKey { get; }
        private IEnumerable<string> AccessUserKeys =>
            new[] { this.AuthenticatedUserKey }.Concat(
                this.Friends
                    .Where(friend => friend.FriendKey == this.AuthenticatedUserKey)
                    .Select(friend => friend.OwnerKey));

        public ContentContext(
            DbContextOptions<ContentContext> options, LogSink logger, 
            TenancyProvider tenancyProvider) : base(options)
        {
            this.Logger = logger;
            this.AuthenticatedUserKey = tenancyProvider.AuthenticatedUser.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.Logger.AppendMethodCalled();
            modelBuilder.ForProduct();
            modelBuilder.ForFriendConnection();

            modelBuilder.Entity<Product>().HasQueryFilter(
                product => this.AccessUserKeys.Contains(product.OwnerKey));
        }
    }
}
