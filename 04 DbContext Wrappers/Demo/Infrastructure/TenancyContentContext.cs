using Demo.Logging;
using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Infrastructure
{
    public abstract class TenancyContentContext
    {
        private LogSink SecurityLog { get; } 
        private ContentContext DbContext { get; }
        private UserRef AuthenticatedUserRef { get; }

        public TenancyContentContext(
            LogSink securityLog, ContentContext context, TenancyProvider tenancyProvider)
        {
            this.SecurityLog = securityLog;
            this.DbContext = context;
            this.AuthenticatedUserRef = tenancyProvider.AuthenticatedUser;
        }

        protected abstract Expression<Func<Product, bool>> GetProductsFilter(
            UserRef authenticatedUser);

        private Lazy<Expression<Func<Product, bool>>> ProductsFilter =>
            new Lazy<Expression<Func<Product, bool>>>(
                () => this.GetProductsFilter(this.AuthenticatedUserRef));

        private Lazy<Func<Product, bool>> ProductsPredicate =>
            new Lazy<Func<Product, bool>>(this.ProductsFilter.Value.Compile);

        protected IQueryable<Product> GetProducts() =>
            this.DbContext.QueryAll<Product>().Where(this.ProductsFilter.Value);

        protected IQueryable<FriendConnection> GetFriends() => this.DbContext
            .QueryAll<FriendConnection>()
            .Where(friend => friend.OwnerKey == this.AuthenticatedUserRef.Value);

        protected IQueryable<FriendConnection> GetReverseFriends() => this.DbContext
            .QueryAll<FriendConnection>()
            .Where(friend => friend.FriendKey == this.AuthenticatedUserRef.Value);

        protected IQueryable<TResult> GetEntities<TResult>() where TResult : class =>
            typeof(TResult) == typeof(Product) 
                ? this.GetProducts().OfType<TResult>()
            : typeof(TResult) == typeof(FriendConnection) 
                ? this.GetFriends().OfType<TResult>()
            : Enumerable.Empty<TResult>().AsQueryable();

        protected TResult FindEntity<TResult>(params object[] keyValues) where TResult : class =>
            keyValues.Length == 1 && keyValues[0] is int id ? this.FindEntity<TResult>(id)
            : default(TResult);

        private TResult FindEntity<TResult>(int id) where TResult : class =>
            typeof(TResult) == typeof(Product) 
                ? this.GetProducts().FirstOrDefault(product => product.Id == id) as TResult
            : typeof(TResult) == typeof(FriendConnection) 
                ? this.GetFriends().FirstOrDefault(friend => friend.Id == id) as TResult
            : default(TResult);

        protected EntityEntry<Product> AddProduct(Product obj)
        {
            if (obj is null) return default(EntityEntry<Product>);

            if (this.ProductsPredicate.Value(obj))
            {
                return this.DbContext.Add(obj);
            }
            else
            {
                this.SecurityLog.Append("UNAUTHORIZED PRODUCT INSERTION ATTEMPTED!");
                return default(EntityEntry<Product>);
            }
        }

        protected EntityEntry<Product> RemoveProduct(Product obj)
        {
            if (obj is null) return default(EntityEntry<Product>);

            if (this.ProductsPredicate.Value(obj))
            {
                return this.DbContext.Remove(obj);
            }
            else
            {
                this.SecurityLog.Append("UNAUTHORIZED PRODUCT DELETION ATTEMPTED!");
                return default(EntityEntry<Product>);
            }
        }

        protected EntityEntry<FriendConnection> AddFriend(FriendConnection obj)
        {
            if (obj is null) return default(EntityEntry<FriendConnection>);

            if (obj.OwnerKey == this.AuthenticatedUserRef.Value)
            {
                return this.DbContext.Add(obj);
            }
            else
            {
                this.SecurityLog.Append("UNAUTHORIZED FRIEND CONNECTION INSERTION ATTEMPTED!");
                return default(EntityEntry<FriendConnection>);
            }
        }

        protected EntityEntry<FriendConnection> RemoveFriend(FriendConnection obj)
        {
            if (obj is null) return default(EntityEntry<FriendConnection>);

            if (obj.OwnerKey == this.AuthenticatedUserRef.Value)
            {
                return this.DbContext.Remove(obj);
            }
            else
            {
                this.SecurityLog.Append("UNAUTHORIZED FRIEND CONNECTION REMOVAL ATTEMPTED!");
                return default(EntityEntry<FriendConnection>);
            }
        }

        protected int InternalSaveChanges() =>
            this.DbContext.SaveChanges();
    }
}
