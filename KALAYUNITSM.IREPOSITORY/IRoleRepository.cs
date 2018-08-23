using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IRoleRepository : IBaseRepository<Sys_Role>
    {
        IEnumerable<Sys_Role_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
    }
}
