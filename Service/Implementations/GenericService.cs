﻿using Repository.Implementation;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IUnitOfWork<T> _iUnitOfWork;

        public GenericService()
        {
            _iUnitOfWork = new UnitOfWork<T>();
        }

        public void Delete(int id)
        {
            try
            {
                _iUnitOfWork.ModelRepository.Delete(id);
                _iUnitOfWork.Save();
            }
            catch (Exception ex)
            {
            }
        }

        public List<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            List<T> _returnList = new List<T>();
            try
            {
                _returnList = _iUnitOfWork.ModelRepository.Get(filter, orderBy, includes);
            }
            catch (Exception ex)
            {
                _returnList = null;
            }
            return _returnList;
        }

        public T GetById(int id)
        {
            return _iUnitOfWork.ModelRepository.GetById(id);
        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            return _iUnitOfWork.ModelRepository.GetFirstOrDefault(filter, includes);
        }

        public void Insert(T entity)
        {
            _iUnitOfWork.ModelRepository.Insert(entity);
            _iUnitOfWork.Save();
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> _returnList = null;
            try
            {
                _returnList = _iUnitOfWork.ModelRepository.Query(filter, orderBy);
            }
            catch (Exception ex)
            {
                _returnList = null;
            }
            return _returnList;
        }

        public void Update(T entity)
        {
            _iUnitOfWork.ModelRepository.Update(entity);
            _iUnitOfWork.Save();
        }
    }
}
