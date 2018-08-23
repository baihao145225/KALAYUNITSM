using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ILogService : IBaseService<Sys_Log>
    {
        List<Sys_Log> GetPageList(int curr, int nums, out int count, string keyWord);
    }
}
