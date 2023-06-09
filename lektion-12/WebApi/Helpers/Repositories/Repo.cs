﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Helpers.Repositories
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;
        }


        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _context.Set<TEntity>().AnyAsync(expression);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                return entity!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

    }
}
