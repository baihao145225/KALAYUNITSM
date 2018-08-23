using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IItemsDetailRepository : IBaseRepository<Sys_ItemsDetail>
    {
        IEnumerable<Sys_ItemsDetail_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string itemId);
    }
}
