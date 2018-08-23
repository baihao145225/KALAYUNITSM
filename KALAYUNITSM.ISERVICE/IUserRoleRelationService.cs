using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IUserRoleRelationService : IBaseService<Sys_UserRoleRelation>
    {
        List<Sys_UserRoleRelation> GetList(string userId);
        void SetRole(string userId, params string[] roleIds);
    }
}
