using Demo.Models.Content;
using System.Linq;

namespace Demo.Infrastructure
{
    public interface IContentReadContext : IReadDbContext
    {
        IQueryable<Product> Products => this.QueryAll<Product>();
        IQueryable<FriendConnection> Friends => this.QueryAll<FriendConnection>();
    }
}
