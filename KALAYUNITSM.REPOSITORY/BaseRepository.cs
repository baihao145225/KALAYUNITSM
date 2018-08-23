using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using SqlSugar;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.REPOSITORY
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ITEntity, new()
    {
        public IBase _dbbase { get; private set; }
        public BaseRepository()
        {
            this._dbbase = new SqlSugarDBConfig().db;
        }

        #region 数据操作
        public bool Insert(TEntity entity)
        {
            try
            {
                return _dbbase.SqlSugarClient.Insertable(entity).ExecuteCommand() > 0;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }

        }
        public object InsertReturnEntity(TEntity entity)
        {
            try
            {
                return _dbbase.SqlSugarClient.Insertable(entity).ExecuteReturnEntity();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }

        }
        public bool Insert(IEnumerable<TEntity> entitys)
        {
            try
            {
                _dbbase.SqlSugarClient.Ado.BeginTran();
                int count = _dbbase.SqlSugarClient.Insertable(entitys.ToArray()).ExecuteCommand();
                _dbbase.SqlSugarClient.Ado.CommitTran();
                return count > 0;
            }
            catch (Exception ex)
            {
                _dbbase.SqlSugarClient.Ado.RollbackTran();
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool UpdateById(object updateObj)
        {
            try
            {
                return _dbbase.SqlSugarClient.Updateable(updateObj).ExecuteCommand() > 0;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool UpdateNoReturn(TEntity entity)
        {
            try
            {
                return _dbbase.SqlSugarClient.Updateable(entity).ExecuteCommand() > 0;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Update(TEntity entity, Expression<Func<TEntity, TEntity>> columns = null)
        {
            try
            {
                if (columns == null)
                {
                    return _dbbase.SqlSugarClient.Updateable(entity).Where(true).ExecuteCommand() > 0;
                }
                else
                {
                    return _dbbase.SqlSugarClient.Updateable(entity).UpdateColumns(columns).Where(true).ExecuteCommand() > 0;
                }
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Update(List<TEntity> entitys)
        {
            try
            {
                _dbbase.SqlSugarClient.Ado.BeginTran();
                int count = _dbbase.SqlSugarClient.Updateable(entitys).Where(true).ExecuteCommand();
                _dbbase.SqlSugarClient.Ado.CommitTran();
                return true;
            }
            catch (Exception ex)
            {
                _dbbase.SqlSugarClient.Ado.RollbackTran();
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Update(object[] keys)
        {
            try
            {
                foreach (var key in keys)
                {
                    TEntity entity = _dbbase.SqlSugarClient.Queryable<TEntity>().InSingle(key);
                    int count = _dbbase.SqlSugarClient.Updateable(entity).Where(true).ExecuteCommand();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Update(TEntity entity, Expression<Func<TEntity, bool>> columns)
        {
            try
            {

                _dbbase.SqlSugarClient.Updateable(entity).UpdateColumns(columns);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Delete(TEntity entity)
        {
            try
            {
                return _dbbase.SqlSugarClient.Deleteable(entity).ExecuteCommand() > 0;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool Delete(object[] keys)
        {
            try
            {
                _dbbase.SqlSugarClient.Ado.BeginTran();
                int count = _dbbase.SqlSugarClient.Deleteable<TEntity>().In(keys).ExecuteCommand();
                _dbbase.SqlSugarClient.Ado.CommitTran();
                return true;
            }
            catch (Exception ex)
            {
                _dbbase.SqlSugarClient.Ado.RollbackTran();
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
     

        #endregion

        #region 数据查询

        /// <summary>
        /// 根据Id获取实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="queryState">默认返回正常数据,数据状态支持enum Flags位标志</param>
        /// <returns></returns>
        public TEntity Get(object primaryKey, ChkState queryState = ChkState.Normal)
        {
            try
            {
                var item = _dbbase.SqlSugarClient.Queryable<TEntity>().InSingle(primaryKey);
                if (item == null) return null;
                // return ((ChkState)item.ChkState & queryState) != 0 ? item : null; //使用Flags位运算
                return item;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

        /// <summary>
        /// 根据Id获取实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="queryState">默认返回正常数据,数据状态支持enum Flags位标志</param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> expression = null, ChkState queryState = ChkState.Normal)
        {
            try
            {
                var item = _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).First();
                if (item == null) return null;
                // return ((ChkState)item.ChkState & queryState) != 0 ? item : null; //使用Flags位运算
                return item;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }


        /// <summary>
        /// 获取数据表总项数
        /// </summary>
        /// <param name="expression">linq表达式 谓词</param>
        /// <returns></returns>
        public long GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            try
            {
                // var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
                return _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).Count();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

        /// <summary>
        /// 获取结果集第一条数据
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sortList"></param>
        /// <returns></returns>
        public TEntity GetFirst(Expression<Func<TEntity, bool>> expression = null, string sortList = null)
        {
            try
            {

                return _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).First();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

        /// <summary>
        /// 查看指定的数据是否存在
        /// </summary>
        /// <param name="expression">linq表达式 谓词</param>
        /// <returns></returns>
        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            var ct = this.GetCount(expression);
            return ct > 0;
        }

        /// <summary>
        /// 查看指定的数据是否存在
        /// </summary>
        /// <param name="expression">linq表达式 谓词</param>
        /// <returns></returns>
        public bool Exists(TEntity entity)
        {
            var item = _dbbase.SqlSugarClient.Queryable<TEntity>().First();
            return item != null;
        }
        /// <summary>
        /// 根据条件获取表数据
        /// </summary>
        /// <param name="expression">linq表达式</param>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null)
        {
            try
            {
                if (sortList == null)
                {
                    sortList = c => c.SortCode;
                }
                if (expression == null)
                {
                    return _dbbase.SqlSugarClient.Queryable<TEntity>().OrderBy(sortList, OrderByType.Desc).ToList();

                }
                return _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).OrderBy(sortList, OrderByType.Desc).ToList();

            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        /// <summary>
        /// 根据条件获取表数据
        /// </summary>
        /// <param name="expression">linq表达式</param>
        /// <returns></returns>
        public List<TEntity> GetListByArray(object[] keys, Expression<Func<TEntity, object>> sortList = null)
        {
            try
            {
                if (sortList == null)
                {
                    sortList = c => c.SortCode;
                }
                if (keys == null || keys.Count() == 0)
                {
                    return _dbbase.SqlSugarClient.Queryable<TEntity>().OrderBy(sortList, OrderByType.Desc).ToList();
                }
                else
                {
                    return _dbbase.SqlSugarClient.Queryable<TEntity>().In(keys).OrderBy(sortList, OrderByType.Desc).ToList();
                }
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        /// <summary>
        /// 根据条件获取表数据
        /// </summary>
        /// <param name="expression">linq表达式</param>
        /// <returns></returns>
        public List<TEntity> GetDataList(Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null)
        {
            try
            {
                if (sortList == null)
                {
                    sortList = c => c.SortCode;
                }
                if (expression == null)
                {
                    return _dbbase.SqlSugarClient.Queryable<TEntity>().OrderBy(sortList, OrderByType.Desc).ToList();

                }
                return _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).OrderBy(sortList, OrderByType.Desc).ToList();

            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public IEnumerable<TEntity> GetPageData(int pageIndex, int pageSize, out int outTotal,
            Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> sortList = null)
        {
            try
            {
                outTotal = 0;
                if (sortList == null)
                {
                    sortList = c => c.SortCode;
                }
                var entitys = _dbbase.SqlSugarClient.Queryable<TEntity>().Where(expression).OrderBy(sortList, OrderByType.Desc);
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public IEnumerable<TEntity> GetPageList(int pageIndex, int pageSize, int outTotal,
          object predicate = null, bool buffered = true, Expression<Func<TEntity, object>> sortList = null)
        {

            try
            {
                if (sortList == null)
                {
                    sortList = c => c.SortCode;
                }
                return _dbbase.SqlSugarClient.Queryable<TEntity>().OrderBy(sortList, OrderByType.Desc).ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public IEnumerable<TEntity> GetPageList(int pageIndex, int pageSize, out int outTotal, ISugarQueryable<TEntity> entitys, object predicate = null, bool buffered = true, Expression<Func<TEntity, object>> sortList = null)
        {
            try
            {
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        #endregion

        #region 辅助方法



        public static List<PropertyInfo> GetPropertyInfos(object obj)
        {
            if (obj == null)
            {
                return new List<PropertyInfo>();
            }
            List<PropertyInfo> properties;
            properties = obj.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).ToList();
            return properties;
        }
        #endregion
    }
}