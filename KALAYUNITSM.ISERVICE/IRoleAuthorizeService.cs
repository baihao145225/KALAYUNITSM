using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IRoleAuthorizeService : IBaseService<Sys_RoleAuthorize>
    {
        List<Sys_RoleAuthorize> GetList(string roleId);
        void Authorize(string roleId, params string[] perIds);
    }
}
