using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class PermissionRepository : BaseRepository<Sys_Permission>, IPermissionRepository
    {
        public List<Sys_Permission> GetList()
        {
            return  base.GetDataList();
        }
        public long GetChildCount(string parentid)
        {
            return base.GetCount(c => c.ParentId == parentid);
        }
        public bool Delete(params string[] primaryKeys)
        {
            return base.Delete(primaryKeys);
        }
    }
}
