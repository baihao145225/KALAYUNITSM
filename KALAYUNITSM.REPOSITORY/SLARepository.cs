using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class SLARepository : BaseRepository<Conf_SLA>, ISLARepository
    {
        public IEnumerable<Conf_SLA_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Conf_SLA_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_SLA, Commerce_Contract>((st, sc) => new object[] { 
                JoinType.Left, st.ContractId == sc.Id
            })
                .Where((st, sc) => st.Name.Contains(keyWord))
                .Select((st, sc) => new Conf_SLA_Dto { Id = st.Id, ContractName = sc.Name, Name = st.Name, SLTsName = "" });
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
