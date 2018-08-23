using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class CIRepository : BaseRepository<Conf_CI>, ICIRepository
    {
        public IEnumerable<Conf_CI_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string ciGroupId)
        {
            try
            {
                ISugarQueryable<Conf_CI_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_CI, Conf_CIGroup, Conf_Localtion, Conf_Contacts, Commerce_Customer>((st, sc, sc2, sc3, sc4) => new object[] { 
                JoinType.Left, st.CIGroupId == sc.Id,
              JoinType.Left,st.LocaltionId==sc2.Id,
              JoinType.Left,st.ContactsId==sc3.Id,
              JoinType.Left,st.CustomerId==sc4.Id
            })
                .Where((st, sc, sc2, sc3, sc4) => st.Name.Contains(keyWord) && st.CIGroupId == ciGroupId)
                .Select((st, sc, sc2, sc3, sc4) => new Conf_CI_Dto { Id = st.Id, Label = st.Label, Name = st.Name, CIGroupName = sc.Name, LocaltionName = sc2.Name, UsingContactsName = sc3.Name, UsingCustomerName = sc4.Name, CreateTime = st.CreateTime, Description = st.Description, IsEnable = st.IsEnable });
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
