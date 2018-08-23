using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class OrdersRepository : BaseRepository<Itsm_Orders>, IOrdersRepository
    {
        public Itsm_Orders_Dto GetOrder(string orderid)
        {
            try
            {
                return _dbbase.SqlSugarClient.Queryable<Itsm_Orders, Conf_CI, Conf_Contacts, Sys_User, Commerce_Contract, Itsm_OrderChk>((st, sc, sc1, sc2, sc3, sc4) => new object[] { 
                JoinType.Left, st.CIId == sc.Id, 
              JoinType.Left,st.ContactsId==sc1.Id, 
              JoinType.Left,st.CreateUser==sc2.Account, 
              JoinType.Left,st.ContractId==sc3.Id, 
              JoinType.Left,st.OrderId==sc4.OrderId && sc4.OrderChkStatus==OrdersStatusEnums.已解决
            })
                .Where((st, sc, sc1, sc2, sc3, sc4) => st.OrderId == orderid)
                .Select((st, sc, sc1, sc2, sc3, sc4) => new Itsm_Orders_Dto { Id = st.Id, Name = st.Name, OrderId = st.OrderId, ContactsName = sc1.Name, ContractName = sc3.Name, PriorityName = st.PriorityId, CIName = sc.Name, AttachmentFile = st.AttachmentFile, Solution = sc4.Solution, RegisterTime = st.RegisterTime, FinishTime = st.FinishTime, StatusCode = st.StatusCode, Status= (int)st.StatusCode, CreateTime = st.CreateTime, Description = st.Description, IsEnable = st.IsEnable, CreateUser = sc2.RealName }).First();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public IEnumerable<Itsm_Orders_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Itsm_Orders_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Itsm_Orders, Conf_CI, Conf_Contacts, Sys_User>((st, sc, sc1, sc2) => new object[] { 
                JoinType.Left, st.CIId == sc.Id, 
              JoinType.Left,st.ContactsId==sc1.Id, 
              JoinType.Left,st.CurrUser==sc2.Account
            })
                .Where((st, sc, sc1, sc2) => st.Name.Contains(keyWord))
                .Select((st, sc, sc1, sc2) => new Itsm_Orders_Dto { Id = st.Id, Name = st.Name, OrderId = st.OrderId, ContactsName = sc1.Name, PriorityName = st.PriorityId, RegisterTime = st.RegisterTime, FinishTime = st.FinishTime, StatusCode = st.StatusCode, CurrUser = st.CurrUser, CurrUserName = sc2.RealName, CreateTime = st.CreateTime, Description = st.Description, IsEnable = st.IsEnable }).OrderBy(st => st.CreateTime, OrderByType.Desc);
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
