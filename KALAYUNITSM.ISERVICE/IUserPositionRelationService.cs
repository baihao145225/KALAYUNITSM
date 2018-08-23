using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IUserPositionRelationService : IBaseService<Sys_UserPositionRelation>
    {

        List<Sys_UserPositionRelation> GetList(string userId);
        void SetPosition(string userId, string positionId);
    }
}
