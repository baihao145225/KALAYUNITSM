using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ICIService : IBaseService<Conf_CI>
    {
        List<Conf_CI_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string ciGroupId);
    }
}
