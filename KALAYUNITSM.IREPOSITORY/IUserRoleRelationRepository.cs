using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IUserRoleRelationRepository : IBaseRepository<Sys_UserRoleRelation>
    {
        List<Sys_UserRoleRelation> GetList(string userid);

    }
}
