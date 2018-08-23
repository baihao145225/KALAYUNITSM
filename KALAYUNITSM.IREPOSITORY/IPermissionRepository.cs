using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IPermissionRepository : IBaseRepository<Sys_Permission>
    {
        List<Sys_Permission> GetList();
        long GetChildCount(string parentid);
        bool Delete(params string[] primaryKeys);
    }
}
