using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class ContractRepository : BaseRepository<Commerce_Contract>, IContractRepository
    {
        public IEnumerable<Commerce_Contract_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Commerce_Contract_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Commerce_Contract, Sys_ItemsDetail, Commerce_Customer>((st, sc, sc2) => new object[] { 
                JoinType.Left, st.Type == sc.EnCode,
              JoinType.Left,st.CustomerId==sc2.Id
            })
                .Where((st, sc, sc2) => st.Name.Contains(keyWord))
                .Select((st, sc, sc2) => new Commerce_Contract_Dto { Id = st.Id, CustomerName = sc2.Name, TypeName = sc.Name, Name = st.Name, IsEnable = st.IsEnable, StartDate = st.StartDate.ToString(), EndDate = st.EndDate.ToString(), Expenses = st.Expenses });
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
