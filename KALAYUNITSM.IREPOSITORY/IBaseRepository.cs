using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.IREPOSITORY
{

    public interface IBaseRepository<TEntity> where TEntity : class,ITEntity
    {
        bool Insert(TEntity entity);
        object InsertReturnEntity(TEntity entity);
        bool Insert(IEnumerable<TEntity> entitys);
        bool UpdateById(object id);
        bool UpdateNoReturn(TEntity entity);
        bool Update(TEntity entity, Expression<Func<TEntity, TEntity>> columns = null);
        bool Update(List<TEntity> entitys);
        bool Update(object[] keys);
        bool Update(TEntity entity, Expression<Func<TEntity, bool>> columns);          
        bool Delete(TEntity entity);
        bool Delete(object[] keys);
    
        TEntity Get(object primaryKey, ChkState queryState = ChkState.Normal);
        TEntity Get(Expression<Func<TEntity, bool>> expression = null, ChkState queryState = ChkState.Normal);
        long GetCount(Expression<Func<TEntity, bool>> expression = null);
        bool Exists(Expression<Func<TEntity, bool>> expression);
        bool Exists(TEntity entity);
        TEntity GetFirst(Expression<Func<TEntity, bool>> expression = null, string sortList = null);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null);
        List<TEntity> GetListByArray(object[] keys, Expression<Func<TEntity, object>> sortList = null);
        List<TEntity> GetDataList(Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null);
        IEnumerable<TEntity> GetPageData(int pageIndex, int pageSize, out  int outTotal,
            Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null);
        IEnumerable<TEntity> GetPageList(int pageIndex, int pageSize, int outTotal,
          object predicate = null, bool buffered = true, Expression<Func<TEntity, object>> sortList = null);
        IEnumerable<TEntity> GetPageList(int pageIndex, int pageSize, out  int outTotal, ISugarQueryable<TEntity> entitys, object predicate = null, bool buffered = true, Expression<Func<TEntity, object>> sortList = null);
    }
}
