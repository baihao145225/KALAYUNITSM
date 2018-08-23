using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.DATA;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class ItemService : BaseService<Sys_Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        } 
        public List<Sys_Item> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Sys_Item>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _itemRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
        }

        public long GetChildCount(string parentId)
        {
            return _itemRepository.GetChildCount(parentId);
        }


    }
}
