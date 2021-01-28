using Demo.Logging;
using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Infrastructure
{
    public class FullOwnershipContentContext :
        TenancyContentContext, IDbContext<Product>, 
        IDbContext<FriendConnection>, IContentReadContext
    {
        public FullOwnershipContentContext(
            LogSink securityLog, ContentContext context, TenancyProvider tenancyProvider)
            : base(securityLog, context, tenancyProvider)
        {
        }

        protected override Expression<Func<Product, bool>> GetProductsFilter(UserRef authenticatedUser) =>
            product => product.OwnerKey == authenticatedUser.Value;

        public IQueryable<TResult> QueryAll<TResult>() where TResult : class =>
            base.GetEntities<TResult>();

        public TResult Find<TResult>(params object[] keyValues) where TResult : class =>
            base.FindEntity<TResult>(keyValues);

        public EntityEntry<Product> Add(Product obj) =>
            base.AddProduct(obj);

        public EntityEntry<Product> Remove(Product obj) =>
            base.RemoveProduct(obj);

        public EntityEntry<FriendConnection> Add(FriendConnection obj) =>
            base.AddFriend(obj);

        public EntityEntry<FriendConnection> Remove(FriendConnection obj) =>
            base.RemoveFriend(obj);

        public int SaveChanges() =>
            base.InternalSaveChanges();
    }
}
