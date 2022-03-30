using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserManagement.Domain.Repositories
{
    public interface IGenericRepository<TEntity, TSelect, TKey>
        where TEntity : class, new()
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> GetById(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task<List<TSelect>> GetListWithWhereAndInclude(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TSelect>> props, List<string> includes);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
        Task Update(TEntity entity);
    }
}
