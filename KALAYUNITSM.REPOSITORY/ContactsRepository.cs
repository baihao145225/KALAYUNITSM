using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class ContactsRepository : BaseRepository<Conf_Contacts>, IContactsRepository
    {
        public IEnumerable<Conf_Contacts_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Conf_Contacts_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_Contacts, Commerce_Customer>((st, sc) => new object[] { 
                JoinType.Left, st.CustomerId == sc.Id
            })
                .Where((st, sc) => st.Name.Contains(keyWord))
                .Select((st, sc) => new Conf_Contacts_Dto { Id = st.Id, CustomerName = sc.Name, Name = st.Name, Email = st.Email, MobilePhone = st.MobilePhone, TelPhone = st.TelPhone, IsEnable = st.IsEnable });
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
