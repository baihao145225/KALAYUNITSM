using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KALAYUNITSM.ISERVICE
{
    public partial interface IBaseService<TEntity> where TEntity : class
    {
        bool Exists(TEntity model);
        TEntity Get(object primaryKey);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        TEntity GetFirst(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
        List<TEntity> GetList(object[] keys);
        object Insert(TEntity entity);
        object InsertReturnEntity(TEntity entity);
        bool Update(TEntity entity);
        bool Update(TEntity entity, Expression<Func<TEntity, TEntity>> columns = null);
        bool Update(TEntity entity, Expression<Func<TEntity, bool>> columns);
        bool Update(object[] primaryKey);
        bool Delete(object[] primaryKey);
    }
}
