using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class CIGroupRepository : BaseRepository<Conf_CIGroup>, ICIGroupRepository
    {
        public IEnumerable<Conf_CIGroup_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string parentId)
        {
            try
            {
                ISugarQueryable<Conf_CIGroup_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_CIGroup, Conf_CIGroup>((st, sc) => new object[] { 
                JoinType.Left, st.ParentId == sc.Id
            })
                .Where((st, sc) => st.Name.Contains(keyWord) && st.ParentId == parentId)
                .Select((st, sc) => new Conf_CIGroup_Dto { Id = st.Id, EnCode = st.EnCode, Name = st.Name, ParentName = sc.Name, Url = st.Url, Description = st.Description, IsEnable = st.IsEnable });
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public List<Conf_CIGroup_Dto> GetListCount()
        {
            try
            {
                ISugarQueryable<Conf_CIGroup_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_CIGroup, Conf_CI>((st, sc) => new object[] { 
                JoinType.Left, st.Id == sc.CIGroupId
            })
                .Select((st, sc) => new Conf_CIGroup_Dto { Id = st.Id, Name = st.Name, Count = SqlFunc.AggregateCount(sc.Id), ParentId = st.ParentId }).GroupBy(st => st.Id).GroupBy(st => st.Name).GroupBy(st => st.ParentId);
                return entitys.ToList();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
