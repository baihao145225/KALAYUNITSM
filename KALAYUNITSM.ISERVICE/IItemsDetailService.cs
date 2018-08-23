using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IItemsDetailService : IBaseService<Sys_ItemsDetail>
    {
        List<Sys_ItemsDetail_Dto> GetPageList(int curr, int nums, out int count, string keyWord, string itemId);
    }
}
