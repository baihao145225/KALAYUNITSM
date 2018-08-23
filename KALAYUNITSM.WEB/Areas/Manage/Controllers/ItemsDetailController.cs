using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;
using AutoMapper;

namespace KALAYUNITSM.WEB.Areas.Manage.Controllers
{
    public class ItemsDetailController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly IItemsDetailService _itemsDetailService;

        public ItemsDetailController(IItemService itemService, IItemsDetailService itemsDetailService)
        {
            this._itemService = itemService;
            this._itemsDetailService = itemsDetailService;
        }

        #region 视图层
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord, string itemId)
        {
            int count;
            var pageData = _itemsDetailService.GetPageList(curr, nums, out count, keyWord, itemId);

            var result = new LayUI<Sys_ItemsDetail_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetItem(string itemId)
        {
            var data = _itemsDetailService.GetList(c => c.ItemId == itemId);
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_ItemsDetail item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = item.Id;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }

        [HttpPost]
        public ActionResult GetItemByCode(string itemCode)
        {
            string itemId = _itemService.Get(c => c.EnCode == itemCode).Id;
            var data = _itemsDetailService.GetList(c => c.ItemId == itemId);
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_ItemsDetail item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.EnCode;
                model.text = item.Name;
                model.parentId = "1000";
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson()); 
        }


        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _itemsDetailService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Sys_ItemsDetail model)
        {
            if (model.Id.IsNullOrEmpty())
            {
                var primaryKey = _itemsDetailService.Insert(model);
                return primaryKey != null ? Success() : Errors();
            }
            else
            {
                return _itemsDetailService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _itemsDetailService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}