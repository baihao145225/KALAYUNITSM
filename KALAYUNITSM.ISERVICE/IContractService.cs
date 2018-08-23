using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IContractService : IBaseService<Commerce_Contract>
    {
        List<Commerce_Contract_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
