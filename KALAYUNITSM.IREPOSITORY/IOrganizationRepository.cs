using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IOrganizationRepository : IBaseRepository<Sys_Organization>
    { 
        long GetChildCount(string parentid);
        IEnumerable<Sys_Organization_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string parentId);
    }
}
