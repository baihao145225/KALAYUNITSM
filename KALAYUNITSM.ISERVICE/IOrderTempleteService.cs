using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IOrderTempleteService : IBaseService<Itsm_OrderTemplete>
    {
        List<Itsm_OrderTemplete> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
