using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IContactsRepository : IBaseRepository<Conf_Contacts>
    {
        IEnumerable<Conf_Contacts_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
    }
}
