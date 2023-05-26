using System.Linq.Expressions;

namespace WebApi.Models.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}