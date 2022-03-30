using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Services;
using UserManagement.Service.Mappings;
using UserManagement.Shared.SharedDTOs;

namespace UserManagement.Service.Services
{
    public class GenericService<TEntity, TDto, TKey> : IGenericService<TEntity, TDto, TKey>
        where TEntity : class, new()

        where TKey : IEquatable<TKey>
    {

        private readonly IGenericRepository<TEntity, TDto, TKey> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(
            IGenericRepository<TEntity, TDto, TKey> genericRepository,
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public BaseResponse<TDto> Add(TDto entity)
        {
            TEntity newEntity = CustomObjectMapper.ObjectMapper.Mapper.Map<TEntity>(entity);

            _genericRepository.Add(newEntity);
            _unitOfWork.CommitChanges();

            TDto newDto = CustomObjectMapper.ObjectMapper.Mapper.Map<TDto>(newEntity);

            return BaseResponse<TDto>.Success(newDto, 200);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<TDto>> GetAll()
        {
            List<TDto> result = CustomObjectMapper.ObjectMapper.Mapper.Map<List<TDto>>(_genericRepository.GetAll());

            return BaseResponse<IEnumerable<TDto>>.Success(result, 200);
        }

        public BaseResponse<TDto> GetById(TKey id)
        {
            TEntity result = _genericRepository.GetById(id);

            if (result == null)
            {
                return BaseResponse<TDto>.Fail($"{nameof(id)} not found", 404, true);
            }

            return BaseResponse<TDto>.Success(CustomObjectMapper.ObjectMapper.Mapper.Map<TDto>(result), 200);
        }

        public BaseResponse<List<TDto>> GetListWithWhereAndInclude(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TDto>> props,
            List<string> includes)
        {
            List<TDto> includedResult = _genericRepository.GetListWithWhereAndInclude(filter, props, includes);

            return BaseResponse<List<TDto>>.Success(includedResult, 200);
        }

        public BaseResponse<List<TDto>> GetListWithWhereAndInclude(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TDto>> props, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<NoDataDto> Remove(TKey id)
        {
            TEntity isExistEntity = _genericRepository.GetById(id);

            if (isExistEntity == null)
            {
                return BaseResponse<NoDataDto>.Fail($"{nameof(id)} not found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);

            _unitOfWork.Save();
            return BaseResponse<NoDataDto>.Success(204);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TEntity> SingleOrDefaultWithInclude<T>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T>> props, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TEntity> SingleOrDefaultWithInclude<T>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T>> props, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<NoDataDto> Update(TDto entity, TKey id)
        {
            TEntity isExistEntity = _genericRepository.GetById(id);

            if (isExistEntity == null)
            {
                return BaseResponse<NoDataDto>.Fail($"{nameof(id)} not found", 404, true);
            }

            var updateEntity = CustomObjectMapper.ObjectMapper.Mapper.Map<TEntity>(entity);

            _genericRepository.Update(updateEntity);

            _unitOfWork.Save();
            return BaseResponse<NoDataDto>.Success(204);
        }
    }
}
