using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.DATA;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.REPOSITORY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class,ITEntity, new()
    {
        private IBaseRepository<TEntity> _baseDal;
        public BaseService()
        {
            if (_baseDal == null)
            {
                _baseDal = new BaseRepository<TEntity>();
            }
        }
        public bool Exists(TEntity entity)
        {
            return _baseDal.Exists(entity);
        }
        public TEntity Get(object primaryKey)
        {
            return _baseDal.Get(primaryKey);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _baseDal.Get(expression);
        }
        public TEntity GetFirst(Expression<Func<TEntity, bool>> expression)
        {
            return _baseDal.GetFirst(expression);
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return _baseDal.GetList(expression);
        }
        public List<TEntity> GetList(object[] keys)
        {
            return _baseDal.GetListByArray(keys);
        }
        public virtual object Insert(TEntity entity)
        {
            entity.CreateTime = System.DateTime.Now;
            entity.SortCode = entity.SortCode == null ? 10000 : entity.SortCode;
            entity.ChkState = 1;
            return _baseDal.Insert(entity);
        }
        public virtual object InsertReturnEntity(TEntity entity)
        {
            entity.CreateTime = System.DateTime.Now;
            entity.SortCode = entity.SortCode == null ? 10000 : entity.SortCode;
            entity.ChkState = 1;
            return _baseDal.InsertReturnEntity(entity);
        }
        public virtual bool Update(TEntity entity)
        {
            return _baseDal.UpdateNoReturn(entity);
        }
        public virtual bool Update(TEntity entity, Expression<Func<TEntity, TEntity>> columns = null)
        {
            return _baseDal.Update(entity);
        }
        public virtual bool Update(TEntity entity, Expression<Func<TEntity, bool>> columns)
        {
            return _baseDal.Update(entity, columns);
        }
        public virtual bool Update(object[] primaryKey)
        {
            return _baseDal.Update(primaryKey);
        }
        public virtual bool Delete(object[] primaryKey)
        {
            return _baseDal.Delete(primaryKey);
        }
    }
}
