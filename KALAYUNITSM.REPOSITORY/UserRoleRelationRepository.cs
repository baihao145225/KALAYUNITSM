using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    class UserRoleRelationRepository : BaseRepository<Sys_UserRoleRelation>, IUserRoleRelationRepository
    {
        public List<Sys_UserRoleRelation> GetList(string userid)
        {
            return base.GetDataList(t => t.UserId == userid);
        }
    }
}
