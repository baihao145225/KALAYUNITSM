using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IOrganizationService : IBaseService<Sys_Organization>
    { 
        long GetChildCount(string parentId);
        List<Sys_Organization_Dto> GetPageList(int curr, int nums, out int count, string keyWord, string parentId);
    }
}
