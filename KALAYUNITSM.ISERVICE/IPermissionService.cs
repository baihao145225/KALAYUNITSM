using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IPermissionService : IBaseService<Sys_Permission>
    {
        long GetChildCount(string parentid);
        List<Sys_Permission> GetListByUserId(string userid);
        List<Sys_Permission> GetPageList(int curr, int nums, out int count, string keyWord);
        bool ActionValidate(string account, string action);

    }
}
