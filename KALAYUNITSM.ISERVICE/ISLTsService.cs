using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ISLTsService : IBaseService<Conf_SLTs>
    {
        List<Conf_SLTs> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
