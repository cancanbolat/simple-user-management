using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Context;
using UserManagement.Domain.Repositories;

namespace UserManagement.Data.Repositories
{
    public class GenericRepository<TEntity, TSelect, TKey> : IGenericRepository<TEntity, TSelect, TKey>
        where TEntity : class, new()
        where TKey : IEquatable<TKey>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<List<TSelect>> GetListWithWhereAndInclude(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TSelect>> props,
            List<string> includes)
        {
            if (includes.Count > 0)
            {
                var query = _dbSet.AsQueryable();

                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

                return await _dbSet
                    .Where(filter)
                    .Select(props)
                    .ToListAsync();
            }

            return await _dbSet.Where(filter).Select(props).ToListAsync();
        }

        public async Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }
    }
}
