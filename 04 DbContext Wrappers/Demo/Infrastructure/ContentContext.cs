using Microsoft.EntityFrameworkCore.ChangeTracking;
using Demo.Logging;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure
{
    public class ContentContext : 
        DbContext, IDbContext<Product>, 
        IDbContext<FriendConnection>, IContentReadContext
    {
        public IQueryable<Product> Products => base.Set<Product>();
        public IQueryable<FriendConnection> Friends => base.Set<FriendConnection>();

        private LogSink Logger { get; }

        public ContentContext(DbContextOptions<ContentContext> options, LogSink logger) : base(options)
        {
            this.Logger = logger;
        }

        public IQueryable<TResult> QueryAll<TResult>() where TResult : class =>
            base.Set<TResult>().AsQueryable();

        public EntityEntry<Product> Add(Product obj) =>
            base.Set<Product>().Add(obj);

        public EntityEntry<Product> Remove(Product obj) =>
            base.Set<Product>().Remove(obj);

        public EntityEntry<FriendConnection> Add(FriendConnection obj) =>
            base.Set<FriendConnection>().Add(obj);

        public EntityEntry<FriendConnection> Remove(FriendConnection obj) =>
            base.Set<FriendConnection>().Remove(obj);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.Logger.AppendMethodCalled();
            modelBuilder.ForProduct();
            modelBuilder.ForFriendConnection();
        }
    }
}
