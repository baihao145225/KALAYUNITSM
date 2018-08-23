using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class RoleAuthorizeRepository : BaseRepository<Sys_RoleAuthorize>, IRoleAuthorizeRepository
    {

        public List<Sys_RoleAuthorize> GetList()
        {
            return base.GetDataList();
        }
        public List<Sys_RoleAuthorize> GetList(string roleId)
        {
            return base.GetDataList(t => t.RoleId == roleId);
        }
        public bool Delete(params string[] moduleIds)
        {
            return base.Delete(moduleIds);
        }

    }
}
