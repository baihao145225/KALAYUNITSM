using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class OrderChkRepository : BaseRepository<Itsm_OrderChk>, IOrderChkRepository
    {
        public List<Itsm_OrderChk_Dto> GetDataList(string orderId)
        {
            try
            {
                ISugarQueryable<Itsm_OrderChk_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Itsm_OrderChk, Sys_User, Sys_User, Sys_User>((st, sc, sc1, sc2) => new object[] {   
              JoinType.Left,st.CreateUser==sc.Account,  
              JoinType.Left,st.CurrUser==sc1.Account,  
              JoinType.Left,st.NextUser==sc2.Account
            })
                .Where((st, sc, sc1, sc2) => st.OrderId == orderId)
                .Select((st, sc, sc1, sc2) => new Itsm_OrderChk_Dto { Id = st.Id, CurrUser = sc1.RealName,NextUser = sc2.RealName, CreateTime = st.CreateTime, Description = st.Description, FinishedTime = st.FinishedTime, CreateUser = sc.RealName, OrderChkStatus = st.OrderChkStatus }).OrderBy(st => st.CreateTime, OrderByType.Desc);
                return entitys.ToList();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
