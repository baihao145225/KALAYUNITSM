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
    public class ItemsDetailService : BaseService<Sys_ItemsDetail>, IItemsDetailService
    {
        private readonly IItemsDetailRepository _itemsDetailRepository;
        public ItemsDetailService(IItemsDetailRepository itemsDetailRepository)
        {
            this._itemsDetailRepository = itemsDetailRepository;
        }

        #region 数据层
        public List<Sys_ItemsDetail_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string itemId)
        {
            return _itemsDetailRepository.GetPageJoinList(pageIndex, pageSize, out count, itemId).ToList();
        }
        #endregion

        #region 操作层
        public override object Insert(Sys_ItemsDetail model)
        {
            model.Id = Tools.GuId();
            model.IsEnable = model.IsEnable == null ? false : true;
            model.IsDefault = model.IsDefault == null ? false : true; 
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now; 
            return _itemsDetailRepository.Insert(model);
        }
        public override bool Update(Sys_ItemsDetail model)
        {
            model.IsEnable = model.IsEnable == null ? false : true;
            model.IsDefault = model.IsDefault == null ? false : true; 
            var updateColumns = new List<string>() { "EnCode", "Name", "ItemId" };
            return _itemsDetailRepository.Update(model);
        } 
        #endregion
    }
}
