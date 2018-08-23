using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface ICIRepository : IBaseRepository<Conf_CI>
    {
        IEnumerable<Conf_CI_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string ciGroupId);
    }
}
