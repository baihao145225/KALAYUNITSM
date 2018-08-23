using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ILocaltionService : IBaseService<Conf_Localtion>
    {
        List<Conf_Localtion_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
