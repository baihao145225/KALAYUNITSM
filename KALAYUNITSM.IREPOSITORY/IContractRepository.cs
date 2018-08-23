using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IContractRepository : IBaseRepository<Commerce_Contract>
    {
        IEnumerable<Commerce_Contract_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
    }
}
