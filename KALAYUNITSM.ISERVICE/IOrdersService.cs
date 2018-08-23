using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IOrdersService : IBaseService<Itsm_Orders>
    {
        Itsm_Orders_Dto GetOrder(string orderid);
        List<Itsm_Orders_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
