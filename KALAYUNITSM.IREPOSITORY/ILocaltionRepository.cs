using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface ILocaltionRepository : IBaseRepository<Conf_Localtion>
    {
        IEnumerable<Conf_Localtion_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
    }
}
