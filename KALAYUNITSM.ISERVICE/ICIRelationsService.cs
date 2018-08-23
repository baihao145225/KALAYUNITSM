using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ICIRelationsService : IBaseService<Conf_CIRelations>
    {
        IEnumerable<Conf_CIRelations_Dto> GetJoinList(string ciId);
    }
}
