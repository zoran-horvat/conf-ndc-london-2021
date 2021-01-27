using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Demo.Infrastructure
{
    public interface IWriteDbContext<TEntity> where TEntity : class
    {

    }
}
