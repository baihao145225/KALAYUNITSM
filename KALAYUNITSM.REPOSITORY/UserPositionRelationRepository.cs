using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    class UserPositionRelationRepository : BaseRepository<Sys_UserPositionRelation>, IUserPositionRelationRepository
    {
        public List<Sys_UserPositionRelation> GetList(string userid)
        {
            return base.GetDataList(t => t.UserId == userid);
        }
    }
}
