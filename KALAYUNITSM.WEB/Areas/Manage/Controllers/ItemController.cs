using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Manage.Controllers
{
    public class ItemController : BaseController
    {

        private readonly IItemService _itemService;
        private readonly IItemsDetailService _itemsDetailService;

        public ItemController(IItemService itemService, IItemsDetailService itemsDetailService)
        {
            this._itemService = itemService;
            this._itemsDetailService = itemsDetailService;
        }

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 数据层
        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _itemService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = item.ParentId;
                model.name = item.Name;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _itemService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_Item item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = item.ParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _itemService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 数据层

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            long count = _itemService.GetChildCount(primaryKey);
            return Success();
        } 
        #endregion
    }
}