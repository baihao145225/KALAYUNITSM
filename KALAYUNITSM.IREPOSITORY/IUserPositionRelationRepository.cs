using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IUserPositionRelationRepository : IBaseRepository<Sys_UserPositionRelation>
    {
        List<Sys_UserPositionRelation> GetList(string userid);
    }
}
