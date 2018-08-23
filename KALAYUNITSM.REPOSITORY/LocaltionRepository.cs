using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class LocaltionRepository : BaseRepository<Conf_Localtion>, ILocaltionRepository
    {
        public IEnumerable<Conf_Localtion_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Conf_Localtion_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_Localtion, Commerce_Customer>((st, sc) => new object[] { 
                JoinType.Left, st.CustomerId == sc.Id 
            })
                .Where((st, sc) => st.Name.Contains(keyWord))
                .Select((st, sc) => new Conf_Localtion_Dto { Id = st.Id, CustomerName = sc.Name, Name = st.Name, Address = st.Address, IsEnable = st.IsEnable, SortCode = st.SortCode });
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
