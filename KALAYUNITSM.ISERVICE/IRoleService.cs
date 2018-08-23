using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IRoleService : IBaseService<Sys_Role>
    {
        List<Sys_Role_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);

    }
}
