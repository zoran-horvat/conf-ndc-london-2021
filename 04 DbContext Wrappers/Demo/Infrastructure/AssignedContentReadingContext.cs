using Demo.Logging;
using Demo.Models.Authentication;
using Demo.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Infrastructure
{
    public class AssignedContentReadingContext
        : TenancyContentContext, IContentReadContext
    {
        public AssignedContentReadingContext(
            LogSink securityLog, ContentContext context, TenancyProvider tenancyProvider)
            : base(securityLog, context, tenancyProvider)
        {
        }

        private IEnumerable<string> GetUserKeys(UserRef authenticatedUser) =>
            new[] { authenticatedUser.Value }.Concat(
                base.GetReverseFriends().Select(friend => friend.OwnerKey));

        protected override Expression<Func<Product, bool>> GetProductsFilter(UserRef authenticatedUser) =>
            product => this.GetUserKeys(authenticatedUser).Contains(product.OwnerKey);

        public IQueryable<TResult> QueryAll<TResult>() where TResult : class =>
            base.GetEntities<TResult>();

        public TResult Find<TResult>(params object[] keyValues) where TResult : class =>
            base.FindEntity<TResult>(keyValues);
    }
}
