using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Configure.Controllers
{
    public class CIGroupController : BaseController
    {
        private readonly ICIGroupService _cigroupService;

        public CIGroupController(ICIGroupService cigroupService)
        {
            this._cigroupService = cigroupService;
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
        public ActionResult GetJsonData(int curr, int nums, string keyWord, string parentId)
        {
            int count;
            var pageData = _cigroupService.GetPageList(curr, nums, out count, keyWord, parentId);
            var result = new LayUI<Conf_CIGroup_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _cigroupService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Conf_CIGroup item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = item.ParentId;
                model.data = item.Url;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
        [HttpPost]
        public ActionResult GetParentUrl()
        {
            var data = _cigroupService.GetList(c => c.ParentId != "1000");
            var treeList = new List<TreeSelectModel>();
            foreach (Conf_CIGroup item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = "1000";
                model.data = item.ParentId;
                treeList.Add(model);
            }
            return Content(treeList.OrderByDescending(c => c.data).ToList().ToTreeSelectJson());
        }
        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _cigroupService.GetList();
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
        public ActionResult GetListTreeCount()
        {
            var listAllItems = _cigroupService.GetListCount();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = item.ParentId;
                model.name = item.ParentId == "1000" ? item.Name : item.Name + " (" + item.Count + ")";
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }
        [HttpPost]
        public ActionResult GetListTreeSelect(string parentId = "")
        {
            List<Conf_CIGroup> lists;
            if (parentId == "")
            {
                lists = _cigroupService.GetList();
            }
            else
            {
                lists = _cigroupService.GetList(c => c.ParentId == parentId);
            }
            var listTree = new List<TreeSelectModel>();
            foreach (var item in lists)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                listTree.Add(model);
            }
            return Content(listTree.ToJson());
        }
        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _cigroupService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_CIGroup model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _cigroupService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _cigroupService.Update(model) ? Success() : Errors();
                }
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _cigroupService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion

    }
}