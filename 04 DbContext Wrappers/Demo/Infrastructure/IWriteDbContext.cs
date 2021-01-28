using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Demo.Infrastructure
{
    public interface IWriteDbContext<TEntity> where TEntity : class
    {
        EntityEntry<TEntity> Add(TEntity obj);
        EntityEntry<TEntity> Remove(TEntity obj);
        int SaveChanges();
    }
}
