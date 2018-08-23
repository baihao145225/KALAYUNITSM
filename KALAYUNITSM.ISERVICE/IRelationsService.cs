
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IRelationsService : IBaseService<Conf_Relations>
    {
        List<Conf_Relations> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
