using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class ServiceCatalogRepository : BaseRepository<Conf_ServiceCatalog>, IServiceCatalogRepository
    {
        public Conf_ServiceCatalog_Dto Get(string Id)
        {
            try
            {
                ISugarQueryable<Conf_ServiceCatalog_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_ServiceCatalog, Sys_ItemsDetail>((st, sc) => new object[] { 
                JoinType.Left, st.Type == sc.EnCode
            })
                .Where((st, sc) => st.Id == Id)
                .Select((st, sc) => new Conf_ServiceCatalog_Dto { Id = st.Id, EnCode=st.EnCode, Name = st.Name, TypeName = sc.Name, Delivery = st.Delivery, Level = st.Level, Time = st.Time, Description = st.Description, Frequency = st.Frequency, CreateTime = st.CreateTime, IsEnable = st.IsEnable }).OrderBy(st => st.CreateTime, OrderByType.Desc);
                return entitys.First();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public List<Conf_ServiceCatalog_Dto> GetList(string keyWord, string parentId)
        {
            //return base.GetDataList(expression); 
            try
            {
                ISugarQueryable<Conf_ServiceCatalog_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_ServiceCatalog, Sys_ItemsDetail>((st, sc) => new object[] { 
                JoinType.Left, st.Type == sc.EnCode
            })
                .Where((st, sc) => st.Name.Contains(keyWord) && st.ParentId == parentId)
                .Select((st, sc) => new Conf_ServiceCatalog_Dto { Id = st.Id, EnCode = st.EnCode, Name = st.Name, TypeName = sc.Name, Delivery = st.Delivery, Level = st.Level, Time = st.Time, Description = st.Description, Frequency = st.Frequency, CreateTime = st.CreateTime, IsEnable = st.IsEnable }).OrderBy(st => st.CreateTime, OrderByType.Desc);
                return entitys.ToList();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
