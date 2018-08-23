using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ICustomerService : IBaseService<Commerce_Customer>
    {
        List<Commerce_Customer> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
