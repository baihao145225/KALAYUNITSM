using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IRoleAuthorizeRepository : IBaseRepository<Sys_RoleAuthorize>
    {
        List<Sys_RoleAuthorize> GetList();
        List<Sys_RoleAuthorize> GetList(string roleId);
        bool Delete(params string[] moduleIds);
    }
}
