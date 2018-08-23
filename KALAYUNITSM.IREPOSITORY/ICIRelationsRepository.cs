using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface ICIRelationsRepository : IBaseRepository<Conf_CIRelations>
    {
        IEnumerable<Conf_CIRelations_Dto> GetJoinList(string ciId);
    }
}
