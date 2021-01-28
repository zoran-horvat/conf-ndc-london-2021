namespace Demo.Infrastructure
{
    public interface IDbContext<TEntity> : IReadDbContext, IWriteDbContext<TEntity>
        where TEntity : class
    {
    }
}
