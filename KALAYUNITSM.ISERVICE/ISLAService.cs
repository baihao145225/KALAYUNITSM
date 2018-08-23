using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ISLAService : IBaseService<Conf_SLA>
    {
        List<Conf_SLA_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
