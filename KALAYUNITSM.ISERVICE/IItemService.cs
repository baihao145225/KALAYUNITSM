using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IItemService : IBaseService<Sys_Item>
    {
        long GetChildCount(string parentId);
    }
}
