using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{

    public interface ICIGroupRepository : IBaseRepository<Conf_CIGroup>
    {
        List<Conf_CIGroup_Dto> GetListCount();
        IEnumerable<Conf_CIGroup_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string parentId);
    }
}
