using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IOrdersRepository : IBaseRepository<Itsm_Orders>
    {
        Itsm_Orders_Dto GetOrder(string orderid);
        IEnumerable<Itsm_Orders_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
    }
}
