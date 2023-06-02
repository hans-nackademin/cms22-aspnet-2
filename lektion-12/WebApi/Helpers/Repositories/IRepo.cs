using System.Linq.Expressions;

namespace WebApi.Helpers.Repositories
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}