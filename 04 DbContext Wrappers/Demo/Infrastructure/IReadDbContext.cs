using System.Linq;

namespace Demo.Infrastructure
{
    public interface IReadDbContext
    {
        IQueryable<TResult> QueryAll<TResult>() where TResult : class;
        TResult Find<TResult>(params object[] keyValues) where TResult : class;
    }
}
