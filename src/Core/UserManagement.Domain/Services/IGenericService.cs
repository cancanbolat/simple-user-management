using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UserManagement.Shared.SharedDTOs;

namespace UserManagement.Domain.Services
{
    public interface IGenericService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TKey : IEquatable<TKey>
    {
        BaseResponse<TDto> GetById(TKey id);
        BaseResponse<IEnumerable<TDto>> GetAll();
        BaseResponse<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        BaseResponse<TEntity> SingleOrDefaultWithInclude<T>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T>> props, List<string> includes);
        BaseResponse<List<TDto>> GetListWithWhereAndInclude(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> props, List<string> includes);
        BaseResponse<TDto> Add(TDto entity);
        void AddRange(IEnumerable<TEntity> entities);
        BaseResponse<NoDataDto> Remove(TKey id);
        void RemoveRange(IEnumerable<TEntity> entities);
        BaseResponse<NoDataDto> Update(TDto entity, TKey id);
    }
}
