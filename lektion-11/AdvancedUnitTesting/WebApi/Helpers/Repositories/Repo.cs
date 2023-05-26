using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Helpers.Contexts;
using WebApi.Models.Interfaces;

namespace WebApi.Helpers.Repositories
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        #region constructors and private fields

        private readonly DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;
        }

        #endregion

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            return null!;
        }


        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            if (entities.Any())
                return entities;

            return null!;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
                return entity;

            return null!;
        }
    }
}
