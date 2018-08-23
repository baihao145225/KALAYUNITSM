using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class ItemRepository : BaseRepository<Sys_Item>, IItemRepository
    { 
        public long GetChildCount(string parentid)
        {
            return base.GetCount(c => c.ParentId == parentid);
        }
    }
}
